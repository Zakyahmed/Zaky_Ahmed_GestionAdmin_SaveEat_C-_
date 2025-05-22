using GestionAdmin_SaveEat_C_.Services;

namespace GestionAdmin_SaveEat_C_
{
    public static class ApiServiceManager
    {
        private static ApiService _instance;

        public static ApiService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApiService();

                    // Si un token existe dans Storage, le configurer
                    string token = Storage.GetToken();
                    if (!string.IsNullOrEmpty(token))
                    {
                        _instance.SetAuthToken(token);
                    }
                }
                return _instance;
            }
        }

        // Méthode pour réinitialiser l'instance (utile lors de la déconnexion)
        public static void Reset()
        {
            _instance = null;
        }
    }
}