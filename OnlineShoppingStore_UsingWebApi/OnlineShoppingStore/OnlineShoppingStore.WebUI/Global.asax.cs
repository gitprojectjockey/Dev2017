using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OnlineShoppingStore.WebUI.App_Start;


namespace OnlineShoppingStore.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Domain.Entities.Cart), new Binders.CartModelBinder());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
