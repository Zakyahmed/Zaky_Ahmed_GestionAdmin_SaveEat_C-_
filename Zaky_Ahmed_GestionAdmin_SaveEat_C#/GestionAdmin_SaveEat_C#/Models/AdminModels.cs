using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GestionAdmin_SaveEat_C_.Models
{
    // Convertisseur personnalisé pour gérer les rôles qui peuvent être des strings ou des objets
    public class RoleConverter : JsonConverter<List<Role>>
    {
        public override List<Role> ReadJson(JsonReader reader, Type objectType, List<Role> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var roles = new List<Role>();
            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Array)
            {
                foreach (var item in token)
                {
                    if (item.Type == JTokenType.String)
                    {
                        // Si c'est une string, créer un objet Role
                        roles.Add(new Role { Name = item.ToString() });
                    }
                    else if (item.Type == JTokenType.Object)
                    {
                        // Si c'est déjà un objet, le désérialiser normalement
                        roles.Add(item.ToObject<Role>());
                    }
                }
            }

            return roles;
        }

        public override void WriteJson(JsonWriter writer, List<Role> value, JsonSerializer serializer)
        {
            // Pour l'écriture, on peut garder le comportement par défaut
            serializer.Serialize(writer, value);
        }
    }

    public class AdminAuthResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("utilisateur")]  // Changé de "user" à "utilisateur"
        public AuthUtilisateur Utilisateur { get; set; }

        // Propriété calculée car Laravel ne renvoie pas de champ "success"
        public bool Success => !string.IsNullOrEmpty(Token);

        public string Message { get; set; }
    }

    // Classe spécifique pour la réponse d'authentification
    public class AuthUtilisateur
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nom")]
        public string Nom { get; set; }

        [JsonProperty("prenom")]
        public string Prenom { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }  // Laravel renvoie directement des strings
    }

    public class Utilisateur
    {
        [JsonProperty("util_id")]
        public int Id { get; set; }

        [JsonProperty("util_nom")]
        public string Nom { get; set; }

        [JsonProperty("util_prenom")]
        public string Prenom { get; set; }

        [JsonProperty("util_email")]
        public string Email { get; set; }

        [JsonProperty("util_username")]
        public string Username { get; set; }

        [JsonProperty("util_telephone")]
        public string Telephone { get; set; }

        [JsonProperty("util_date_inscription")]
        public DateTime DateInscription { get; set; }

        [JsonProperty("util_derniere_connexion")]
        public DateTime? DerniereConnexion { get; set; }

        [JsonProperty("util_image_profil")]
        public string ImageProfil { get; set; }

        [JsonProperty("roles")]
        [JsonConverter(typeof(RoleConverter))]
        public List<Role> Roles { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        // Ajouter cette propriété
        [JsonProperty("actif")]
        public bool Actif { get; set; } = true; // Par défaut, l'utilisateur est actif

        // Propriété calculée pour obtenir le rôle principal
        public string RolePrincipal => Roles?.Count > 0 ? Roles[0].Name : "utilisateur";
    }

    public class Role
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    // Classe Restaurant
    public class Restaurant
    {
        [JsonProperty("rest_id")]
        public int Id { get; set; }

        [JsonProperty("rest_nom")]
        public string Nom { get; set; }

        [JsonProperty("rest_adresse")]
        public string Adresse { get; set; }

        [JsonProperty("rest_npa")]
        public string NPA { get; set; }

        [JsonProperty("rest_localite")]
        public string Localite { get; set; }

        [JsonProperty("rest_canton")]
        public string Canton { get; set; }

        [JsonProperty("rest_latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("rest_longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("rest_ide")]
        public string IDE { get; set; }

        [JsonProperty("rest_description")]
        public string Description { get; set; }

        [JsonProperty("rest_site_web")]
        public string SiteWeb { get; set; }

        [JsonProperty("rest_valide")]
        public bool RestValide { get; set; }

        [JsonProperty("rest_util_id")]
        public int UtilisateurId { get; set; }

        [JsonProperty("utilisateur")]
        public Utilisateur Utilisateur { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    // Classe Association
    public class Association
    {
        [JsonProperty("asso_id")]
        public int Id { get; set; }

        [JsonProperty("asso_nom")]
        public string Nom { get; set; }

        [JsonProperty("asso_adresse")]
        public string Adresse { get; set; }

        [JsonProperty("asso_npa")]
        public string NPA { get; set; }

        [JsonProperty("asso_localite")]
        public string Localite { get; set; }

        [JsonProperty("asso_canton")]
        public string Canton { get; set; }

        [JsonProperty("asso_latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("asso_longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("asso_ide")]
        public string IDE { get; set; }

        [JsonProperty("asso_zewo")]
        public string ZEWO { get; set; }

        [JsonProperty("asso_description")]
        public string Description { get; set; }

        [JsonProperty("asso_site_web")]
        public string SiteWeb { get; set; }

        [JsonProperty("asso_valide")]
        public bool AssoValide { get; set; }

        [JsonProperty("asso_util_id")]
        public int UtilisateurId { get; set; }

        [JsonProperty("utilisateur")]
        public Utilisateur Utilisateur { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    // Classe Justificatif
    public class Justificatif
    {
        [JsonProperty("just_id")]
        public int Id { get; set; }

        [JsonProperty("just_nom_fichier")]
        public string NomFichier { get; set; }

        [JsonProperty("just_chemin_fichier")]
        public string CheminFichier { get; set; }

        [JsonProperty("just_date_envoi")]
        public DateTime DateEnvoi { get; set; }

        [JsonProperty("just_statut")]
        public string Statut { get; set; }

        [JsonProperty("just_commentaire")]
        public string Commentaire { get; set; }

        [JsonProperty("just_util_id")]
        public int UtilisateurId { get; set; }

        [JsonProperty("utilisateur")]
        public Utilisateur Utilisateur { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    // Classe Invendu
    public class Invendu
    {
        [JsonProperty("inv_id")]
        public int Id { get; set; }

        [JsonProperty("inv_titre")]
        public string Titre { get; set; }

        [JsonProperty("inv_description")]
        public string Description { get; set; }

        [JsonProperty("inv_quantite")]
        public int Quantite { get; set; }

        [JsonProperty("inv_unite")]
        public string Unite { get; set; }

        [JsonProperty("inv_date_disponibilite")]
        public DateTime DateDisponibilite { get; set; }

        [JsonProperty("inv_date_limite")]
        public DateTime DateLimite { get; set; }

        [JsonProperty("inv_statut")]
        public string Statut { get; set; }

        [JsonProperty("inv_urgent")]
        public bool Urgent { get; set; }

        [JsonProperty("inv_allergenes")]
        public string Allergenes { get; set; }

        [JsonProperty("inv_temperature")]
        public string Temperature { get; set; }

        [JsonProperty("inv_rest_id")]
        public int RestaurantId { get; set; }

        [JsonProperty("restaurant")]
        public Restaurant Restaurant { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    // Classe Reservation
    public class Reservation
    {
        [JsonProperty("res_id")]
        public int Id { get; set; }

        [JsonProperty("res_date")]
        public DateTime DateReservation { get; set; }

        [JsonProperty("res_date_collecte")]
        public DateTime DateCollecte { get; set; }

        [JsonProperty("res_statut")]
        public string Statut { get; set; }

        [JsonProperty("res_commentaire")]
        public string Commentaire { get; set; }

        [JsonProperty("res_inv_id")]
        public int InvenduId { get; set; }

        [JsonProperty("res_asso_id")]
        public int AssociationId { get; set; }

        [JsonProperty("invendu")]
        public Invendu Invendu { get; set; }

        [JsonProperty("association")]
        public Association Association { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    // Classes pour les statistiques
    public class UserStats
    {
        [JsonProperty("total_restaurants")]
        public int TotalRestaurants { get; set; }

        [JsonProperty("total_associations")]
        public int TotalAssociations { get; set; }

        [JsonProperty("pending_validations")]
        public int PendingValidations { get; set; }

        [JsonProperty("active_users")]
        public int ActiveUsers { get; set; }
    }

    public class InvendusStats
    {
        [JsonProperty("total_quantity")]
        public int TotalQuantity { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("saved_this_month")]
        public int SavedThisMonth { get; set; }
    }

    public class ReservationsStats
    {
        [JsonProperty("total_reservations")]
        public int TotalReservations { get; set; }

        [JsonProperty("confirmed_reservations")]
        public int ConfirmedReservations { get; set; }

        [JsonProperty("pending_reservations")]
        public int PendingReservations { get; set; }
    }

    public class ActivityLog
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class ValidationRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nom")]
        public string Nom { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("adresse")]
        public string Adresse { get; set; }

        [JsonProperty("localite")]
        public string Localite { get; set; }

        [JsonProperty("canton")]
        public string Canton { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("date_demande")]
        public DateTime DateDemande { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("justificatif_path")]
        public string JustificatifPath { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class DashboardStats
    {
        [JsonProperty("total_restaurants")]
        public int TotalRestaurants { get; set; }

        [JsonProperty("total_associations")]
        public int TotalAssociations { get; set; }

        [JsonProperty("total_food_saved")]
        public int TotalFoodSaved { get; set; }

        [JsonProperty("satisfaction_rating")]
        public double SatisfactionRating { get; set; }

        [JsonProperty("recent_activities")]
        public List<ActivityLog> RecentActivities { get; set; }

        [JsonProperty("validation_pending")]
        public int ValidationPending { get; set; }
    }
}