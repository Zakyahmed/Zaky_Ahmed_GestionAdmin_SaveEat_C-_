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
    public partial class frmRestaurants : Form
    {
        // Variables privées pour stocker les données
        private string currentUsername;
        private List<Restaurant> restaurants = new List<Restaurant>();
        private ApiService apiService;

        // Constructeur
        public frmRestaurants(string username = "Admin")
        {
            InitializeComponent();
            currentUsername = username;

            // Initialisation du service API
            apiService = new ApiService();
        }

        private async void frmRestaurants_Load(object sender, EventArgs e)
        {
            try
            {
                // Mettre à jour le nom d'utilisateur dans le header
                lblUsername.Text = $"Bonjour, {currentUsername}";

                // Remplir les combobox de filtres
                LoadFilterData();

                // Charger les données des restaurants depuis l'API
                await LoadRestaurantsFromApiAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des restaurants : {ex.Message}",
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
            // Déjà sur la page des restaurants, donc rien à faire
        }

        private void btnAssociations_Click(object sender, EventArgs e)
        {
            // Naviguer vers la gestion des associations
            frmAssociations associations = new frmAssociations(currentUsername);
            associations.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // Naviguer vers la gestion des utilisateurs
            frmUsers users = new frmUsers(currentUsername);
            users.Show();
            this.Hide();
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

        private async Task LoadRestaurantsFromApiAsync()
        {
            try
            {
                // Afficher un indicateur de chargement
                Cursor.Current = Cursors.WaitCursor;

                // Récupérer les restaurants depuis l'API
                restaurants = await apiService.GetAllRestaurantsAsync();

                // Charger les données
                LoadRestaurantsData();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erreur lors de la récupération des restaurants : {ex.Message}",
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

            // Remplir dynamiquement si nécessaire depuis l'API
            if (restaurants != null && restaurants.Count > 0)
            {
                var villes = restaurants.Select(r => r.Localite).Distinct().Where(l => !string.IsNullOrEmpty(l)).ToList();
                foreach (var ville in villes)
                {
                    cmbVille.Items.Add(ville);
                }

                var cantons = restaurants.Select(r => r.Canton).Distinct().Where(c => !string.IsNullOrEmpty(c)).ToList();
                foreach (var canton in cantons)
                {
                    cmbDepartement.Items.Add(canton);
                }
            }

            cmbVille.SelectedIndex = 0;
            cmbDepartement.SelectedIndex = 0;
        }

        private void LoadRestaurantsData()
        {
            try
            {
                // Effacer les lignes existantes
                dgvRestaurants.Rows.Clear();

                // Appliquer les filtres
                string searchText = txtSearch.Text.ToLower();
                string ville = cmbVille.SelectedIndex > 0 ? cmbVille.SelectedItem.ToString() : "";
                string canton = cmbDepartement.SelectedIndex > 0 ? cmbDepartement.SelectedItem.ToString() : "";

                foreach (var restaurant in restaurants)
                {
                    // Appliquer le filtre de recherche
                    if (!string.IsNullOrEmpty(searchText) &&
                        !restaurant.Nom.ToLower().Contains(searchText) &&
                        !restaurant.Id.ToString().Contains(searchText))
                        continue;

                    // Appliquer le filtre de ville
                    if (!string.IsNullOrEmpty(ville) && restaurant.Localite != ville)
                        continue;

                    // Appliquer le filtre de canton
                    if (!string.IsNullOrEmpty(canton) && restaurant.Canton != canton)
                        continue;

                    // Ajouter à la grille
                    dgvRestaurants.Rows.Add(
                        restaurant.Id,
                        restaurant.Nom,
                        restaurant.Adresse,
                        restaurant.Localite,
                        restaurant.Canton,
                        restaurant.Utilisateur?.Telephone ?? "",
                        restaurant.Utilisateur?.Email ?? "",
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
            LoadRestaurantsData();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            // Réinitialiser les filtres
            txtSearch.Text = "";
            cmbVille.SelectedIndex = 0;
            cmbDepartement.SelectedIndex = 0;

            // Recharger les données
            await LoadRestaurantsFromApiAsync();
        }

        private void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fonctionnalité d'ajout de restaurant à implémenter", "SaveEat",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fonctionnalité d'export à implémenter", "SaveEat",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvRestaurants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gestion des boutons Modifier et Supprimer dans la grille
            if (e.RowIndex >= 0)
            {
                // Récupérer l'ID du restaurant sélectionné
                int restaurantId = Convert.ToInt32(dgvRestaurants.Rows[e.RowIndex].Cells["colId"].Value);
                string restaurantName = dgvRestaurants.Rows[e.RowIndex].Cells["colNom"].Value.ToString();

                // Bouton Modifier
                if (e.ColumnIndex == dgvRestaurants.Columns["colEdit"].Index)
                {
                    MessageBox.Show($"Modifier le restaurant {restaurantName} (ID: {restaurantId})", "SaveEat",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Bouton Supprimer
                else if (e.ColumnIndex == dgvRestaurants.Columns["colDelete"].Index)
                {
                    if (MessageBox.Show($"Êtes-vous sûr de vouloir supprimer le restaurant {restaurantName} ?",
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