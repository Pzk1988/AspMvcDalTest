using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace PANWebApp.Services
{
    public class AuthenticationService
    {
        public void LogIn(string userName, bool remember = false)
        {
            FormsAuthentication.SetAuthCookie(userName, remember);
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}