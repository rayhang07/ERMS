using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMS
{
    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string FullName { get; set; }
        public static string Email { get; set; }

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            FullName = null;
            Email = null;
        }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(Username);
    }
}
