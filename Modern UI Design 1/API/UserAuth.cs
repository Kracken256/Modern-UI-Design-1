using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_UI_Design_1.API
{
    public class UserAuth
    {
        
        public static bool IsLoggedIn()
        {
            bool status = false;
            return status;
        }
        public static bool UserExists(string email)
        {
            // Query database for user.
            // For now return true for demo
            return true;
        }
        public static bool ValidateCreds(string email, string password)
        {
            // Query database to test creds
            // use HTTPS REST API
            // Set sessions id from server
            // For now hard code it.
            string session_id = "b20812c19036e8b0f89d2f1dad0cfd2b";
            SecureStorage.SetAsync("session_id", session_id);
            return true;
        }
    }
}
