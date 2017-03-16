using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OnlineShoppingService.Helpers
{
    public static class SecurityHelper
    {
        public static string[] GetDecodedUserNameAndPassordFromAuthorizationHeader(string token)
        {
            string decodedAuthenticationToken = Encoding.UTF8.GetString(
               Convert.FromBase64String(token));

            return decodedAuthenticationToken.Split(':');
        }
    }
}