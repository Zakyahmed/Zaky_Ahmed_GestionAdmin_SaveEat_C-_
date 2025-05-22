using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using GestionAdmin_SaveEat_C_.Services;
using GestionAdmin_SaveEat_C_.Models;
using System.Linq;

namespace GestionAdmin_SaveEat_C_
{
    public partial class frmValidation : Form
    {
        // Variables privées pour stocker les données
        private string currentUsername;
        private List<ValidationRequest> requests = new List<ValidationRequest>();
        private ValidationRequest selectedRequest;
        private ApiService apiService;

        // Constructeur
        public frmValidation(string username = "Admin")
        {
            InitializeComponent();
            currentUsername = username;

            // Utiliser l'instance singleton
            apiService = ApiServiceManager.Instance;
        }

        private async void frmValidation_Load(object sender, EventArgs e)
        {
            try
            {
                // Mettre à jour le nom d'utilisateur dans le header
                lblUsername.Text = $"Bonjour, {currentUsername}";

                // Remplir les combobox de filtres
                LoadFilterData();

                // Charger les données des demandes
                await LoadRequestsFromApiAsync();

                // Désactiver les boutons d'approbation/rejet
                EnableActionButtons(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des demandes : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRequest != null && !string.IsNullOrEmpty(selectedRequest.JustificatifPath))
                {
                    OpenFile(selectedRequest.JustificatifPath);
                }
                else
                {
                    MessageBox.Show("Aucun fichier justificatif disponible.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture du fichier : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Le fichier n'existe pas.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ouvrir le fichier avec l'application par défaut associée à son extension
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture du fichier: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Déjà sur la page de validation, donc rien à faire
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

        #region Gestion des données

        private async Task LoadRequestsFromApiAsync()
        {
            try
            {
                // Afficher un indicateur de chargement
                Cursor.Current = Cursors.WaitCursor;

                // Récupérer les demandes depuis l'API
                requests = await apiService.GetValidationRequestsAsync();

                // Charger les données
                LoadRequestsData();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erreur lors de la récupération des demandes : {ex.Message}",
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilterData()
        {
            try
            {
                // Remplir les combobox Type
                cmbType.Items.Clear();
                cmbType.Items.Add("Tous les types");
                cmbType.Items.Add("Restaurant");
                cmbType.Items.Add("Association");
                cmbType.SelectedIndex = 0;

                // Remplir les combobox Statut
                cmbStatus.Items.Clear();
                cmbStatus.Items.Add("Tous les statuts");
                cmbStatus.Items.Add("En attente");
                cmbStatus.Items.Add("Approuvé");
                cmbStatus.Items.Add("Rejeté");
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des filtres : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRequestsData()
        {
            try
            {
                // Effacer les lignes existantes
                dgvRequests.Rows.Clear();

                // Appliquer les filtres
                string searchText = txtSearch.Text.ToLower();
                string type = cmbType.SelectedIndex > 0 ? cmbType.SelectedItem.ToString() : "";
                string status = cmbStatus.SelectedIndex > 0 ? cmbStatus.SelectedItem.ToString() : "";

                // Ajouter les demandes filtrées
                foreach (var request in requests)
                {
                    // Appliquer le filtre de recherche
                    bool matchesSearch = string.IsNullOrEmpty(searchText) ||
                                        request.Nom.ToLower().Contains(searchText) ||
                                        request.Id.ToString().Contains(searchText);

                    // Appliquer le filtre de type
                    bool matchesType = string.IsNullOrEmpty(type) || request.Type == type;

                    // Appliquer le filtre de statut
                    bool matchesStatus = string.IsNullOrEmpty(status) || request.Status == status;

                    // Si la demande correspond à tous les filtres, l'ajouter à la grille
                    if (matchesSearch && matchesType && matchesStatus)
                    {
                        dgvRequests.Rows.Add(
                            request.Id,
                            request.Nom,
                            request.Type,
                            request.DateDemande.ToShortDateString(),
                            request.Status
                        );
                    }
                }

                // Réinitialiser les détails
                ClearDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDetails()
        {
            try
            {
                lblDetailsNom.Text = "Nom: ";
                lblDetailsAdresse.Text = "Adresse: ";
                lblDetailsType.Text = "Type: ";
                lblDetailsEmail.Text = "Email: ";
                picJustificatif.Image = null;

                // Désactiver les boutons d'approbation/rejet
                EnableActionButtons(false);

                // Réinitialiser la demande sélectionnée
                selectedRequest = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la réinitialisation des détails: {ex.Message}");
            }
        }

        private void ShowRequestDetails(int requestId)
        {
            try
            {
                // Rechercher la demande correspondante
                selectedRequest = requests.Find(r => r.Id == requestId);

                if (selectedRequest != null)
                {
                    // Afficher les détails
                    lblDetailsNom.Text = $"Nom: {selectedRequest.Nom}";
                    lblDetailsAdresse.Text = $"Adresse: {selectedRequest.Adresse}";
                    lblDetailsType.Text = $"Type: {selectedRequest.Type}";
                    lblDetailsEmail.Text = $"Email: {selectedRequest.Email}";

                    // Charger l'image du justificatif
                    try
                    {
                        if (!string.IsNullOrEmpty(selectedRequest.JustificatifPath) &&
                            File.Exists(selectedRequest.JustificatifPath))
                        {
                            var extension = Path.GetExtension(selectedRequest.JustificatifPath).ToLower();
                            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" ||
                                extension == ".gif" || extension == ".bmp")
                            {
                                picJustificatif.Image = Image.FromFile(selectedRequest.JustificatifPath);
                            }
                            else
                            {
                                // Si ce n'est pas une image, afficher une icône
                                picJustificatif.Image = null;
                                picJustificatif.BackColor = Color.LightGray;
                            }
                        }
                        else
                        {
                            // Image par défaut si le fichier n'existe pas
                            picJustificatif.Image = null;
                            picJustificatif.BackColor = Color.LightGray;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur lors du chargement de l'image: {ex.Message}");
                        picJustificatif.Image = null;
                    }

                    // Activer/désactiver les boutons d'action selon le statut
                    EnableActionButtons(selectedRequest.Status == "En attente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'affichage des détails: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableActionButtons(bool enable)
        {
            try
            {
                btnApprove.Enabled = enable;
                btnReject.Enabled = enable;

                // Changer l'apparence des boutons
                btnApprove.BackColor = enable ? Color.FromArgb(76, 175, 80) : Color.FromArgb(200, 200, 200);
                btnReject.BackColor = enable ? Color.FromArgb(231, 76, 60) : Color.FromArgb(200, 200, 200);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'activation/désactivation des boutons: {ex.Message}");
            }
        }

        #endregion

        #region Gestion des événements

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRequestsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                // Réinitialiser les filtres
                txtSearch.Text = "";
                cmbType.SelectedIndex = 0;
                cmbStatus.SelectedIndex = 0;

                // Recharger les données
                await LoadRequestsFromApiAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la réinitialisation des filtres: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Gestion du bouton Voir dans la grille
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvRequests.Columns["colView"].Index)
                {
                    // Récupérer l'ID de la demande sélectionnée
                    int requestId = Convert.ToInt32(dgvRequests.Rows[e.RowIndex].Cells["colId"].Value);

                    // Afficher les détails
                    ShowRequestDetails(requestId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'affichage des détails: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (selectedRequest != null)
            {
                try
                {
                    // Afficher un indicateur de chargement
                    Cursor.Current = Cursors.WaitCursor;

                    // Approuver via l'API
                    var updatedRequest = await apiService.ApproveValidationRequestAsync(selectedRequest.Id);

                    Cursor.Current = Cursors.Default;

                    if (updatedRequest != null)
                    {
                        // Recharger les données pour mettre à jour la liste
                        await LoadRequestsFromApiAsync();

                        // Afficher un message de confirmation
                        MessageBox.Show($"La demande de {selectedRequest.Nom} a été approuvée avec succès",
                            "SaveEat", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Réinitialiser les détails
                        ClearDetails();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'approbation de la demande.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show($"Erreur lors de l'approbation : {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            if (selectedRequest != null)
            {
                try
                {
                    // Afficher un indicateur de chargement
                    Cursor.Current = Cursors.WaitCursor;

                    // Rejeter via l'API
                    var updatedRequest = await apiService.RejectValidationRequestAsync(selectedRequest.Id);

                    Cursor.Current = Cursors.Default;

                    if (updatedRequest != null)
                    {
                        // Recharger les données pour mettre à jour la liste
                        await LoadRequestsFromApiAsync();

                        // Afficher un message de confirmation
                        MessageBox.Show($"La demande de {selectedRequest.Nom} a été rejetée",
                            "SaveEat", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Réinitialiser les détails
                        ClearDetails();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors du rejet de la demande.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show($"Erreur lors du rejet : {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}