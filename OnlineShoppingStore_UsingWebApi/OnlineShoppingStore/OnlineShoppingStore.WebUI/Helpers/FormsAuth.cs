using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace OnlineShoppingStore.WebUI.Helpers
{
    public static class FormsAuth
    {
        public static bool Authenticate(Domain.Entities.User currentUser)
        {
            FormsAuthentication.SetAuthCookie(currentUser.Email, false);
            return true;
        }
        public static bool CreateTicket(Domain.Entities.User currentUser, HttpRequestBase request, HttpResponseBase response)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, currentUser.Email, DateTime.Now, DateTime.Now.AddMinutes(10), false, currentUser.Password, FormsAuthentication.FormsCookiePath);

            HttpCookie cookie = new HttpCookie(currentUser.Email, FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            response.Cookies.Add(cookie);
            return true;
        }

        public static bool Authenticated
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }
        public static string GetUserData(HttpRequestBase request, string userName)
        {
            HttpCookie authCookie = request.Cookies[userName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
           
            return ticket.UserData;
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}