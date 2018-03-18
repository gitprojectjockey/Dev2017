using System.Web.Http;
using System.Web.Http.Cors;

namespace LinqToXmlFileWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Setup media type formatters
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            //I installed Install-Package Microsoft.AspNet.WebApi.Cors and enabled Cors on this service
            //By Installing CORS or Cross - Origin Requests on the web service I am able to call the products api using stright json with ajax
            //from a cross domain client.

            //This enables CORS for all controllers and actions (GLOBAL) you can also do this at the controller of action level
            var cors = new EnableCorsAttribute("*", "*", "get,post,put,delete");
            config.EnableCors();

            //This Service uses attribute routing only so we need to call config.MapHttpAttributeRoutes() to enable it.
            config.MapHttpAttributeRoutes();

            // Only allow json formatting by removing the xml formatter
            // config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Only allow xml formatting by removing the json formatter
            // config.Formatters.Remove(config.Formatters.JsonFormatter);

            //This will enable content negotiation (Accept: application/json) (Accept: application/xml)
            config.Formatters.Add(config.Formatters.XmlFormatter);
            config.Formatters.Add(config.Formatters.JsonFormatter);

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
