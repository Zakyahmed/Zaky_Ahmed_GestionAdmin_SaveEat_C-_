using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using GestionAdmin_SaveEat_C_.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestionAdmin_SaveEat_C_
{
    public partial class frmAddEditUser : Form
    {
        private Utilisateur userToEdit = null;
        private bool isEditMode = false;
        private frmUsers parentForm;

        public frmAddEditUser(frmUsers parent, Utilisateur user = null)
        {
            InitializeComponent();

            // Vérifier que le formulaire parent n'est pas nul
            if (parent == null)
                throw new ArgumentNullException("Le formulaire parent ne peut pas être nul");

            parentForm = parent;

            // Déterminer si nous sommes en mode édition ou ajout
            if (user != null)
            {
                userToEdit = user;
                isEditMode = true;
            }
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialiser les contrôles du formulaire
                InitializeComboBoxes();

                // Ajouter l'événement pour gérer l'activation du type selon le rôle
                cmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;

                if (isEditMode)
                {
                    ConfigureEditMode();
                }
                else
                {
                    ConfigureAddMode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation du formulaire: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem != null)
            {
                string selectedRole = cmbRole.SelectedItem.ToString();

                if (selectedRole == "admin")
                {
                    // Désactiver le type pour admin
                    cmbStatus.Enabled = false;
                    cmbStatus.SelectedIndex = -1; // Aucune sélection
                }
                else if (selectedRole == "utilisateur")
                {
                    // Activer le type pour utilisateur
                    cmbStatus.Enabled = true;

                    // Sélectionner restaurant par défaut si aucune sélection
                    if (cmbStatus.SelectedIndex == -1)
                    {
                        cmbStatus.SelectedIndex = 0; // restaurant
                    }
                }
            }
        }

        private void InitializeComboBoxes()
        {
            try
            {
                // Vider les listes pour éviter les doublons
                cmbRole.Items.Clear();
                cmbStatus.Items.Clear();

                // Remplir les rôles
                cmbRole.Items.Add("utilisateur");
                cmbRole.Items.Add("admin");

                // Remplir les types (seulement restaurant et association)
                cmbStatus.Items.Add("restaurant");
                cmbStatus.Items.Add("association");

                // Définir le style pour empêcher l'édition manuelle
                cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'initialisation des listes déroulantes: {ex.Message}");
            }
        }

        private void ConfigureEditMode()
        {
            try
            {
                // Mode édition - configurer le formulaire et remplir les champs
                this.Text = "Modifier un utilisateur";
                lblFormTitle.Text = "Modifier un utilisateur";
                btnSubmit.Text = "Mettre à jour";

                // Remplir les champs avec les données de l'utilisateur
                txtNom.Text = userToEdit.Nom;
                txtPrenom.Text = userToEdit.Prenom;
                txtEmail.Text = userToEdit.Email;
                txtUsername.Text = userToEdit.Username;

                // Gérer le rôle et le type
                if (!string.IsNullOrEmpty(userToEdit.RolePrincipal))
                {
                    if (userToEdit.RolePrincipal == "admin")
                    {
                        cmbRole.SelectedIndex = 1; // admin
                        cmbStatus.Enabled = false;
                        cmbStatus.SelectedIndex = -1;
                    }
                    else
                    {
                        cmbRole.SelectedIndex = 0; // utilisateur
                        cmbStatus.Enabled = true;

                        // Sélectionner le type approprié
                        if (userToEdit.Type == "restaurant")
                        {
                            cmbStatus.SelectedIndex = 0;
                        }
                        else if (userToEdit.Type == "association")
                        {
                            cmbStatus.SelectedIndex = 1;
                        }
                    }
                }

                // Gérer le mot de passe différemment en mode édition
                txtPassword.PasswordChar = '\0';
                txtPassword.Text = "••••••••";
                txtPassword.Enabled = false;
                lblPassword.Text = "Mot de passe: (inchangé)";
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de la configuration du mode édition: {ex.Message}");
            }
        }

        private void ConfigureAddMode()
        {
            try
            {
                // Mode ajout - configurer le formulaire avec les valeurs par défaut
                this.Text = "Ajouter un utilisateur";
                lblFormTitle.Text = "Ajouter un utilisateur";
                btnSubmit.Text = "Ajouter";

                // Valeurs par défaut
                cmbRole.SelectedIndex = 0; // "utilisateur" par défaut
                cmbStatus.SelectedIndex = 0; // "restaurant" par défaut
                cmbStatus.Enabled = true; // Actif par défaut

                // S'assurer que le champ de mot de passe est actif
                txtPassword.PasswordChar = '●';
                txtPassword.Text = "";
                txtPassword.Enabled = true;
                lblPassword.Text = "Mot de passe:";
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de la configuration du mode ajout: {ex.Message}");
            }
        }
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Valider les champs obligatoires
                if (!ValidateFields())
                    return;

                // Afficher un indicateur de chargement
                Cursor.Current = Cursors.WaitCursor;
                btnSubmit.Enabled = false;
                btnCancel.Enabled = false;

                bool success = false;

                if (isEditMode)
                {
                    // Mettre à jour l'utilisateur existant
                    success = await UpdateExistingUserAsync();
                }
                else
                {
                    // Créer un nouvel utilisateur
                    success = await CreateNewUserAsync();
                }

                Cursor.Current = Cursors.Default;
                btnSubmit.Enabled = true;
                btnCancel.Enabled = true;

                if (success)
                {
                    // Fermer le formulaire avec succès
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                btnSubmit.Enabled = true;
                btnCancel.Enabled = true;
                MessageBox.Show($"Erreur lors de l'enregistrement: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields()
        {
            try
            {
                // Vérifier que les champs obligatoires sont remplis
                if (string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("Le nom est obligatoire.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNom.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtPrenom.Text))
                {
                    MessageBox.Show("Le prénom est obligatoire.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrenom.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("L'email est obligatoire.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }

                // Valider le format de l'email
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Veuillez entrer une adresse email valide.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }

                // En mode ajout, le mot de passe est obligatoire
                if (!isEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Le mot de passe est obligatoire.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                // Vérifier que le rôle est sélectionné
                if (cmbRole.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez sélectionner un rôle.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRole.Focus();
                    return false;
                }

                // Vérifier le type SEULEMENT si le rôle n'est pas "admin"
                if (cmbRole.SelectedItem != null && cmbRole.SelectedItem.ToString() != "admin")
                {
                    if (cmbStatus.SelectedIndex == -1)
                    {
                        MessageBox.Show("Veuillez sélectionner un type.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbStatus.Focus();
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de la validation des champs: {ex.Message}");
            }
        }
        private async Task<bool> CreateNewUserAsync()
        {
            try
            {
                // Vérifier que le rôle est sélectionné
                if (cmbRole.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner un rôle.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string selectedRole = cmbRole.SelectedItem.ToString();
                string userType = "";

                // Déterminer le type basé sur le rôle sélectionné
                if (selectedRole == "admin")
                {
                    userType = "admin";
                    // Pas besoin de vérifier le type pour admin
                }
                else if (selectedRole == "utilisateur")
                {
                    // Pour un utilisateur normal, on doit avoir un type sélectionné
                    if (cmbStatus.SelectedItem == null)
                    {
                        MessageBox.Show("Veuillez sélectionner un type d'utilisateur (restaurant ou association).",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    userType = cmbStatus.SelectedItem.ToString().ToLower().Trim();
                }

                // Vérifier que le type est valide
                var validTypes = new[] { "admin", "restaurant", "association" };
                if (!validTypes.Contains(userType))
                {
                    MessageBox.Show($"Type d'utilisateur invalide : {userType}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Créer un objet avec les données du nouvel utilisateur
                var newUser = new
                {
                    nom = txtNom.Text.Trim(),
                    prenom = txtPrenom.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    username = txtUsername.Text.Trim(),
                    password = txtPassword.Text,
                    type = userType // L'API utilise le type pour assigner le rôle
                };

                // Log pour debug
                Console.WriteLine($"Création d'un nouvel utilisateur : {newUser.email}");
                Console.WriteLine($"Rôle sélectionné : '{selectedRole}'");
                Console.WriteLine($"Type envoyé : '{newUser.type}'");

                // Créer via l'API
                var createdUser = await ApiServiceManager.Instance.CreateUserAsync(newUser);

                if (createdUser != null)
                {
                    MessageBox.Show($"Utilisateur créé avec succès.\nRôle : {selectedRole}\nType : {userType}",
                        "SaveEat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("La création de l'utilisateur a échoué. Vérifiez les logs.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création de l'utilisateur: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Erreur détaillée : {ex.ToString()}");
                return false;
            }
        }
        private async Task<bool> UpdateExistingUserAsync()
        {
            try
            {
                // Mettre à jour les propriétés de l'utilisateur existant
                userToEdit.Nom = txtNom.Text.Trim();
                userToEdit.Prenom = txtPrenom.Text.Trim();
                userToEdit.Email = txtEmail.Text.Trim();
                userToEdit.Username = txtUsername.Text.Trim();

                // Vérifier que le rôle est sélectionné
                if (cmbRole.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner un rôle.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string selectedRole = cmbRole.SelectedItem.ToString();
                string userType = "";

                // Déterminer le type basé sur le rôle sélectionné
                if (selectedRole == "admin")
                {
                    selectedRole = "admin";
                    userType = "admin";
                    // Pas besoin de vérifier le type pour admin
                }
                else if (selectedRole == "utilisateur")
                {
                    // Pour un utilisateur normal, on doit avoir un type sélectionné
                    if (cmbStatus.SelectedItem == null)
                    {
                        MessageBox.Show("Veuillez sélectionner un type d'utilisateur (restaurant ou association).",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    userType = cmbStatus.SelectedItem.ToString().ToLower().Trim();
                    selectedRole = userType; // Le rôle réel est restaurant ou association
                }

                // Log pour debug
                Console.WriteLine($"Mise à jour utilisateur - Rôle sélectionné : {selectedRole}");
                Console.WriteLine($"Type : {userType}");

                // Mettre à jour le rôle
                userToEdit.Roles = new List<Role>
        {
            new Role { Name = selectedRole }
        };

                // Mettre à jour le type
                userToEdit.Type = userType;

                // Mettre à jour l'utilisateur dans la liste principale via l'API
                bool success = await parentForm.UpdateUserAsync(userToEdit);

                if (success)
                {
                    MessageBox.Show("Utilisateur mis à jour avec succès.",
                        "SaveEat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La mise à jour a échoué.",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de la mise à jour de l'utilisateur: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Annuler l'opération et fermer le formulaire
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la fermeture du formulaire: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            // Méthode vide, générée automatiquement par le concepteur
        }
    }
}