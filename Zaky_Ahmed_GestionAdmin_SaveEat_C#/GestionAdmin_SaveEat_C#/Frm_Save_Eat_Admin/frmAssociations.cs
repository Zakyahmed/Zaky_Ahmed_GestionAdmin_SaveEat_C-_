using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using GestionAdmin_SaveEat_C_.Models;
using GestionAdmin_SaveEat_C_.Services;
using System.Linq;

namespace GestionAdmin_SaveEat_C_
{
    public partial class frmAssociations : Form
    {
        // Variables privées pour stocker les données
        private string currentUsername;
        private List<Association> associations = new List<Association>();
        private ApiService apiService;

        // Constructeur
        public frmAssociations(string username = "Admin")
        {
            InitializeComponent();
            currentUsername = username;

            // Initialisation du service API
            apiService = new ApiService();
        }

        private async void frmAssociations_Load(object sender, EventArgs e)
        {
            try
            {
                // Mettre à jour le nom d'utilisateur dans le header
                lblUsername.Text = $"Bonjour, {currentUsername}";

                // Remplir les combobox de filtres
                LoadFilterData();

                // Charger les données des associations depuis l'API
                await LoadAssociationsFromApiAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des associations : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Gestion de la navigation

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Naviguer vers le tableau de bord
            frmDashboard dashboard = new frmDashboard(currentUsername);
            dashboard.Show();
            this.Hide();
        }

        private void btnRestaurants_Click(object sender, EventArgs e)
        {
            // Naviguer vers la gestion des restaurants
            frmRestaurants restaurants = new frmRestaurants(currentUsername);
            restaurants.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // Naviguer vers la gestion des utilisateurs
            frmUsers users = new frmUsers(currentUsername);
            users.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigation vers les rapports", "SaveEat",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Naviguer vers les paramètres
            frmParametre settings = new frmParametre(currentUsername);
            settings.Show();
            this.Hide();
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Déconnexion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await apiService.AdminLogoutAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la déconnexion: {ex.Message}");
                }
                finally
                {
                    Storage.SetToken("");
                }

                frmConnexion frm = new frmConnexion();
                frm.Show();
                this.Close();
            }
        }

        private void ActivateButton(Button button)
        {
            // Réinitialiser tous les boutons
            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn && btn != btnLogout)
                {
                    btn.BackColor = Color.FromArgb(52, 58, 64); // Couleur sombre du sidebar
                }
            }

            // Activer le bouton sélectionné
            button.BackColor = Color.FromArgb(76, 175, 80); // Couleur verte de SaveEat
        }

        #endregion

        #region Gestion des données

        private async Task LoadAssociationsFromApiAsync()
        {
            try
            {
                // Afficher un indicateur de chargement
                Cursor.Current = Cursors.WaitCursor;

                // Récupérer les associations depuis l'API
                associations = await apiService.GetAllAssociationsAsync();

                // Charger les données
                LoadAssociationsData();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erreur lors de la récupération des associations : {ex.Message}",
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilterData()
        {
            // Villes
            cmbVille.Items.Clear();
            cmbVille.Items.Add("Toutes les villes");

            // Cantons (remplacer départements)
            cmbDepartement.Items.Clear();
            cmbDepartement.Items.Add("Tous les cantons");

            // Types d'associations
            cmbType.Items.Clear();
            cmbType.Items.Add("Tous les types");

            // Remplir dynamiquement si nécessaire
            if (associations != null && associations.Count > 0)
            {
                var villes = associations.Select(a => a.Localite).Distinct().Where(l => !string.IsNullOrEmpty(l)).ToList();
                foreach (var ville in villes)
                {
                    cmbVille.Items.Add(ville);
                }

                var cantons = associations.Select(a => a.Canton).Distinct().Where(c => !string.IsNullOrEmpty(c)).ToList();
                foreach (var canton in cantons)
                {
                    cmbDepartement.Items.Add(canton);
                }
            }

            cmbVille.SelectedIndex = 0;
            cmbDepartement.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
        }

        private void LoadAssociationsData()
        {
            try
            {
                // Effacer les lignes existantes
                dgvAssociations.Rows.Clear();

                // Appliquer les filtres
                string searchText = txtSearch.Text.ToLower();
                string ville = cmbVille.SelectedIndex > 0 ? cmbVille.SelectedItem.ToString() : "";
                string canton = cmbDepartement.SelectedIndex > 0 ? cmbDepartement.SelectedItem.ToString() : "";
                string type = cmbType.SelectedIndex > 0 ? cmbType.SelectedItem.ToString() : "";

                foreach (var association in associations)
                {
                    // Appliquer le filtre de recherche
                    if (!string.IsNullOrEmpty(searchText) &&
                        !association.Nom.ToLower().Contains(searchText) &&
                        !association.Id.ToString().Contains(searchText))
                        continue;

                    // Appliquer le filtre de ville
                    if (!string.IsNullOrEmpty(ville) && association.Localite != ville)
                        continue;

                    // Appliquer le filtre de canton
                    if (!string.IsNullOrEmpty(canton) && association.Canton != canton)
                        continue;

                    // Ajouter à la grille
                    dgvAssociations.Rows.Add(
                        association.Id,
                        association.Nom,
                        association.IDE,  // Au lieu de SIRET
                        association.Adresse,
                        association.Localite,
                        association.Canton,
                        association.Utilisateur?.Telephone ?? "",
                        association.Utilisateur?.Email ?? "",
                        "Humanitaire",  // Type par défaut ou depuis l'API
                        "0 kg" // Valeur par défaut ou calculée
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Gestion des événements

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAssociationsData();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            // Réinitialiser les filtres
            txtSearch.Text = "";
            cmbVille.SelectedIndex = 0;
            cmbDepartement.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;

            // Recharger les données
            await LoadAssociationsFromApiAsync();
        }

        private void btnAddAssociation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fonctionnalité d'ajout d'association à implémenter", "SaveEat",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fonctionnalité d'export à implémenter", "SaveEat",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvAssociations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gestion des boutons Modifier et Supprimer dans la grille
            if (e.RowIndex >= 0)
            {
                // Récupérer l'ID de l'association sélectionnée
                int associationId = Convert.ToInt32(dgvAssociations.Rows[e.RowIndex].Cells["colId"].Value);
                string associationName = dgvAssociations.Rows[e.RowIndex].Cells["colNom"].Value.ToString();

                // Bouton Modifier
                if (e.ColumnIndex == dgvAssociations.Columns["colEdit"].Index)
                {
                    MessageBox.Show($"Modifier l'association {associationName} (ID: {associationId})", "SaveEat",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Bouton Supprimer
                else if (e.ColumnIndex == dgvAssociations.Columns["colDelete"].Index)
                {
                    if (MessageBox.Show($"Êtes-vous sûr de vouloir supprimer l'association {associationName} ?",
                        "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show($"Fonctionnalité de suppression à implémenter", "SaveEat",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion
    }
}