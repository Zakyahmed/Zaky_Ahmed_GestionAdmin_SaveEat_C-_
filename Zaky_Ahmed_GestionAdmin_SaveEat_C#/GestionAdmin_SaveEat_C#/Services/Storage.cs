using System;

namespace GestionAdmin_SaveEat_C_.Services
{
    public static class Storage
    {
        private static string _token = "";
        private static DateTime _tokenExpiration = DateTime.MinValue;

        public static void SetToken(string token)
        {
            _token = token;
            _tokenExpiration = DateTime.Now.AddDays(7); // Token valide 7 jours
            Console.WriteLine($"Token stored: {!string.IsNullOrEmpty(token)}");
        }

        public static string GetToken()
        {
            if (DateTime.Now > _tokenExpiration)
            {
                ClearToken();
                return "";
            }
            return _token;
        }

        public static bool HasToken()
        {
            return !string.IsNullOrEmpty(GetToken());
        }

        public static void ClearToken()
        {
            _token = "";
            _tokenExpiration = DateTime.MinValue;
            Console.WriteLine("Token cleared");
        }
    }
}