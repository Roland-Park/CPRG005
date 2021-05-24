using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG005.Final.Roland.Helpers
{
    public interface ISessionHelper
    {
        bool IsLoggedIn { get; set; }
        string UserName { get; set; }
        int UserId { get; set; }
        string AccessToken { get; set; }
        void SignIn(string token, int id, string userName);
        void SignOut();

    }

    public class SessionHelper : ISessionHelper
    {
        public bool IsLoggedIn { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string AccessToken { get; set; }

        public void SignIn(string token, int id, string userName)
        {
            IsLoggedIn = true;
            UserName = userName;
            UserId = id;
            AccessToken = token;
        }

        public void SignOut()
        {
            IsLoggedIn = false;
            UserName = null;
            UserId = -1;
            AccessToken = null;
        }
    }
}
