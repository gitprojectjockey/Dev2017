using System.Security.Claims;

namespace MVC_Identity_Cookie_Auth.ApplicationUsers
{
    public class AppUserPrinciple : ClaimsPrincipal
    {
        public AppUserPrinciple(ClaimsPrincipal principal): base(principal){}

        public string Name => this.FindFirst(ClaimTypes.Name)?.Value;

        public string UserEmail => this.FindFirst(ClaimTypes.Email)?.Value;

        public string Country => this.FindFirst(ClaimTypes.Country)?.Value;
    }
}