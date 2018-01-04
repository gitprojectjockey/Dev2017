using System;
using System.Configuration;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Wcf;
using AutoMapper;
using WOW.SavesTool.WebApp.Automapper;
using WOW.SavesTool.WebApp.Controllers;
using WOW.SavesTool.WebApp.Models;
using WOW.SaveTool.Data;
using WOW.SaveTool.Data.Customer;
using WOW.SaveTool.Data.ProductCommand;
using WOW.SaveTool.Data.ProductQuery;

namespace WOW.SavesTool.WebApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
           // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var automapperConfig = new AutoMapperConfig().RegisterMappings();
            automapperConfig.AssertConfigurationIsValid();

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterFilterProvider();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.Register(c => automapperConfig.CreateMapper()).As<IMapper>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<CustomModelValidator>().As<IModelValidator>();
            builder.RegisterType<LogRepository>().As<ILogRepository>();

            builder.Register(c => new ChannelFactory<IProductCommand>("BasicHttpBinding_IProductCommand"));
            builder.Register(c => new ChannelFactory<ICustomer>("BasicHttpBinding_ICustomer"));
            builder.Register(c => new ChannelFactory<IProductQuery>("BasicHttpBinding_IProductQuery"));

            builder.Register(c =>
            {
                var factory = c.Resolve<ChannelFactory<IProductCommand>>();
                var credentialBehaviour = factory.Endpoint.Behaviors.Find<ClientCredentials>();
                credentialBehaviour.UserName.UserName = ConfigurationManager.AppSettings["ProductCommand.Username"];
                credentialBehaviour.UserName.Password = ConfigurationManager.AppSettings["ProductCommand.Password"];
                return factory.CreateChannel();
            }
            ).As<IProductCommand>().UseWcfSafeRelease();


            builder.Register(c =>
            {
                var factory = c.Resolve<ChannelFactory<ICustomer>>();
                var credentialBehaviour = factory.Endpoint.Behaviors.Find<ClientCredentials>();
                credentialBehaviour.UserName.UserName = ConfigurationManager.AppSettings["Customer.Username"];
                credentialBehaviour.UserName.Password = ConfigurationManager.AppSettings["Customer.Password"];
                return factory.CreateChannel();
            }).As<ICustomer>().UseWcfSafeRelease();


            builder.Register(c =>
            {
                var factory = c.Resolve<ChannelFactory<IProductQuery>>();
                var credentialBehaviour = factory.Endpoint.Behaviors.Find<ClientCredentials>();
                credentialBehaviour.UserName.UserName = ConfigurationManager.AppSettings["ProductQuery.Username"];
                credentialBehaviour.UserName.Password = ConfigurationManager.AppSettings["ProductQuery.Password"];
                return factory.CreateChannel();
            }).As<IProductQuery>().UseWcfSafeRelease();


            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            ModelBinders.Binders.Add(typeof(HomeModel), new HomeModelBinder());

        }

        protected void Application_Error()
        {
            if (Context.IsCustomErrorEnabled)
            {
                ShowCustomErrorPage(Server.GetLastError());
            }
        }

        private void ShowCustomErrorPage(Exception exception)
        {
            var httpException = exception as HttpException ?? new HttpException(500, "Internal Server Error", exception);

            Response.Clear();
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Errors");
            routeData.Values.Add("fromAppErrorEvent", true);

            switch (httpException.GetHttpCode())
            {
                    //Remove incase of securtity
                case 403:
                    routeData.Values.Add("action", "HttpError403");
                    //routeData.Values.Add("error", httpException.Message);
                    break;

                case 404:
                    routeData.Values.Add("action", "HttpError404");
                    //routeData.Values.Add("error", httpException.Message);
                    break;

                case 500:
                    routeData.Values.Add("action", "HttpError500");
                    //routeData.Values.Add("error", httpException.Message);
                    break;

                default:
                    routeData.Values.Add("action", "GeneralError");
                    //routeData.Values.Add("httpStatusCode", httpException.GetHttpCode());
                    break;
            }

            Server.ClearError();

            IController controller = new ErrorsController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}