
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LinqToXmlFileWebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LinqToXmlFileWebApi.App_Start.NinjectWebCommon), "Stop")]

namespace LinqToXmlFileWebApi.App_Start
{
   
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;
    using System;
    using System.Web;
    using System.Web.Hosting;
    using System.Web.Http;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
           

            RegisterServices(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);


            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {

            ////Always use InRequestScope For Web Api 2
            var xmlDatabaseFile = HostingEnvironment.MapPath("~/App_Data/CustomersAndOrders.xml");
            kernel.Bind<CustomerFileContext.ICustomerOrderFileService>().To<CustomerFileContext.CustomerOrderFileService>().WithConstructorArgument("uri", new Uri(xmlDatabaseFile)); ;
        }
    }
}
