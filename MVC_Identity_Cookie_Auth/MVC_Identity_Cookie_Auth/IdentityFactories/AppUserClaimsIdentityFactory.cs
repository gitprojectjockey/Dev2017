using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MVC_Identity_Cookie_Auth.ApplicationUsers;

namespace MVC_Identity_Cookie_Auth.IdentityFactories
{
    public class AppUserClaimsIdentityFactory : ClaimsIdentityFactory<AppDbIdentityUser>
    {
        public override async Task<ClaimsIdentity> CreateAsync(UserManager<AppDbIdentityUser, string> manager, AppDbIdentityUser user, string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);
           
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Country, user.Country));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            return identity;
        }
    }
}