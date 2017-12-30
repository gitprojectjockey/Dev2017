using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using MVC_Identity_Cookie_Auth.ApplicationUsers;
using Owin;

namespace MVC_Identity_Cookie_Auth
{



    //AuthenticationType - This is a string value that identifies the the cookie. This 
    //is necessary since we may have several instances of the Cookie middleware. 
    //For example, when using external auth servers (OAuth/OpenID) the same cookie 
    //middleware is used to pass claims from the external provider. If we'd pulled 
    //in the  Microsoft.AspNet.Identity NuGet package we could just use the 
    //constant DefaultAuthenticationTypes.ApplicationCookie which has the same 
    //value - "ApplicationCookie".
    //LoginPath - The path to which the user agent (browser) should be redirected to 
    //when your application returns an unauthorized (401) response. This should 
    //correspond to your "login" controller. In this case I have an AuthContoller 
    //with a LogIn action.


    //The ASP.NET Identity UserManager class is used to manage users e.g.registering new users, validating credentials and loading user information.It is not 
    //concerned with how user information is stored.For this it relies on a UserStore (which in our case uses Entity Framework). There are also implementations 
    //available for Azure Table Storage, RavenDB and MongoDB to name a few.

    //Below I use the Factory Pattern so that I can create a new instance of UserManager at the start 
    //of each request(you could achieve the same thing with the DI tool 
    //of your choice). In Startup.cs:


    public class Startup
    {
        public UserManager<AppDbIdentityUser> AppUserManager { get; internal set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });
        }
    }
}