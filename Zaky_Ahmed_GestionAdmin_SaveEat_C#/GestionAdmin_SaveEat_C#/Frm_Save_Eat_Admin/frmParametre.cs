using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using GestionAdmin_SaveEat_C_.Services;
using GestionAdmin_SaveEat_C_.Models;

namespace GestionAdmin_SaveEat_C_
{
    public partial class frmParametre : Form
    {
        // Variables privées pour stocker les données
        private string currentUsername;
        private Utilisateur currentUser;
        private ApiService apiService;

        // Constructeur
        public frmParametre(string username = "Admin")
        {
            InitializeComponent();
            currentUsername = username;

            // Utiliser l'instance singleton
            apiService = ApiServiceManager.Instance;
        }

        private async void frmParametre_Load(object sender, EventArgs e)
        {
            try
            {
                // Mettre à jour le nom d'utilisateur dans le header
                lblUsername.Text = $"Bonjour, {currentUsername}";

                // Charger les données de l'utilisateur actuel
                await LoadCurrentUserAsync();

                // Charger les paramètres actuels
                LoadCurrentSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des paramètres : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCurrentUserAsync()
        {
            try
            {
                // Récupérer les informations de l'utilisateur connecté depuis l'API
                currentUser = await apiService.GetCurrentUserAsync();

                // Si l'utilisateur a été récupéré avec succès
                if (currentUser != null)
                {
                    // Mettre à jour les champs avec les informations de l'utilisateur
                    txtEmail.Text = currentUser.Email;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération de l'utilisateur: {ex.Message}");
                MessageBox.Show("Impossible de charger les informations du profil.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Gestion de la navigation

        private void tsmiDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                // Naviguer vers le tableau de bord
                frmDashboard frm = new frmDashboard(currentUsername);
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la navigation : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            try
            {
                // Naviguer vers la gestion des utilisateurs
                frmUsers frm = new frmUsers(currentUsername);
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la navigation : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiValidation_Click(object sender, EventArgs e)
        {
            try
            {
                // Naviguer vers la validation des justificatifs
                frmValidation frm = new frmValidation(currentUsername);
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la navigation : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            // Déjà sur la page des paramètres, donc rien à faire
        }

        private async void tsmiLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Déconnexion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Afficher un indicateur de chargement
                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        // Déconnexion via l'API
                        await apiService.AdminLogoutAsync();
                    }
                    catch (Exception ex)
                    {
                        // On ignore les erreurs de déconnexion
                        Console.WriteLine($"Erreur lors de la déconnexion: {ex.Message}");
                    }
                    finally
                    {
                        // Supprimer le token d'authentification
                        Storage.SetToken("");
                    }

                    Cursor.Current = Cursors.Default;

                    // Créer une nouvelle instance de l'écran de connexion
                    frmConnexion frm = new frmConnexion();
                    frm.Show();

                    // Fermer le formulaire actuel
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erreur lors de la déconnexion : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Gestion des paramètres

        private void LoadCurrentSettings()
        {
            try
            {
                // Paramètres du profil
                // L'email est déjà rempli par LoadCurrentUserAsync()

                // Paramètres d'interface
                rbThemeClair.Checked = true;
                rbThemeSombre.Checked = false;

                cmbTaillePolice.Items.Clear();
                cmbTaillePolice.Items.Add("Petite");
                cmbTaillePolice.Items.Add("Normale");
                cmbTaillePolice.Items.Add("Grande");
                cmbTaillePolice.Items.Add("Très grande");
                cmbTaillePolice.SelectedIndex = 1; // "Normale"

                cmbLangue.Items.Clear();
                cmbLangue.Items.Add("Français");
                cmbLangue.Items.Add("English");
                cmbLangue.Items.Add("Deutsch");
                cmbLangue.Items.Add("Italiano");
                cmbLangue.SelectedIndex = 0; // "Français"
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des paramètres: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier que les champs sont valides
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Veuillez entrer une adresse email valide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNewPassword.Text) != string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Veuillez remplir les deux champs de mot de passe ou aucun.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtNewPassword.Text) && txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Afficher un indicateur de chargement
                Cursor.Current = Cursors.WaitCursor;

                bool success = true;

                // Mettre à jour le profil si l'email a changé
                if (currentUser != null && currentUser.Email != txtEmail.Text)
                {
                    currentUser.Email = txtEmail.Text;
                    var updatedUser = await apiService.UpdateProfileAsync(currentUser);
                    if (updatedUser == null)
                    {
                        success = false;
                    }
                }

                // Changer le mot de passe si nécessaire
                if (!string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    // Demander le mot de passe actuel
                    using (var passwordDialog = new Form())
                    {
                        passwordDialog.Text = "Mot de passe actuel";
                        passwordDialog.Size = new Size(350, 150);
                        passwordDialog.StartPosition = FormStartPosition.CenterParent;
                        passwordDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                        passwordDialog.MaximizeBox = false;
                        passwordDialog.MinimizeBox = false;

                        var lblPassword = new Label
                        {
                            Text = "Entrez votre mot de passe actuel:",
                            Location = new Point(20, 20),
                            AutoSize = true
                        };

                        var txtCurrentPassword = new TextBox
                        {
                            PasswordChar = '●',
                            Location = new Point(20, 45),
                            Width = 290
                        };

                        var btnOk = new Button
                        {
                            Text = "OK",
                            DialogResult = DialogResult.OK,
                            Location = new Point(155, 80),
                            Width = 75
                        };

                        var btnCancel = new Button
                        {
                            Text = "Annuler",
                            DialogResult = DialogResult.Cancel,
                            Location = new Point(235, 80),
                            Width = 75
                        };

                        passwordDialog.Controls.Add(lblPassword);
                        passwordDialog.Controls.Add(txtCurrentPassword);
                        passwordDialog.Controls.Add(btnOk);
                        passwordDialog.Controls.Add(btnCancel);
                        passwordDialog.AcceptButton = btnOk;
                        passwordDialog.CancelButton = btnCancel;

                        if (passwordDialog.ShowDialog() == DialogResult.OK)
                        {
                            string currentPassword = txtCurrentPassword.Text;
                            success = await apiService.ChangePasswordAsync(currentPassword, txtNewPassword.Text, txtConfirmPassword.Text);
                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                    }
                }

                Cursor.Current = Cursors.Default;

                // Afficher un message de confirmation
                if (success)
                {
                    MessageBox.Show("Paramètres du profil enregistrés avec succès.", "SaveEat",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Réinitialiser les champs de mot de passe
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'enregistrement des paramètres.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erreur lors de l'enregistrement des paramètres: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveInterface_Click(object sender, EventArgs e)
        {
            try
            {
                // Sauvegarder les paramètres d'interface
                // Dans une vraie application, vous sauvegarderiez ces paramètres
                // dans un fichier de configuration ou les Properties.Settings

                string theme = rbThemeClair.Checked ? "Clair" : "Sombre";
                string fontSize = cmbTaillePolice.SelectedItem?.ToString() ?? "Normale";
                string language = cmbLangue.SelectedItem?.ToString() ?? "Français";

                MessageBox.Show($"Paramètres d'interface enregistrés:\n" +
                               $"Thème: {theme}\n" +
                               $"Taille de police: {fontSize}\n" +
                               $"Langue: {language}\n\n" +
                               "Les modifications prendront effet au prochain démarrage de l'application.",
                    "SaveEat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement des paramètres: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbThemeSombre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbThemeSombre.Checked)
            {
                // Prévisualisation du thème sombre (juste pour le panneau d'exemple)
                pnlThemePreview.BackColor = Color.FromArgb(52, 58, 64);
                lblPreviewText.ForeColor = Color.White;
            }
        }

        private void rbThemeClair_CheckedChanged(object sender, EventArgs e)
        {
            if (rbThemeClair.Checked)
            {
                // Prévisualisation du thème clair (juste pour le panneau d'exemple)
                pnlThemePreview.BackColor = Color.White;
                lblPreviewText.ForeColor = Color.FromArgb(60, 60, 60);
            }
        }

        #endregion

        private void lblTaillePolice_Click(object sender, EventArgs e)
        {
            // Méthode vide, générée automatiquement par le concepteur
        }
    }
}