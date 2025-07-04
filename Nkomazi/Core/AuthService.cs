using System.Threading.Tasks;

namespace Nkomazi.Core
{
    public static class AuthService
    {
        private static Models.DBEngine _db = new();

        // Attempts to login asynchronously
        public static Task<bool> LoginAsync(string user, string pass)
        {
            return Task.Run(() =>
            {
                bool valid = _db.ValidateCredentials(user, pass);
                if (valid)
                {
                    // Set the global values for the user session for verification
                    Models.Globals.IsAuthenticated = true; 
                    Models.Globals.UserName = user;
                }
                return valid;
            });
        }

        // Logs out the user and clears the authentication state
        public static void Logout()
        {
            Models.Globals.IsAuthenticated = false;
            Models.Globals.UserName = string.Empty;
        }
    }
}
