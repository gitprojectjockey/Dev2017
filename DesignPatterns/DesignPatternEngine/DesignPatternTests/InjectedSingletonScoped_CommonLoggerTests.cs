
using DesignPatterEngineWeb.Controllers;
using DesignPatternEngine.InjectedLoggerPattern.Abstract;
using DesignPatternEngine.InjectedLoggerPattern.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Web.Mvc;

namespace DesignPatternTests
{
    [TestClass]
    public class InjectedSingletonScoped_CommonLoggerTests
    {
        [TestMethod]
        public void Controller_Returns_Index_View()
        {
            var mockCommonLogger = new Moq.Mock<ICommonLogger>();
            mockCommonLogger.SetupSet(cl => cl.InformationMessage = "Infomatin Message from test");
            mockCommonLogger.SetupSet(cl => cl.Exp = new System.Exception("This is the exception message"));
            var sut = new HomeController(mockCommonLogger.Object);
            var result = sut.Index() as ViewResult;
            var result1 = sut.Index(1) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual("Index", result1.ViewName);
        }

        [TestMethod]
        public void Test_LoggerInjection_IsSingletonScope()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ICommonLogger>().To<CommonLogger>();
            kernel.Bind<CommonLogger>().ToSelf().InSingletonScope();
            var logger1 = kernel.Get<CommonLogger>();
            var logger2 = kernel.Get<CommonLogger>();
            Assert.AreEqual(logger1, logger2);
        }
    }
}

