using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC_Identity_Cookie_Auth.ApplicationUsers
{
    public class AppDbIdentityUser : IdentityUser
    {
        //Inherits Email and Name
        
        public string Country { get; set; }
    }
}