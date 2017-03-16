using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using WebApiContrib.IoC.Ninject;
using Ninject;


namespace OnlineShoppingService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // I am binding IProductRepository to EFProductRepsitory and IUserRepository to EFUserRepository using transient scope so I 
            // Get a new instance of the repository for each request
            // We need to do this because EF Context is not thread safe
            // With this aproach I will only have a single thread acting on EF Context at a time 

            IKernel kernel = new StandardKernel();
            kernel.Bind<Domain.Abstract.IEFDbContext>().To<Domain.Concrete.EFDbContext>().InTransientScope();

            kernel.Bind<Domain.Abstract.IProductRepository>().To<Domain.Concrete.ProductRepository>().InTransientScope()
               .WithConstructorArgument("productRepository", new Domain.Concrete.ProductRepository(new Domain.Concrete.EFDbContext()));

            config.DependencyResolver = new NinjectResolver(kernel);

            kernel.Bind<Domain.Abstract.IUserRepository>().To<Domain.Concrete.UserRepository>().InTransientScope()
                .WithConstructorArgument("userRepository", new Domain.Concrete.UserRepository(new Domain.Concrete.EFDbContext()));
            //config.DependencyResolver = new NinjectResolver(kernel);

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Setup media type formatters
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            // Only allow json formatting by removing the xml formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Only allow xml formatting by removing the json formatter
            //config.Formatters.Remove(config.Formatters.JsonFormatter);

            //Setup some custom routes patterns

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "eservices/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "ActionBasedRoute",
                routeTemplate: "eservices/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "CustomRouteUpdate",
                routeTemplate: "eservices/{controller}/{action}/update",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "CustomRouteCreate",
                routeTemplate: "eservices/{controller}/{action}/create",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "CustomRouteDelete",
                routeTemplate: "eservices/{controller}/{action}/delete/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "CustomRouteGet",
                routeTemplate: "eservices/{controller}/{action}/get/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
