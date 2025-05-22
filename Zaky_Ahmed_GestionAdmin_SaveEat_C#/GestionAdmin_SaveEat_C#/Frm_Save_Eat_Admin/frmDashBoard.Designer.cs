namespace GestionAdmin_SaveEat_C_
{
    partial class frmDashboard
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.tsmiDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiValidation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblCurrentSection = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlCharts = new System.Windows.Forms.Panel();
            this.pnlChartRight = new System.Windows.Forms.Panel();
            this.chartRightTitle = new System.Windows.Forms.Label();
            this.pnlChartLeft = new System.Windows.Forms.Panel();
            this.chartLeftTitle = new System.Windows.Forms.Label();
            this.pnlRecentActivity = new System.Windows.Forms.Panel();
            this.dgvRecentActivity = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRecentActivity = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlStatsCard4 = new System.Windows.Forms.Panel();
            this.lblStatsValue4 = new System.Windows.Forms.Label();
            this.lblStatsTitle4 = new System.Windows.Forms.Label();
            this.pnlStatsCard3 = new System.Windows.Forms.Panel();
            this.lblStatsValue3 = new System.Windows.Forms.Label();
            this.lblStatsTitle3 = new System.Windows.Forms.Label();
            this.pnlStatsCard2 = new System.Windows.Forms.Panel();
            this.lblStatsValue2 = new System.Windows.Forms.Label();
            this.lblStatsTitle2 = new System.Windows.Forms.Label();
            this.pnlStatsCard1 = new System.Windows.Forms.Panel();
            this.lblStatsValue1 = new System.Windows.Forms.Label();
            this.lblStatsTitle1 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.mnsMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlCharts.SuspendLayout();
            this.pnlChartRight.SuspendLayout();
            this.pnlChartLeft.SuspendLayout();
            this.pnlRecentActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.pnlStatsCard4.SuspendLayout();
            this.pnlStatsCard3.SuspendLayout();
            this.pnlStatsCard2.SuspendLayout();
            this.pnlStatsCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDashboard,
            this.tsmiUsers,
            this.tsmiValidation,
            this.tsmiSettings,
            this.tsmiLogout});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.mnsMain.Size = new System.Drawing.Size(1116, 31);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // tsmiDashboard
            // 
            this.tsmiDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.tsmiDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiDashboard.ForeColor = System.Drawing.Color.White;
            this.tsmiDashboard.Name = "tsmiDashboard";
            this.tsmiDashboard.Size = new System.Drawing.Size(147, 27);
            this.tsmiDashboard.Text = "&Tableau de bord";
            this.tsmiDashboard.Click += new System.EventHandler(this.tsmiDashboard_Click);
            // 
            // tsmiUsers
            // 
            this.tsmiUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiUsers.ForeColor = System.Drawing.Color.White;
            this.tsmiUsers.Name = "tsmiUsers";
            this.tsmiUsers.Size = new System.Drawing.Size(108, 27);
            this.tsmiUsers.Text = "&Utilisateurs";
            this.tsmiUsers.Click += new System.EventHandler(this.tsmiUsers_Click);
            // 
            // tsmiValidation
            // 
            this.tsmiValidation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiValidation.ForeColor = System.Drawing.Color.White;
            this.tsmiValidation.Name = "tsmiValidation";
            this.tsmiValidation.Size = new System.Drawing.Size(100, 27);
            this.tsmiValidation.Text = "&Validation";
            this.tsmiValidation.Click += new System.EventHandler(this.tsmiValidation_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiSettings.ForeColor = System.Drawing.Color.White;
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(109, 27);
            this.tsmiSettings.Text = "&Paramètres";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiLogout
            // 
            this.tsmiLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmiLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiLogout.ForeColor = System.Drawing.Color.White;
            this.tsmiLogout.Name = "tsmiLogout";
            this.tsmiLogout.Size = new System.Drawing.Size(124, 27);
            this.tsmiLogout.Text = "&Déconnexion";
            this.tsmiLogout.Click += new System.EventHandler(this.tsmiLogout_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblUsername);
            this.pnlHeader.Controls.Add(this.lblCurrentSection);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 31);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1116, 60);
            this.pnlHeader.TabIndex = 1;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::GestionAdmin_SaveEat_C_.Properties.Resources.Fichier_1;
            this.picLogo.Location = new System.Drawing.Point(10, 5);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(103, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblUsername.Location = new System.Drawing.Point(853, 19);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(251, 23);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Bonjour, Admin";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentSection
            // 
            this.lblCurrentSection.AutoSize = true;
            this.lblCurrentSection.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblCurrentSection.Location = new System.Drawing.Point(118, 17);
            this.lblCurrentSection.Name = "lblCurrentSection";
            this.lblCurrentSection.Size = new System.Drawing.Size(190, 32);
            this.lblCurrentSection.TabIndex = 0;
            this.lblCurrentSection.Text = "Tableau de bord";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.pnlContent.Controls.Add(this.pnlCharts);
            this.pnlContent.Controls.Add(this.pnlRecentActivity);
            this.pnlContent.Controls.Add(this.pnlStats);
            this.pnlContent.Controls.Add(this.lblWelcome);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 91);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(1116, 645);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlCharts
            // 
            this.pnlCharts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCharts.Controls.Add(this.pnlChartRight);
            this.pnlCharts.Controls.Add(this.pnlChartLeft);
            this.pnlCharts.Location = new System.Drawing.Point(23, 400);
            this.pnlCharts.Name = "pnlCharts";
            this.pnlCharts.Size = new System.Drawing.Size(1071, 150);
            this.pnlCharts.TabIndex = 3;
            // 
            // pnlChartRight
            // 
            this.pnlChartRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChartRight.BackColor = System.Drawing.Color.White;
            this.pnlChartRight.Controls.Add(this.chartRightTitle);
            this.pnlChartRight.Location = new System.Drawing.Point(530, 5);
            this.pnlChartRight.Name = "pnlChartRight";
            this.pnlChartRight.Size = new System.Drawing.Size(500, 140);
            this.pnlChartRight.TabIndex = 1;
            // 
            // chartRightTitle
            // 
            this.chartRightTitle.AutoSize = true;
            this.chartRightTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartRightTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chartRightTitle.Location = new System.Drawing.Point(15, 15);
            this.chartRightTitle.Name = "chartRightTitle";
            this.chartRightTitle.Size = new System.Drawing.Size(305, 25);
            this.chartRightTitle.TabIndex = 0;
            this.chartRightTitle.Text = "Évolution des aliments sauvés (kg)";
            // 
            // pnlChartLeft
            // 
            this.pnlChartLeft.BackColor = System.Drawing.Color.White;
            this.pnlChartLeft.Controls.Add(this.chartLeftTitle);
            this.pnlChartLeft.Location = new System.Drawing.Point(3, 5);
            this.pnlChartLeft.Name = "pnlChartLeft";
            this.pnlChartLeft.Size = new System.Drawing.Size(500, 140);
            this.pnlChartLeft.TabIndex = 0;
            // 
            // chartLeftTitle
            // 
            this.chartLeftTitle.AutoSize = true;
            this.chartLeftTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartLeftTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chartLeftTitle.Location = new System.Drawing.Point(15, 15);
            this.chartLeftTitle.Name = "chartLeftTitle";
            this.chartLeftTitle.Size = new System.Drawing.Size(262, 25);
            this.chartLeftTitle.TabIndex = 0;
            this.chartLeftTitle.Text = "Restaurants par département";
            // 
            // pnlRecentActivity
            // 
            this.pnlRecentActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRecentActivity.BackColor = System.Drawing.Color.White;
            this.pnlRecentActivity.Controls.Add(this.dgvRecentActivity);
            this.pnlRecentActivity.Controls.Add(this.lblRecentActivity);
            this.pnlRecentActivity.Location = new System.Drawing.Point(23, 200);
            this.pnlRecentActivity.Name = "pnlRecentActivity";
            this.pnlRecentActivity.Size = new System.Drawing.Size(1071, 180);
            this.pnlRecentActivity.TabIndex = 2;
            // 
            // dgvRecentActivity
            // 
            this.dgvRecentActivity.AllowUserToAddRows = false;
            this.dgvRecentActivity.AllowUserToDeleteRows = false;
            this.dgvRecentActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecentActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentActivity.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentActivity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colAction,
            this.colUser,
            this.colDetails});
            this.dgvRecentActivity.Location = new System.Drawing.Point(15, 45);
            this.dgvRecentActivity.Name = "dgvRecentActivity";
            this.dgvRecentActivity.ReadOnly = true;
            this.dgvRecentActivity.RowHeadersVisible = false;
            this.dgvRecentActivity.RowHeadersWidth = 51;
            this.dgvRecentActivity.Size = new System.Drawing.Size(1041, 120);
            this.dgvRecentActivity.TabIndex = 1;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colAction
            // 
            this.colAction.HeaderText = "Action";
            this.colAction.MinimumWidth = 6;
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.HeaderText = "Utilisateur";
            this.colUser.MinimumWidth = 6;
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colDetails
            // 
            this.colDetails.HeaderText = "Détails";
            this.colDetails.MinimumWidth = 6;
            this.colDetails.Name = "colDetails";
            this.colDetails.ReadOnly = true;
            // 
            // lblRecentActivity
            // 
            this.lblRecentActivity.AutoSize = true;
            this.lblRecentActivity.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentActivity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblRecentActivity.Location = new System.Drawing.Point(15, 15);
            this.lblRecentActivity.Name = "lblRecentActivity";
            this.lblRecentActivity.Size = new System.Drawing.Size(171, 28);
            this.lblRecentActivity.TabIndex = 0;
            this.lblRecentActivity.Text = "Activités récentes";
            // 
            // pnlStats
            // 
            this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStats.Controls.Add(this.pnlStatsCard4);
            this.pnlStats.Controls.Add(this.pnlStatsCard3);
            this.pnlStats.Controls.Add(this.pnlStatsCard2);
            this.pnlStats.Controls.Add(this.pnlStatsCard1);
            this.pnlStats.Location = new System.Drawing.Point(23, 83);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1071, 100);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlStatsCard4
            // 
            this.pnlStatsCard4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatsCard4.BackColor = System.Drawing.Color.White;
            this.pnlStatsCard4.Controls.Add(this.lblStatsValue4);
            this.pnlStatsCard4.Controls.Add(this.lblStatsTitle4);
            this.pnlStatsCard4.Location = new System.Drawing.Point(780, 5);
            this.pnlStatsCard4.Name = "pnlStatsCard4";
            this.pnlStatsCard4.Size = new System.Drawing.Size(250, 90);
            this.pnlStatsCard4.TabIndex = 3;
            this.pnlStatsCard4.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatsCard4_Paint);
            // 
            // lblStatsValue4
            // 
            this.lblStatsValue4.AutoSize = true;
            this.lblStatsValue4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsValue4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblStatsValue4.Location = new System.Drawing.Point(23, 42);
            this.lblStatsValue4.Name = "lblStatsValue4";
            this.lblStatsValue4.Size = new System.Drawing.Size(60, 41);
            this.lblStatsValue4.TabIndex = 1;
            this.lblStatsValue4.Text = "4,2";
            // 
            // lblStatsTitle4
            // 
            this.lblStatsTitle4.AutoSize = true;
            this.lblStatsTitle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsTitle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblStatsTitle4.Location = new System.Drawing.Point(23, 15);
            this.lblStatsTitle4.Name = "lblStatsTitle4";
            this.lblStatsTitle4.Size = new System.Drawing.Size(162, 23);
            this.lblStatsTitle4.TabIndex = 0;
            this.lblStatsTitle4.Text = "Note de satisfaction";
            // 
            // pnlStatsCard3
            // 
            this.pnlStatsCard3.BackColor = System.Drawing.Color.White;
            this.pnlStatsCard3.Controls.Add(this.lblStatsValue3);
            this.pnlStatsCard3.Controls.Add(this.lblStatsTitle3);
            this.pnlStatsCard3.Location = new System.Drawing.Point(523, 5);
            this.pnlStatsCard3.Name = "pnlStatsCard3";
            this.pnlStatsCard3.Size = new System.Drawing.Size(250, 90);
            this.pnlStatsCard3.TabIndex = 2;
            // 
            // lblStatsValue3
            // 
            this.lblStatsValue3.AutoSize = true;
            this.lblStatsValue3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsValue3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblStatsValue3.Location = new System.Drawing.Point(23, 42);
            this.lblStatsValue3.Name = "lblStatsValue3";
            this.lblStatsValue3.Size = new System.Drawing.Size(113, 41);
            this.lblStatsValue3.TabIndex = 1;
            this.lblStatsValue3.Text = "523 kg";
            // 
            // lblStatsTitle3
            // 
            this.lblStatsTitle3.AutoSize = true;
            this.lblStatsTitle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblStatsTitle3.Location = new System.Drawing.Point(23, 15);
            this.lblStatsTitle3.Name = "lblStatsTitle3";
            this.lblStatsTitle3.Size = new System.Drawing.Size(131, 23);
            this.lblStatsTitle3.TabIndex = 0;
            this.lblStatsTitle3.Text = "Aliments sauvés";
            // 
            // pnlStatsCard2
            // 
            this.pnlStatsCard2.BackColor = System.Drawing.Color.White;
            this.pnlStatsCard2.Controls.Add(this.lblStatsValue2);
            this.pnlStatsCard2.Controls.Add(this.lblStatsTitle2);
            this.pnlStatsCard2.Location = new System.Drawing.Point(263, 5);
            this.pnlStatsCard2.Name = "pnlStatsCard2";
            this.pnlStatsCard2.Size = new System.Drawing.Size(250, 90);
            this.pnlStatsCard2.TabIndex = 1;
            // 
            // lblStatsValue2
            // 
            this.lblStatsValue2.AutoSize = true;
            this.lblStatsValue2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsValue2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblStatsValue2.Location = new System.Drawing.Point(23, 42);
            this.lblStatsValue2.Name = "lblStatsValue2";
            this.lblStatsValue2.Size = new System.Drawing.Size(52, 41);
            this.lblStatsValue2.TabIndex = 1;
            this.lblStatsValue2.Text = "18";
            // 
            // lblStatsTitle2
            // 
            this.lblStatsTitle2.AutoSize = true;
            this.lblStatsTitle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblStatsTitle2.Location = new System.Drawing.Point(23, 15);
            this.lblStatsTitle2.Name = "lblStatsTitle2";
            this.lblStatsTitle2.Size = new System.Drawing.Size(103, 23);
            this.lblStatsTitle2.TabIndex = 0;
            this.lblStatsTitle2.Text = "Associations";
            // 
            // pnlStatsCard1
            // 
            this.pnlStatsCard1.BackColor = System.Drawing.Color.White;
            this.pnlStatsCard1.Controls.Add(this.lblStatsValue1);
            this.pnlStatsCard1.Controls.Add(this.lblStatsTitle1);
            this.pnlStatsCard1.Location = new System.Drawing.Point(3, 5);
            this.pnlStatsCard1.Name = "pnlStatsCard1";
            this.pnlStatsCard1.Size = new System.Drawing.Size(250, 90);
            this.pnlStatsCard1.TabIndex = 0;
            // 
            // lblStatsValue1
            // 
            this.lblStatsValue1.AutoSize = true;
            this.lblStatsValue1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsValue1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblStatsValue1.Location = new System.Drawing.Point(23, 42);
            this.lblStatsValue1.Name = "lblStatsValue1";
            this.lblStatsValue1.Size = new System.Drawing.Size(52, 41);
            this.lblStatsValue1.TabIndex = 1;
            this.lblStatsValue1.Text = "42";
            // 
            // lblStatsTitle1
            // 
            this.lblStatsTitle1.AutoSize = true;
            this.lblStatsTitle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblStatsTitle1.Location = new System.Drawing.Point(23, 15);
            this.lblStatsTitle1.Name = "lblStatsTitle1";
            this.lblStatsTitle1.Size = new System.Drawing.Size(99, 23);
            this.lblStatsTitle1.TabIndex = 0;
            this.lblStatsTitle1.Text = "Restaurants";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblWelcome.Location = new System.Drawing.Point(23, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(607, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Bienvenue dans le système d\'administration de SaveEat";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1116, 736);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.mnsMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mnsMain;
            this.MaximumSize = new System.Drawing.Size(1231, 783);
            this.MinimumSize = new System.Drawing.Size(1042, 783);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaveEat - Administration";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlCharts.ResumeLayout(false);
            this.pnlChartRight.ResumeLayout(false);
            this.pnlChartRight.PerformLayout();
            this.pnlChartLeft.ResumeLayout(false);
            this.pnlChartLeft.PerformLayout();
            this.pnlRecentActivity.ResumeLayout(false);
            this.pnlRecentActivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStatsCard4.ResumeLayout(false);
            this.pnlStatsCard4.PerformLayout();
            this.pnlStatsCard3.ResumeLayout(false);
            this.pnlStatsCard3.PerformLayout();
            this.pnlStatsCard2.ResumeLayout(false);
            this.pnlStatsCard2.PerformLayout();
            this.pnlStatsCard1.ResumeLayout(false);
            this.pnlStatsCard1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiDashboard;
        //private System.Windows.Forms.ToolStripMenuItem tsmiRestaurants;
        //private System.Windows.Forms.ToolStripMenuItem tsmiAssociations;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmiValidation;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblCurrentSection;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlCharts;
        private System.Windows.Forms.Panel pnlChartRight;
        private System.Windows.Forms.Label chartRightTitle;
        private System.Windows.Forms.Panel pnlChartLeft;
        private System.Windows.Forms.Label chartLeftTitle;
        private System.Windows.Forms.Panel pnlRecentActivity;
        private System.Windows.Forms.DataGridView dgvRecentActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetails;
        private System.Windows.Forms.Label lblRecentActivity;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlStatsCard4;
        private System.Windows.Forms.Label lblStatsValue4;
        private System.Windows.Forms.Label lblStatsTitle4;
        private System.Windows.Forms.Panel pnlStatsCard3;
        private System.Windows.Forms.Label lblStatsValue3;
        private System.Windows.Forms.Label lblStatsTitle3;
        private System.Windows.Forms.Panel pnlStatsCard2;
        private System.Windows.Forms.Label lblStatsValue2;
        private System.Windows.Forms.Label lblStatsTitle2;
        private System.Windows.Forms.Panel pnlStatsCard1;
        private System.Windows.Forms.Label lblStatsValue1;
        private System.Windows.Forms.Label lblStatsTitle1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox picLogo;
    }
}
