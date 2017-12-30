using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC_Identity_Cookie_Auth.ApplicationUsers
{
    //Whilst you can use the built in IdentityDbContext<TUser>, the guys 
    //behind the ASP.NET Identity library recommend you create your own 
    //EF  DbContext. This allows you to use the same context for other 
    //application data which makes it easier to manage things like
    //session-per-request and database migrations.

    //By default, EF will create a database named DefaultConnection in your  App_Data directory.
    //If you want to override it you can just add your own connection string in web.config.

    //Note - You should also make sure you create the App_Data directory in advance,
    //otherwise EF will throw a wobbly.

    public class AppDbIdentityContext : IdentityDbContext<AppDbIdentityUser>
    {
        public AppDbIdentityContext() : base("DefaultConnection")
        {
        }
    }
}