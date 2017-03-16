[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineShoppingStore.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlineShoppingStore.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace OnlineShoppingStore.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Net.Http;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using System.Web.Mvc;
    using System.Configuration;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        private static void RegisterServices(IKernel kernel)
        {

           var  productsUri = ConfigurationManager.AppSettings.Get("ProductsUri");
            var usersUri = ConfigurationManager.AppSettings.Get("UsersUri");


            kernel.Bind<Domain.Abstract.IProductRepository>().To<Domain.Concrete.ProductRepository>()
                .WithConstructorArgument("httpClient", new HttpClient())
                .WithConstructorArgument("uri", new Uri(productsUri))
                .WithConstructorArgument("cacheHandler", new Domain.Concrete.InMemoryCache(300000));
            
            kernel.Bind<Domain.Abstract.IUserRepository>().To<Domain.Concrete.UserRepository>()
                .WithConstructorArgument("httpClient", new HttpClient())
                .WithConstructorArgument("uri", new Uri(usersUri));

            kernel.Bind<Domain.Abstract.IOrderProcessor>().To<Domain.Concrete.EmailOrderProcessor>()
                .WithConstructorArgument("settings", new Domain.Entities.EmailSettings());

            kernel.BindFilter<Attributes.CustomAuthorize>(FilterScope.Action, 0).When(
                (controllerContext, actionDescriptor) => string.Equals(controllerContext.RouteData.GetRequiredString("controller"),"admin",StringComparison.OrdinalIgnoreCase ));
            
           
            //Moq.Mock<Domain.Abstract.IProductRepository> mock = new Moq.Mock<Domain.Abstract.IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            //{
            //    new Domain.Entities.Product {ProductId = 99,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
            //    new Domain.Entities.Product {ProductId = 99,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
            //    new Domain.Entities.Product {ProductId = 99,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            //});
            //kernel.Bind<Domain.Abstract.IProductRepository>().ToConstant(mock.Object);
        }
    }
}
