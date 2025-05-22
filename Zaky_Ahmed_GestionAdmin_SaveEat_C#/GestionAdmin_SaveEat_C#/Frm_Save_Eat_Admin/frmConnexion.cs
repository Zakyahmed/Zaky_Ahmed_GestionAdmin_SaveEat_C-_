using System;
using System.Drawing;
using System.Windows.Forms;
using GestionAdmin_SaveEat_C_.Services;
using GestionAdmin_SaveEat_C_.Models;

namespace GestionAdmin_SaveEat_C_
{
    public partial class frmConnexion : Form
    {
        // Définition des couleurs SaveEat
        private Color saveEatGreen = Color.FromArgb(76, 175, 80);
        private Color saveEatOrange = Color.FromArgb(255, 152, 0);
        private Color saveEatCream = Color.FromArgb(247, 247, 215);
        private Color saveEatGray = Color.FromArgb(85, 85, 85);
        private ApiService apiService;

        public frmConnexion()
        {
            InitializeComponent();

            // Utiliser l'instance singleton
            apiService = ApiServiceManager.Instance;

            // Appliquer les effets visuels et les couleurs
            ApplyVisualEffects();

            // Charger les identifiants sauvegardés si disponibles
            LoadSavedCredentials();
        }

        private void ApplyVisualEffects()
        {
            // Configurer l'apparence du formulaire
            this.BackColor = saveEatCream;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Panel principal en blanc
            panelMain.BackColor = Color.White;

            // Appliquer les styles aux champs de texte
            ApplyTextBoxStyle(txtUsername);
            ApplyTextBoxStyle(txtPassword);

            // Configurer le bouton de connexion (vert SaveEat)
            btnConnexion.BackColor = saveEatGreen;
            btnConnexion.ForeColor = Color.White;
            btnConnexion.FlatStyle = FlatStyle.Flat;
            btnConnexion.FlatAppearance.BorderSize = 0;

            // Configurer l'effet de survol du bouton
            btnConnexion.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 160, 71); // Vert un peu plus foncé
            btnConnexion.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 142, 60); // Encore plus foncé
        }

        private void ApplyTextBoxStyle(TextBox textBox)
        {
            // Configurer l'apparence des champs de texte
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;

            // Ajouter des gestionnaires d'événements pour les effets de focus
            textBox.Enter += (sender, e) => {
                var txt = (TextBox)sender;
                txt.BackColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
            };

            textBox.Leave += (sender, e) => {
                var txt = (TextBox)sender;
                txt.BackColor = Color.White;
            };
        }

        private void LoadSavedCredentials()
        {
            // Dans une version future, vous pourriez utiliser:
            // txtUsername.Text = Properties.Settings.Default.SavedUsername;
            // chkRemember.Checked = !string.IsNullOrEmpty(Properties.Settings.Default.SavedUsername);
        }

        private async void btnConnexion_Click(object sender, EventArgs e)
        {
            // Vérifier que les champs ne sont pas vides
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Veuillez entrer votre email.", "Erreur de connexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Veuillez entrer votre mot de passe.", "Erreur de connexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                // Afficher un indicateur de chargement
                Cursor.Current = Cursors.WaitCursor;
                btnConnexion.Enabled = false;

                // Tentative de connexion admin via l'API
                var authResponse = await apiService.AdminLoginAsync(txtUsername.Text, txtPassword.Text);

                Cursor.Current = Cursors.Default;
                btnConnexion.Enabled = true;

                if (authResponse != null && authResponse.Success)
                {
                    // Vérifier que l'utilisateur est un administrateur
                    if (!authResponse.Utilisateur.Roles.Contains("admin"))
                    {
                        MessageBox.Show("Accès réservé aux administrateurs.",
                            "Erreur d'autorisation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Stocker le token dans Storage pour persistence
                    Storage.SetToken(authResponse.Token);

                    // Le token est déjà configuré dans apiService par AdminLoginAsync
                    // Mais on s'assure qu'il est bien configuré
                    apiService.SetAuthToken(authResponse.Token);

                    // Sauvegarder les identifiants si demandé
                    SaveCredentialsIfRequested();

                    // Ouvrir le tableau de bord avec les infos de l'utilisateur connecté
                    frmDashboard dashboard = new frmDashboard(authResponse.Utilisateur.Prenom);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    string errorMessage = authResponse?.Message ?? "Identifiant ou mot de passe incorrect.";
                    MessageBox.Show(errorMessage, "Erreur de connexion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                btnConnexion.Enabled = true;

                MessageBox.Show($"Erreur de connexion : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCredentialsIfRequested()
        {
            // Sauvegarder les identifiants si la case est cochée
            if (chkRemember.Checked)
            {
                // Dans une version future, vous pourriez utiliser:
                // Properties.Settings.Default.SavedUsername = txtUsername.Text;
                // Properties.Settings.Default.Save();
            }
            else
            {
                // Effacer les identifiants sauvegardés
                // Properties.Settings.Default.SavedUsername = string.Empty;
                // Properties.Settings.Default.Save();
            }
        }
    }
}