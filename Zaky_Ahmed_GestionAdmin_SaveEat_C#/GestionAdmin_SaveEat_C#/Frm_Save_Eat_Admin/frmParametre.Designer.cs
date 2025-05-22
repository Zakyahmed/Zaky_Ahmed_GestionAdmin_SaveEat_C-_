namespace GestionAdmin_SaveEat_C_
{
    partial class frmParametre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblProfileSettings = new System.Windows.Forms.Label();
            this.tabInterface = new System.Windows.Forms.TabPage();
            this.pnlThemePreview = new System.Windows.Forms.Panel();
            this.lblPreviewText = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            this.btnSaveInterface = new System.Windows.Forms.Button();
            this.cmbLangue = new System.Windows.Forms.ComboBox();
            this.lblLangue = new System.Windows.Forms.Label();
            this.cmbTaillePolice = new System.Windows.Forms.ComboBox();
            this.lblTaillePolice = new System.Windows.Forms.Label();
            this.pnlTheme = new System.Windows.Forms.Panel();
            this.rbThemeSombre = new System.Windows.Forms.RadioButton();
            this.rbThemeClair = new System.Windows.Forms.RadioButton();
            this.lblTheme = new System.Windows.Forms.Label();
            this.lblInterfaceSettings = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mnsMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabInterface.SuspendLayout();
            this.pnlThemePreview.SuspendLayout();
            this.pnlTheme.SuspendLayout();
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
            this.mnsMain.Size = new System.Drawing.Size(939, 31);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "Menu principal";
            // 
            // tsmiDashboard
            // 
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
            this.tsmiSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
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
            this.pnlHeader.Size = new System.Drawing.Size(939, 60);
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
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblUsername.Location = new System.Drawing.Point(676, 19);
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
            this.lblCurrentSection.Location = new System.Drawing.Point(120, 17);
            this.lblCurrentSection.Name = "lblCurrentSection";
            this.lblCurrentSection.Size = new System.Drawing.Size(137, 32);
            this.lblCurrentSection.TabIndex = 0;
            this.lblCurrentSection.Text = "Paramètres";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.pnlContent.Controls.Add(this.tabSettings);
            this.pnlContent.Controls.Add(this.lblTitle);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 91);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(939, 570);
            this.pnlContent.TabIndex = 2;
            // 
            // tabSettings
            // 
            this.tabSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSettings.Controls.Add(this.tabProfile);
            this.tabSettings.Controls.Add(this.tabInterface);
            this.tabSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSettings.Location = new System.Drawing.Point(23, 63);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(893, 484);
            this.tabSettings.TabIndex = 1;
            // 
            // tabProfile
            // 
            this.tabProfile.BackColor = System.Drawing.Color.White;
            this.tabProfile.Controls.Add(this.btnSaveProfile);
            this.tabProfile.Controls.Add(this.txtConfirmPassword);
            this.tabProfile.Controls.Add(this.lblConfirmPassword);
            this.tabProfile.Controls.Add(this.txtNewPassword);
            this.tabProfile.Controls.Add(this.lblNewPassword);
            this.tabProfile.Controls.Add(this.txtEmail);
            this.tabProfile.Controls.Add(this.lblEmail);
            this.tabProfile.Controls.Add(this.lblProfileSettings);
            this.tabProfile.Location = new System.Drawing.Point(4, 32);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(1030, 448);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profil administrateur";
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSaveProfile.FlatAppearance.BorderSize = 0;
            this.btnSaveProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProfile.ForeColor = System.Drawing.Color.White;
            this.btnSaveProfile.Location = new System.Drawing.Point(45, 263);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(160, 35);
            this.btnSaveProfile.TabIndex = 7;
            this.btnSaveProfile.Text = "&Enregistrer";
            this.btnSaveProfile.UseVisualStyleBackColor = false;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(45, 210);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '•';
            this.txtConfirmPassword.Size = new System.Drawing.Size(370, 30);
            this.txtConfirmPassword.TabIndex = 6;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(45, 183);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(220, 23);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "&Confirmer le mot de passe :";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.Location = new System.Drawing.Point(45, 145);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.Size = new System.Drawing.Size(370, 30);
            this.txtNewPassword.TabIndex = 4;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblNewPassword.Location = new System.Drawing.Point(45, 118);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(195, 23);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "&Nouveau mot de passe :";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(45, 80);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(370, 30);
            this.txtEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblEmail.Location = new System.Drawing.Point(45, 53);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(124, 23);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "&Adresse email :";
            // 
            // lblProfileSettings
            // 
            this.lblProfileSettings.AutoSize = true;
            this.lblProfileSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblProfileSettings.Location = new System.Drawing.Point(15, 15);
            this.lblProfileSettings.Name = "lblProfileSettings";
            this.lblProfileSettings.Size = new System.Drawing.Size(290, 28);
            this.lblProfileSettings.TabIndex = 0;
            this.lblProfileSettings.Text = "Paramètres de l\'administrateur";
            // 
            // tabInterface
            // 
            this.tabInterface.BackColor = System.Drawing.Color.White;
            this.tabInterface.Controls.Add(this.pnlThemePreview);
            this.tabInterface.Controls.Add(this.lblPreview);
            this.tabInterface.Controls.Add(this.btnSaveInterface);
            this.tabInterface.Controls.Add(this.cmbLangue);
            this.tabInterface.Controls.Add(this.lblLangue);
            this.tabInterface.Controls.Add(this.cmbTaillePolice);
            this.tabInterface.Controls.Add(this.lblTaillePolice);
            this.tabInterface.Controls.Add(this.pnlTheme);
            this.tabInterface.Controls.Add(this.lblTheme);
            this.tabInterface.Controls.Add(this.lblInterfaceSettings);
            this.tabInterface.Location = new System.Drawing.Point(4, 32);
            this.tabInterface.Name = "tabInterface";
            this.tabInterface.Padding = new System.Windows.Forms.Padding(3);
            this.tabInterface.Size = new System.Drawing.Size(885, 448);
            this.tabInterface.TabIndex = 1;
            this.tabInterface.Text = "Interface";
            // 
            // pnlThemePreview
            // 
            this.pnlThemePreview.BackColor = System.Drawing.Color.White;
            this.pnlThemePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThemePreview.Controls.Add(this.lblPreviewText);
            this.pnlThemePreview.Location = new System.Drawing.Point(467, 80);
            this.pnlThemePreview.Name = "pnlThemePreview";
            this.pnlThemePreview.Size = new System.Drawing.Size(400, 200);
            this.pnlThemePreview.TabIndex = 10;
            // 
            // lblPreviewText
            // 
            this.lblPreviewText.AutoSize = true;
            this.lblPreviewText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblPreviewText.Location = new System.Drawing.Point(33, 88);
            this.lblPreviewText.Name = "lblPreviewText";
            this.lblPreviewText.Size = new System.Drawing.Size(347, 28);
            this.lblPreviewText.TabIndex = 0;
            this.lblPreviewText.Text = "Aperçu de l\'apparence de l\'application";
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblPreview.Location = new System.Drawing.Point(467, 53);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(73, 23);
            this.lblPreview.TabIndex = 9;
            this.lblPreview.Text = "Aperçu :";
            // 
            // btnSaveInterface
            // 
            this.btnSaveInterface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSaveInterface.FlatAppearance.BorderSize = 0;
            this.btnSaveInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveInterface.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveInterface.ForeColor = System.Drawing.Color.White;
            this.btnSaveInterface.Location = new System.Drawing.Point(45, 300);
            this.btnSaveInterface.Name = "btnSaveInterface";
            this.btnSaveInterface.Size = new System.Drawing.Size(160, 35);
            this.btnSaveInterface.TabIndex = 8;
            this.btnSaveInterface.Text = "&Enregistrer";
            this.btnSaveInterface.UseVisualStyleBackColor = false;
            this.btnSaveInterface.Click += new System.EventHandler(this.btnSaveInterface_Click);
            // 
            // cmbLangue
            // 
            this.cmbLangue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLangue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLangue.FormattingEnabled = true;
            this.cmbLangue.Location = new System.Drawing.Point(45, 245);
            this.cmbLangue.Name = "cmbLangue";
            this.cmbLangue.Size = new System.Drawing.Size(200, 31);
            this.cmbLangue.TabIndex = 7;
            // 
            // lblLangue
            // 
            this.lblLangue.AutoSize = true;
            this.lblLangue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLangue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblLangue.Location = new System.Drawing.Point(45, 217);
            this.lblLangue.Name = "lblLangue";
            this.lblLangue.Size = new System.Drawing.Size(75, 23);
            this.lblLangue.TabIndex = 6;
            this.lblLangue.Text = "&Langue :";
            // 
            // cmbTaillePolice
            // 
            this.cmbTaillePolice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaillePolice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaillePolice.FormattingEnabled = true;
            this.cmbTaillePolice.Location = new System.Drawing.Point(45, 175);
            this.cmbTaillePolice.Name = "cmbTaillePolice";
            this.cmbTaillePolice.Size = new System.Drawing.Size(200, 31);
            this.cmbTaillePolice.TabIndex = 5;
            // 
            // lblTaillePolice
            // 
            this.lblTaillePolice.AutoSize = true;
            this.lblTaillePolice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaillePolice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblTaillePolice.Location = new System.Drawing.Point(45, 147);
            this.lblTaillePolice.Name = "lblTaillePolice";
            this.lblTaillePolice.Size = new System.Drawing.Size(130, 23);
            this.lblTaillePolice.TabIndex = 4;
            this.lblTaillePolice.Text = "Taille de &police :";
            this.lblTaillePolice.Click += new System.EventHandler(this.lblTaillePolice_Click);
            // 
            // pnlTheme
            // 
            this.pnlTheme.Controls.Add(this.rbThemeSombre);
            this.pnlTheme.Controls.Add(this.rbThemeClair);
            this.pnlTheme.Location = new System.Drawing.Point(45, 80);
            this.pnlTheme.Name = "pnlTheme";
            this.pnlTheme.Size = new System.Drawing.Size(300, 50);
            this.pnlTheme.TabIndex = 3;
            // 
            // rbThemeSombre
            // 
            this.rbThemeSombre.AutoSize = true;
            this.rbThemeSombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThemeSombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.rbThemeSombre.Location = new System.Drawing.Point(145, 12);
            this.rbThemeSombre.Name = "rbThemeSombre";
            this.rbThemeSombre.Size = new System.Drawing.Size(90, 27);
            this.rbThemeSombre.TabIndex = 1;
            this.rbThemeSombre.TabStop = true;
            this.rbThemeSombre.Text = "&Sombre";
            this.rbThemeSombre.UseVisualStyleBackColor = true;
            this.rbThemeSombre.CheckedChanged += new System.EventHandler(this.rbThemeSombre_CheckedChanged);
            // 
            // rbThemeClair
            // 
            this.rbThemeClair.AutoSize = true;
            this.rbThemeClair.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThemeClair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.rbThemeClair.Location = new System.Drawing.Point(3, 12);
            this.rbThemeClair.Name = "rbThemeClair";
            this.rbThemeClair.Size = new System.Drawing.Size(65, 27);
            this.rbThemeClair.TabIndex = 0;
            this.rbThemeClair.TabStop = true;
            this.rbThemeClair.Text = "&Clair";
            this.rbThemeClair.UseVisualStyleBackColor = true;
            this.rbThemeClair.CheckedChanged += new System.EventHandler(this.rbThemeClair_CheckedChanged);
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblTheme.Location = new System.Drawing.Point(45, 53);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(71, 23);
            this.lblTheme.TabIndex = 2;
            this.lblTheme.Text = "Thème :";
            // 
            // lblInterfaceSettings
            // 
            this.lblInterfaceSettings.AutoSize = true;
            this.lblInterfaceSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterfaceSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblInterfaceSettings.Location = new System.Drawing.Point(15, 15);
            this.lblInterfaceSettings.Name = "lblInterfaceSettings";
            this.lblInterfaceSettings.Size = new System.Drawing.Size(230, 28);
            this.lblInterfaceSettings.TabIndex = 1;
            this.lblInterfaceSettings.Text = "Paramètres d\'apparence";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblTitle.Location = new System.Drawing.Point(23, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(381, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Configuration de votre application";
            // 
            // frmParametre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 661);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.mnsMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mnsMain;
            this.MinimumSize = new System.Drawing.Size(957, 708);
            this.Name = "frmParametre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaveEat - Paramètres";
            this.Load += new System.EventHandler(this.frmParametre_Load);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            this.tabInterface.ResumeLayout(false);
            this.tabInterface.PerformLayout();
            this.pnlThemePreview.ResumeLayout(false);
            this.pnlThemePreview.PerformLayout();
            this.pnlTheme.ResumeLayout(false);
            this.pnlTheme.PerformLayout();
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
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblCurrentSection;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblProfileSettings;
        private System.Windows.Forms.TabPage tabInterface;
        private System.Windows.Forms.Panel pnlThemePreview;
        private System.Windows.Forms.Label lblPreviewText;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnSaveInterface;
        private System.Windows.Forms.ComboBox cmbLangue;
        private System.Windows.Forms.Label lblLangue;
        private System.Windows.Forms.ComboBox cmbTaillePolice;
        private System.Windows.Forms.Label lblTaillePolice;
        private System.Windows.Forms.Panel pnlTheme;
        private System.Windows.Forms.RadioButton rbThemeSombre;
        private System.Windows.Forms.RadioButton rbThemeClair;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Label lblInterfaceSettings;
        private System.Windows.Forms.Label lblTitle;
    }
}