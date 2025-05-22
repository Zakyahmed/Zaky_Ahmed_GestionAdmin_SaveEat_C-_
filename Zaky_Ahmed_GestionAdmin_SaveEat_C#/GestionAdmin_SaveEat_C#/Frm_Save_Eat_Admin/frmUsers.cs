using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using GestionAdmin_SaveEat_C_.Services;
using GestionAdmin_SaveEat_C_.Models;

namespace GestionAdmin_SaveEat_C_
{
    public partial class frmUsers : Form
    {
        private string currentUsername;
        private ApiService apiService;
        private List<Utilisateur> users = new List<Utilisateur>();

        public frmUsers(string username)
        {
            InitializeComponent();
            currentUsername = username;

            // Utiliser l'instance singleton
            apiService = ApiServiceManager.Instance;
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            try
            {
                lblUsername.Text = $"Bonjour, {currentUsername}";

                // Charger la liste des utilisateurs
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des utilisateurs : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Déjà sur la page des utilisateurs, donc rien à faire
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
            try
            {
                // Naviguer vers les paramètres
                frmParametre frm = new frmParametre(currentUsername);
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la navigation : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void tsmiLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Déconnexion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        // Déconnexion via l'API
                        await apiService.AdminLogoutAsync();
                    }
                    catch (Exception ex)
                    {
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

        #region Gestion des données

        private async Task LoadUsersAsync()
        {
            try
            {
                // Afficher un indicateur de chargement
                Cursor.Current = Cursors.WaitCursor;

                // Récupérer les utilisateurs depuis l'API
                users = await apiService.GetAllUsersAsync();

                // Charger les filtres
                LoadFilterData();

                // Charger les données dans la grille
                LoadUsersData();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erreur lors de la récupération des utilisateurs : {ex.Message}",
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUsersFromApiAsync()
        {
            await LoadUsersAsync();
        }

        private void LoadFilterData()
        {
            try
            {
                // Remplir les combobox de filtres

                // Types d'utilisateurs
                cmbStatus.Items.Clear();
                cmbStatus.Items.Add("Tous les types");
                cmbStatus.Items.Add("restaurant");
                cmbStatus.Items.Add("association");
                cmbStatus.Items.Add("admin");
                cmbStatus.Items.Add("utilisateur");
                cmbStatus.SelectedIndex = 0;

                // Rôles
                cmbRole.Items.Clear();
                cmbRole.Items.Add("Tous les rôles");
                cmbRole.Items.Add("admin");
                cmbRole.Items.Add("restaurant");
                cmbRole.Items.Add("association");
                cmbRole.Items.Add("utilisateur");
                cmbRole.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des filtres : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadUsersData()
        {
            try
            {
                // Suspendre la mise à jour du DataGridView pour améliorer les performances
                dgvUsers.SuspendLayout();

                // Effacer les lignes existantes
                dgvUsers.Rows.Clear();

                // Appliquer les filtres
                string searchText = txtSearch.Text.ToLower();
                string typeFilter = cmbStatus.SelectedIndex > 0 ? cmbStatus.SelectedItem.ToString() : "";
                string roleFilter = cmbRole.SelectedIndex > 0 ? cmbRole.SelectedItem.ToString() : "";

                // Ajouter les utilisateurs filtrés
                foreach (var user in users)
                {
                    // Appliquer le filtre de recherche
                    bool matchesSearch = string.IsNullOrEmpty(searchText) ||
                                        user.Nom.ToLower().Contains(searchText) ||
                                        user.Prenom.ToLower().Contains(searchText) ||
                                        user.Email.ToLower().Contains(searchText);

                    // Appliquer le filtre de type
                    bool matchesType = string.IsNullOrEmpty(typeFilter) || user.Type == typeFilter;

                    // Appliquer le filtre de rôle
                    bool matchesRole = string.IsNullOrEmpty(roleFilter) || user.RolePrincipal == roleFilter;

                    // Si l'utilisateur correspond à tous les filtres, l'ajouter à la grille
                    if (matchesSearch && matchesType && matchesRole)
                    {
                        dgvUsers.Rows.Add(
                            user.Id,
                            user.Nom,
                            user.Prenom,
                            user.Email,
                            user.Username,
                            user.RolePrincipal,
                            user.Type,
                            user.DateInscription.ToString("dd/MM/yyyy")
                        );
                    }
                }

                // Si aucun utilisateur n'est affiché après filtrage, informer l'utilisateur
                if (dgvUsers.Rows.Count == 0)
                {
                    MessageBox.Show("Aucun utilisateur ne correspond aux critères de recherche.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Réactiver la mise à jour du DataGridView
                dgvUsers.ResumeLayout();
            }
        }

        #endregion

        #region Gestion des événements

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Appliquer les filtres et recharger les données
                LoadUsersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                // Réinitialiser les filtres
                txtSearch.Text = "";
                cmbStatus.SelectedIndex = 0;
                cmbRole.SelectedIndex = 0;

                // Recharger les données
                await LoadUsersFromApiAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la réinitialisation des filtres : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Export vers Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Fichiers Excel (*.xlsx)|*.xlsx|Tous les fichiers (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.FileName = $"Utilisateurs_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("L'export des données est en cours de développement.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'export : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Ouvrir le formulaire en mode ajout
                frmAddEditUser frm = new frmAddEditUser(this, null);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Rafraîchir la liste après ajout avec await
                    await LoadUsersAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifier que le clic est sur une ligne valide
            if (e.RowIndex < 0)
                return;

            try
            {
                // Identifier si la colonne cliquée est un bouton d'action
                string columnName = dgvUsers.Columns[e.ColumnIndex].Name;
                bool isEditColumn = columnName == "colEdit";
                bool isDeleteColumn = columnName == "colDelete";

                if (!isEditColumn && !isDeleteColumn)
                    return;

                // Récupérer l'ID de l'utilisateur à partir de la première cellule de la ligne
                int userId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells[0].Value);

                // Trouver l'utilisateur correspondant
                Utilisateur targetUser = users.FirstOrDefault(u => u.Id == userId);

                if (targetUser == null)
                {
                    MessageBox.Show("Utilisateur introuvable.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Traiter l'action en fonction de la colonne cliquée
                if (isEditColumn)
                {
                    // Ouvrir le formulaire de modification
                    frmAddEditUser frm = new frmAddEditUser(this, targetUser);
                    frm.ShowDialog();
                }
                else if (isDeleteColumn)
                {
                    // Demander confirmation avant suppression
                    string userName = $"{targetUser.Prenom} {targetUser.Nom}";
                    DialogResult result = MessageBox.Show(
                        $"Êtes-vous sûr de vouloir supprimer l'utilisateur {userName} ?",
                        "Confirmation de suppression",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Afficher un indicateur de chargement
                            Cursor.Current = Cursors.WaitCursor;

                            // Supprimer via l'API
                            bool deleted = await apiService.DeleteUserAsync(userId);

                            Cursor.Current = Cursors.Default;

                            if (deleted)
                            {
                                // Actualiser la liste après la suppression
                                await LoadUsersFromApiAsync();

                                MessageBox.Show($"L'utilisateur {userName} a été supprimé avec succès.",
                                    "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Erreur lors de la suppression de l'utilisateur.",
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show($"Erreur lors de la suppression : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Méthodes publiques

        public int GetNextUserId()
        {
            try
            {
                // Obtenir le prochain ID disponible
                if (users == null || users.Count == 0)
                    return 1;

                return users.Max(u => u.Id) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la génération d'ID : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }

        public async Task<int> AddUserAsync(Utilisateur user)
        {
            if (user == null)
                return -1;

            try
            {
                // Préparer les données pour l'API
                var userData = new
                {
                    nom = user.Nom,
                    prenom = user.Prenom,
                    email = user.Email,
                    username = user.Username,
                    password = "TempPassword123!", // Mot de passe temporaire
                    type = user.Type,
                    role = user.RolePrincipal
                };

                // Utilisez await ici pour l'appel async
                await Task.Delay(100); // Simuler un appel API

                MessageBox.Show("La création d'utilisateur sera implémentée selon votre endpoint API.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Rafraîchir la liste avec await
                await LoadUsersFromApiAsync();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'utilisateur : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public async Task<bool> UpdateUserAsync(Utilisateur user)
        {
            if (user == null)
                return false;

            try
            {
                // Utiliser l'instance singleton
                var apiService = ApiServiceManager.Instance;

                // Préparer les données pour la mise à jour
                var updateData = new
                {
                    nom = user.Nom,
                    prenom = user.Prenom,
                    email = user.Email,
                    username = user.Username,
                    type = user.Type // ou user.RolePrincipal selon le cas
                };

                // Log pour debug
                Console.WriteLine($"Mise à jour de l'utilisateur {user.Id}");
                Console.WriteLine($"Données : {Newtonsoft.Json.JsonConvert.SerializeObject(updateData)}");

                // Mettre à jour l'utilisateur via l'API
                var updatedUser = await apiService.UpdateUserAsync(user.Id, updateData);

                if (updatedUser != null)
                {
                    Console.WriteLine($"Utilisateur mis à jour avec succès");

                    // Mettre à jour l'utilisateur dans la liste locale
                    var index = users.FindIndex(u => u.Id == user.Id);
                    if (index >= 0)
                    {
                        users[index] = updatedUser;
                    }

                    // Rafraîchir la grille
                    LoadUsersData();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
    }
}