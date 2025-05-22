using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using GestionAdmin_SaveEat_C_.Services;
using GestionAdmin_SaveEat_C_.Models;

namespace GestionAdmin_SaveEat_C_
{
    public partial class frmDashboard : Form
    {
        // Variables privées pour stocker les données
        private string currentUsername;
        private List<ActivityLog> recentActivities = new List<ActivityLog>();
        private DashboardStats dashboardStats;
        private ApiService apiService;

        // Constructeur
        public frmDashboard(string username = "Admin")
        {
            InitializeComponent();
            currentUsername = username;

            // Utiliser l'instance singleton
            apiService = ApiServiceManager.Instance;
        }

        private async void frmDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                // Mettre à jour le nom d'utilisateur dans le header
                lblUsername.Text = $"Bonjour, {currentUsername}";

                // Charger les statistiques et les activités récentes
                await LoadDashboardDataAsync();

                // Initialiser les graphiques
                InitializeCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement du tableau de bord : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Gestion de la navigation

        private void tsmiDashboard_Click(object sender, EventArgs e)
        {
            lblCurrentSection.Text = "Tableau de bord";
            // Pas besoin de navigation car on est déjà sur le dashboard
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
                        // Nettoyer tout
                        ApiServiceManager.Reset();
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

        #region Chargement des données

        private async Task LoadDashboardDataAsync()
        {
            try
            {
                // Afficher un indicateur de chargement
                Cursor.Current = Cursors.WaitCursor;

                // Récupérer les statistiques du tableau de bord depuis l'API
                dashboardStats = await apiService.GetDashboardStatsAsync();

                if (dashboardStats != null)
                {
                    // Mettre à jour les statistiques
                    UpdateDashboardStats();

                    // Pour l'instant, pas d'activités récentes depuis l'API
                    LoadRecentActivities();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erreur lors de la récupération des données du tableau de bord : {ex.Message}",
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDashboardStats()
        {
            // Mettre à jour les cartes de statistiques
            if (dashboardStats != null)
            {
                lblStatsValue1.Text = dashboardStats.TotalRestaurants.ToString();
                lblStatsValue2.Text = dashboardStats.TotalAssociations.ToString();
                lblStatsValue3.Text = $"{dashboardStats.TotalFoodSaved} kg";
                lblStatsValue4.Text = dashboardStats.SatisfactionRating.ToString("F1");
            }
        }

        private void LoadRecentActivities()
        {
            try
            {
                // Effacer les données existantes
                dgvRecentActivity.Rows.Clear();

                // Pour l'instant, afficher un message d'information
                dgvRecentActivity.Rows.Add(
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    "Information",
                    "Système",
                    "Les activités récentes seront disponibles prochainement"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des activités récentes: {ex.Message}");
            }
        }

        private void InitializeCharts()
        {
            try
            {
                // Création d'un graphique simple pour démontrer le fonctionnement
                InitializeLeftChart();
                InitializeRightChart();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'initialisation des graphiques: {ex.Message}");

                // En cas d'erreur, afficher des placeholders
                Label lblChartLeft = new Label
                {
                    Text = "Graphique: Répartition par canton",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                pnlChartLeft.Controls.Add(lblChartLeft);

                Label lblChartRight = new Label
                {
                    Text = "Graphique: Évolution mensuelle des aliments sauvés",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                pnlChartRight.Controls.Add(lblChartRight);
            }
        }

        private void InitializeLeftChart()
        {
            // Nettoyage des contrôles existants
            pnlChartLeft.Controls.Clear();
            pnlChartLeft.Controls.Add(chartLeftTitle);

            // Création d'un panel pour le graphique
            Panel chartPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };
            pnlChartLeft.Controls.Add(chartPanel);

            // Données de démonstration pour la répartition par canton
            string[] cantons = { "Genève", "Vaud", "Valais", "Neuchâtel", "Fribourg" };
            int[] restaurantCounts = { 15, 8, 10, 6, 3 };

            // Création de barres pour représenter les données
            int maxCount = 0;
            foreach (int count in restaurantCounts)
            {
                if (count > maxCount) maxCount = count;
            }

            int barWidth = (chartPanel.Width - 60) / cantons.Length;
            int maxBarHeight = chartPanel.Height - 60;

            // Dessiner les barres et les libellés
            for (int i = 0; i < cantons.Length; i++)
            {
                // Barre
                int barHeight = (int)(restaurantCounts[i] * (maxBarHeight * 0.8) / maxCount);
                Panel bar = new Panel
                {
                    BackColor = Color.FromArgb(76, 175, 80),
                    Width = barWidth - 10,
                    Height = barHeight,
                    Location = new Point(30 + i * barWidth, chartPanel.Height - 40 - barHeight)
                };
                chartPanel.Controls.Add(bar);

                // Libellé du canton
                Label lblCanton = new Label
                {
                    Text = cantons[i],
                    Width = barWidth,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(30 + i * barWidth - 5, chartPanel.Height - 40)
                };
                chartPanel.Controls.Add(lblCanton);

                // Valeur
                Label lblValue = new Label
                {
                    Text = restaurantCounts[i].ToString(),
                    Width = barWidth,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(30 + i * barWidth - 5, chartPanel.Height - 40 - barHeight - 20)
                };
                chartPanel.Controls.Add(lblValue);
            }

            // Mettre à jour le titre
            chartLeftTitle.Text = "Restaurants par canton";
        }

        private void InitializeRightChart()
        {
            // Nettoyage des contrôles existants
            pnlChartRight.Controls.Clear();
            pnlChartRight.Controls.Add(chartRightTitle);

            // Création d'un panel pour le graphique
            Panel chartPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };
            pnlChartRight.Controls.Add(chartPanel);

            // Données de démonstration pour l'évolution mensuelle
            string[] months = { "Jan", "Fév", "Mar", "Avr", "Mai" };
            int[] foodSaved = { 120, 180, 210, 300, 523 };

            // Création d'une courbe pour représenter les données
            int maxValue = 0;
            foreach (int value in foodSaved)
            {
                if (value > maxValue) maxValue = value;
            }

            int pointWidth = (chartPanel.Width - 60) / (months.Length - 1);
            int maxHeight = chartPanel.Height - 60;

            // Dessiner la courbe et les points
            Point[] points = new Point[months.Length];
            for (int i = 0; i < months.Length; i++)
            {
                int x = 30 + i * pointWidth;
                int y = chartPanel.Height - 40 - (int)(foodSaved[i] * (maxHeight * 0.8) / maxValue);
                points[i] = new Point(x, y);

                // Point
                Panel point = new Panel
                {
                    BackColor = Color.FromArgb(255, 152, 0),
                    Width = 8,
                    Height = 8,
                    Location = new Point(x - 4, y - 4)
                };
                chartPanel.Controls.Add(point);

                // Libellé du mois
                Label lblMonth = new Label
                {
                    Text = months[i],
                    Width = pointWidth,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(x - pointWidth / 2, chartPanel.Height - 40)
                };
                chartPanel.Controls.Add(lblMonth);

                // Valeur
                Label lblValue = new Label
                {
                    Text = foodSaved[i].ToString() + " kg",
                    Width = pointWidth,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(x - pointWidth / 2, y - 25)
                };
                chartPanel.Controls.Add(lblValue);

                // Tracer une ligne vers le point précédent
                if (i > 0)
                {
                    // Ajout d'une ligne de panneau à la place
                    Panel linePanel = new Panel
                    {
                        BackColor = Color.FromArgb(255, 152, 0),
                        Width = pointWidth,
                        Height = 2,
                        Location = new Point(points[i - 1].X, points[i - 1].Y - 1)
                    };
                    chartPanel.Controls.Add(linePanel);
                }
            }
        }

        #endregion

        private async void picLogo_Click(object sender, EventArgs e)
        {
            try
            {
                // Retour au tableau de bord
                lblCurrentSection.Text = "Tableau de bord";

                // Rafraîchir les données
                await LoadDashboardDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du rafraîchissement des données : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlStatsCard4_Paint(object sender, PaintEventArgs e)
        {
            // Méthode vide, générée automatiquement par le concepteur
        }
    }
}