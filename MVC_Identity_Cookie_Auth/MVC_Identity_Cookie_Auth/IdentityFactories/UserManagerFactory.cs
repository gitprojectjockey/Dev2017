using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_Identity_Cookie_Auth.ApplicationUsers;
using System;

namespace MVC_Identity_Cookie_Auth.IdentityFactories
{

    //The ASP.NET Identity UserManager class is used to manage users e.g.registering new users, validating credentials and loading user information.It is not 
    //concerned with how user information is stored.For this it relies on a UserStore (which in our case uses Entity Framework). There are also implementations 
    //available for Azure Table Storage, RavenDB and MongoDB to name a few.

    //Below I use the Factory Pattern so that I can create a new instance of UserManager at the start 
    //of each request(you could achieve the same thing with the DI tool 
    //of your choice). In Startup.cs:

    public static class UserManagerFactory
    {
        public static Func<UserManager<AppDbIdentityUser>> Create = () =>
        {
            var userManager = new UserManager<AppDbIdentityUser>(new UserStore<AppDbIdentityUser>(new AppDbIdentityContext()));

            // allow alphanumeric characters in username
            userManager.UserValidator = new UserValidator<AppDbIdentityUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            userManager.ClaimsIdentityFactory = new AppUserClaimsIdentityFactory();

            return userManager;
        };
    }
}