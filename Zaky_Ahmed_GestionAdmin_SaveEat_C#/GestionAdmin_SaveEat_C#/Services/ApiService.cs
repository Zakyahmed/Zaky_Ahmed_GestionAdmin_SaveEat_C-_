using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GestionAdmin_SaveEat_C_.Models;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace GestionAdmin_SaveEat_C_.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private string _authToken;

        public ApiService(string baseUrl = "http://localhost:8888/api")
        {
            _baseUrl = baseUrl;
            _client = new HttpClient();

            // S'assurer que l'URL se termine par /
            if (!_baseUrl.EndsWith("/"))
            {
                _baseUrl += "/";
            }

            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Configuration du token d'authentification
        public void SetAuthToken(string token)
        {
            _authToken = token;
            if (string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Authorization = null;
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            }
        }

        // Vérifier si l'utilisateur est authentifié
        public bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(_authToken);
        }

        #region Méthodes génériques pour les appels API

        // Méthode générique pour les requêtes GET
        public async Task<T> GetAsync<T>(string endpoint) where T : class
        {
            // Retirer le slash au début si présent
            if (endpoint.StartsWith("/"))
            {
                endpoint = endpoint.Substring(1);
            }

            // Log pour debug
            Console.WriteLine($"GET Request to: {_client.BaseAddress}{endpoint}");
            Console.WriteLine($"Auth header: {_client.DefaultRequestHeaders.Authorization}");

            // Vérifier l'authentification si nécessaire
            if (endpoint != "auth/login" && !IsAuthenticated())
            {
                throw new Exception("Utilisateur non authentifié.");
            }

            // Effectuer la requête
            var response = await _client.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Content: {content}"); // Pour debug

            if (response.IsSuccessStatusCode)
            {
                // Si T est une liste et que le contenu est un objet JSON
                if (typeof(T).IsGenericType &&
                    typeof(T).GetGenericTypeDefinition() == typeof(List<>) &&
                    content.TrimStart().StartsWith("{"))
                {
                    try
                    {
                        var jObject = JObject.Parse(content);

                        // IMPORTANT : Gérer la pagination Laravel
                        // Laravel retourne un objet avec "data", "current_page", "per_page", etc.
                        if (jObject["data"] != null && jObject["data"].Type == JTokenType.Array)
                        {
                            return jObject["data"].ToObject<T>();
                        }

                        // Gérer d'autres formats de réponse
                        if (jObject["value"] != null && jObject["value"].Type == JTokenType.Array)
                        {
                            return jObject["value"].ToObject<T>();
                        }

                        // Chercher des propriétés qui pourraient contenir le tableau
                        var possibleProperties = new[] {
                    "data", "items", "results", "users", "utilisateurs",
                    "restaurants", "associations", "justificatifs"
                };

                        foreach (var prop in possibleProperties)
                        {
                            if (jObject[prop] != null && jObject[prop].Type == JTokenType.Array)
                            {
                                return jObject[prop].ToObject<T>();
                            }
                        }

                        // Si aucun tableau n'est trouvé dans les propriétés connues,
                        // chercher la première propriété qui est un tableau
                        foreach (var property in jObject.Properties())
                        {
                            if (property.Value.Type == JTokenType.Array)
                            {
                                return property.Value.ToObject<T>();
                            }
                        }

                        // En dernier recours, essayer de deserializer directement
                        // Cela pourrait échouer si ce n'est pas le bon format
                        Console.WriteLine("Attention : Impossible de trouver un tableau dans la réponse JSON");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur parsing JSON: {ex.Message}");
                        Console.WriteLine($"Contenu JSON: {content}");
                    }
                }

                return JsonConvert.DeserializeObject<T>(content);
            }

            throw new Exception($"Erreur API [{response.StatusCode}]: {content}");
        }

        public async Task<T> PostAsync<T>(string endpoint, object data) where T : class
        {
            // Retirer le slash au début si présent
            if (endpoint.StartsWith("/"))
            {
                endpoint = endpoint.Substring(1);
            }

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine($"POST Request to: {_client.BaseAddress}{endpoint}");
            Console.WriteLine($"Auth header: {_client.DefaultRequestHeaders.Authorization}");
            Console.WriteLine($"Data: {json}");

            // Vérifier l'authentification si nécessaire
            if (endpoint != "auth/login" && endpoint != "auth/register" && !IsAuthenticated())
            {
                throw new Exception("Utilisateur non authentifié.");
            }

            var response = await _client.PostAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Content: {responseContent}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(responseContent);
            }

            throw new Exception($"Erreur API [{response.StatusCode}]: {responseContent}");
        }

        public async Task<T> PutAsync<T>(string endpoint, object data) where T : class
        {
            // Retirer le slash au début si présent
            if (endpoint.StartsWith("/"))
            {
                endpoint = endpoint.Substring(1);
            }

            // Vérifier l'authentification
            if (!IsAuthenticated())
            {
                throw new Exception("Utilisateur non authentifié.");
            }

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine($"PUT Request to: {_client.BaseAddress}{endpoint}");
            Console.WriteLine($"Auth header: {_client.DefaultRequestHeaders.Authorization}");
            Console.WriteLine($"Data: {json}");

            var response = await _client.PutAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Response Status: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(responseContent);
            }

            throw new Exception($"Erreur API [{response.StatusCode}]: {responseContent}");
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            // Retirer le slash au début si présent
            if (endpoint.StartsWith("/"))
            {
                endpoint = endpoint.Substring(1);
            }

            // Vérifier l'authentification
            if (!IsAuthenticated())
            {
                throw new Exception("Utilisateur non authentifié.");
            }

            Console.WriteLine($"DELETE Request to: {_client.BaseAddress}{endpoint}");
            Console.WriteLine($"Auth header: {_client.DefaultRequestHeaders.Authorization}");

            var response = await _client.DeleteAsync(endpoint);

            Console.WriteLine($"Response Status: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erreur API [{response.StatusCode}]: {errorContent}");
        }

        #endregion

        #region Authentification

        // Authentification Admin
        public async Task<AdminAuthResponse> AdminLoginAsync(string email, string password)
        {
            var loginData = new { email = email, password = password };

            var authResponse = await PostAsync<AdminAuthResponse>("/auth/login", loginData);

            if (authResponse != null && authResponse.Success)
            {
                // Configure le token pour les futures requêtes
                if (!string.IsNullOrEmpty(authResponse.Token))
                {
                    Console.WriteLine($"Token reçu: {authResponse.Token}");
                    SetAuthToken(authResponse.Token);
                    Console.WriteLine($"Token configuré dans l'header: {_client.DefaultRequestHeaders.Authorization}");
                }

                return authResponse;
            }

            throw new Exception(authResponse?.Message ?? "Erreur de connexion");
        }

        // Déconnexion Admin
        public async Task<bool> AdminLogoutAsync()
        {
            // Si l'utilisateur n'est pas authentifié, considérer qu'il est déjà déconnecté
            if (string.IsNullOrEmpty(_authToken))
            {
                SetAuthToken(null);
                return true;
            }

            // Utiliser PostAsync pour gérer le slash automatiquement
            try
            {
                await PostAsync<object>("auth/logout", null);
                SetAuthToken(null);
                return true;
            }
            catch
            {
                // En cas d'erreur, on essaie quand même de nettoyer le token
                SetAuthToken(null);
                throw new Exception("Erreur lors de la déconnexion");
            }
        }

        // Récupération des informations de l'utilisateur connecté
        public async Task<Utilisateur> GetCurrentUserAsync()
        {
            return await GetAsync<Utilisateur>("/auth/profile");
        }

        #endregion

        #region Gestion des utilisateurs

        // Récupération de la liste des utilisateurs
        public async Task<List<Utilisateur>> GetAllUsersAsync()
        {
            return await GetAsync<List<Utilisateur>>("/admin/users");
        }

        // Récupération d'un utilisateur par ID
        public async Task<Utilisateur> GetUserByIdAsync(int id)
        {
            return await GetAsync<Utilisateur>($"/admin/users/{id}");
        }

        // Modification du rôle d'un utilisateur
        public async Task<Utilisateur> UpdateUserRoleAsync(int id, string role)
        {
            // S'assurer que le rôle est en minuscules
            role = role?.ToLower()?.Trim();

            Console.WriteLine($"Tentative de mise à jour du rôle - ID: {id}, Rôle: {role}");

            var roleData = new
            {
                role = role
                // Pas de champ actif
            };

            Console.WriteLine($"Données envoyées: {JsonConvert.SerializeObject(roleData)}");

            return await PutAsync<Utilisateur>($"/admin/users/{id}/role", roleData);
        }

        // Modification du statut d'un utilisateur (désactivé)
        public Task<Utilisateur> UpdateUserStatusAsync(int id, string status)
        {
            // Cette méthode est désactivée car nous n'utilisons pas de statut actif/inactif
            throw new NotImplementedException("La gestion du statut utilisateur est désactivée");
        }

        // Mise à jour du profil utilisateur
        public async Task<Utilisateur> UpdateProfileAsync(Utilisateur user)
        {
            // Créer un objet avec seulement les champs nécessaires
            var updateData = new
            {
                util_nom = user.Nom,
                util_prenom = user.Prenom,
                util_email = user.Email,
                util_username = user.Username,
                util_telephone = user.Telephone,
                type = user.Type
                // Pas de champ actif
            };

            return await PutAsync<Utilisateur>("/auth/profile", updateData);
        }

        // Changement de mot de passe
        public async Task<bool> ChangePasswordAsync(string currentPassword, string newPassword, string confirmPassword)
        {
            var passwordData = new
            {
                current_password = currentPassword,
                password = newPassword,
                password_confirmation = confirmPassword
            };

            try
            {
                await PostAsync<object>("/auth/password/change", passwordData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Suppression d'un utilisateur
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await DeleteAsync($"/admin/users/{id}");
        }

        // Création d'un utilisateur
        public async Task<Utilisateur> CreateUserAsync(object userData)
        {
            return await PostAsync<Utilisateur>("/admin/users", userData);
        }

        // Mise à jour complète d'un utilisateur
        public async Task<Utilisateur> UpdateUserAsync(int id, object userData)
        {
            return await PutAsync<Utilisateur>($"/admin/users/{id}/update", userData);
        }

        #endregion

        #region Gestion des restaurants et associations

        // Récupération des restaurants
        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return await GetAsync<List<Restaurant>>("/admin/restaurants");
        }

        // Récupération des associations
        public async Task<List<Association>> GetAllAssociationsAsync()
        {
            return await GetAsync<List<Association>>("/admin/associations");
        }

        // Validation d'un restaurant
        public async Task<Restaurant> ValidateRestaurantAsync(int id, bool isValid)
        {
            var validationData = new
            {
                status = isValid ? "validé" : "rejeté"
                // Pas de champ actif
            };
            return await PutAsync<Restaurant>($"/admin/restaurants/{id}/validate", validationData);
        }

        // Validation d'une association
        public async Task<Association> ValidateAssociationAsync(int id, bool isValid)
        {
            var validationData = new
            {
                status = isValid ? "validé" : "rejeté"
                // Pas de champ actif
            };
            return await PutAsync<Association>($"/admin/associations/{id}/validate", validationData);
        }

        #endregion

        #region Gestion des justificatifs

        // Récupération des justificatifs
        public async Task<List<Justificatif>> GetAllJustificatifsAsync()
        {
            return await GetAsync<List<Justificatif>>("/admin/justificatifs?no_pagination=1");
        }

        // Validation d'un justificatif
        public async Task<Justificatif> ValidateJustificatifAsync(int id, bool isValid)
        {
            var validationData = new { status = isValid ? "validé" : "rejeté" };
            return await PutAsync<Justificatif>($"/admin/justificatifs/{id}/validate", validationData);
        }

        #endregion

        #region Statistiques

        // Récupération des statistiques du tableau de bord
        public async Task<DashboardStats> GetDashboardStatsAsync()
        {
            // Récupérer les statistiques depuis les endpoints spécifiques
            var userStatsTask = GetAsync<UserStats>("/admin/stats/users");
            var invendusStatsTask = GetAsync<InvendusStats>("/admin/stats/invendus");
            var reservationsStatsTask = GetAsync<ReservationsStats>("/admin/stats/reservations");

            await Task.WhenAll(userStatsTask, invendusStatsTask, reservationsStatsTask);

            var userStats = await userStatsTask;
            var invendusStats = await invendusStatsTask;
            var reservationsStats = await reservationsStatsTask;

            return new DashboardStats
            {
                TotalRestaurants = userStats.TotalRestaurants,
                TotalAssociations = userStats.TotalAssociations,
                TotalFoodSaved = invendusStats.TotalQuantity,
                SatisfactionRating = 4.2, // Par défaut, l'API ne semble pas fournir cette info
                RecentActivities = new List<ActivityLog>(), // À implémenter si nécessaire
                ValidationPending = userStats.PendingValidations
            };
        }

        #endregion

        #region Demandes de validation

        public async Task<List<ValidationRequest>> GetValidationRequestsAsync()
        {
            try
            {
                // Récupérer toutes les données nécessaires en parallèle
                var justificatifsTask = GetAllJustificatifsAsync();
                var restaurantsTask = GetAllRestaurantsAsync();
                var associationsTask = GetAllAssociationsAsync();

                await Task.WhenAll(justificatifsTask, restaurantsTask, associationsTask);

                var justificatifs = await justificatifsTask;
                var restaurants = await restaurantsTask;
                var associations = await associationsTask;

                var validationRequests = new List<ValidationRequest>();

                // Ajouter les restaurants non validés
                foreach (var restaurant in restaurants.Where(r => !r.RestValide))
                {
                    // Vérifier que l'ID n'est pas null
                    if (restaurant.Id == 0 || restaurant.UtilisateurId == 0)
                    {
                        Console.WriteLine($"Restaurant avec ID invalide ignoré: {restaurant.Nom}");
                        continue;
                    }

                    var justificatif = justificatifs.FirstOrDefault(j =>
                        j.UtilisateurId == restaurant.UtilisateurId &&
                        j.Statut == "en_attente");

                    validationRequests.Add(new ValidationRequest
                    {
                        Id = restaurant.Id,
                        Nom = restaurant.Nom ?? "Sans nom",
                        Type = "Restaurant",
                        Adresse = restaurant.Adresse ?? "",
                        Localite = restaurant.Localite ?? "",
                        Canton = restaurant.Canton ?? "",
                        Email = restaurant.Utilisateur?.Email ?? "",
                        DateDemande = restaurant.CreatedAt,
                        Status = "En attente",
                        JustificatifPath = justificatif?.CheminFichier,
                        CreatedAt = restaurant.CreatedAt,
                        UpdatedAt = restaurant.UpdatedAt
                    });
                }

                // Ajouter les associations non validées
                foreach (var association in associations.Where(a => !a.AssoValide))
                {
                    // Vérifier que l'ID n'est pas null
                    if (association.Id == 0 || association.UtilisateurId == 0)
                    {
                        Console.WriteLine($"Association avec ID invalide ignorée: {association.Nom}");
                        continue;
                    }

                    var justificatif = justificatifs.FirstOrDefault(j =>
                        j.UtilisateurId == association.UtilisateurId &&
                        j.Statut == "en_attente");

                    validationRequests.Add(new ValidationRequest
                    {
                        Id = association.Id,
                        Nom = association.Nom ?? "Sans nom",
                        Type = "Association",
                        Adresse = association.Adresse ?? "",
                        Localite = association.Localite ?? "",
                        Canton = association.Canton ?? "",
                        Email = association.Utilisateur?.Email ?? "",
                        DateDemande = association.CreatedAt,
                        Status = "En attente",
                        JustificatifPath = justificatif?.CheminFichier,
                        CreatedAt = association.CreatedAt,
                        UpdatedAt = association.UpdatedAt
                    });
                }

                return validationRequests;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur dans GetValidationRequestsAsync: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        // Approbation d'une demande de validation
        public async Task<ValidationRequest> ApproveValidationRequestAsync(int id)
        {
            return await ProcessValidationRequestAsync(id, true);
        }

        // Rejet d'une demande de validation
        public async Task<ValidationRequest> RejectValidationRequestAsync(int id)
        {
            return await ProcessValidationRequestAsync(id, false);
        }

        private async Task<ValidationRequest> ProcessValidationRequestAsync(int id, bool isApproved)
        {
            // Récupérer la validation request pour déterminer si c'est un restaurant ou une association
            var validationRequests = await GetValidationRequestsAsync();
            var request = validationRequests.FirstOrDefault(vr => vr.Id == id);

            if (request != null)
            {
                if (request.Type == "Restaurant")
                {
                    await ValidateRestaurantAsync(id, isApproved);
                }
                else if (request.Type == "Association")
                {
                    await ValidateAssociationAsync(id, isApproved);
                }

                // Mettre à jour le statut de la validation request
                request.Status = isApproved ? "Approuvé" : "Rejeté";
                request.UpdatedAt = DateTime.Now;
                return request;
            }

            throw new Exception("Demande de validation introuvable");
        }

        #endregion
    }
}