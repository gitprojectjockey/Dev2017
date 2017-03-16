using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShoppingService.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Routing;


namespace OnlineShoppingService.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void Test_Get_Products_NotNull_CountGreaterThenZero()
        {
            Moq.Mock<Domain.Abstract.IProductRepository> mockRepository = new Moq.Mock<Domain.Abstract.IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product {ProductId = 1,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 2,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 3,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            });
            ProductsController controller = new ProductsController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            HttpResponseMessage response = controller.Get();
            List<Domain.Entities.Product> products;
            Assert.IsTrue(response.TryGetContentValue(out products));
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count() > 0);
        }

        [TestMethod]
        public void Test_Get_Product_ProductNotNull_ProductIdMatch()
        {
            Moq.Mock<Domain.Abstract.IProductRepository> mockRepository = new Moq.Mock<Domain.Abstract.IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product {ProductId = 1,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 2,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 3,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            });
            ProductsController controller = new ProductsController(mockRepository.Object);
            var request = new HttpRequestMessage(HttpMethod.Get, "http://location/GetTest");
            controller.Request = request;
            controller.Configuration = new HttpConfiguration();

            Domain.Entities.Product product;
            HttpResponseMessage response = controller.Get(2);
            Assert.IsTrue(response.TryGetContentValue(out product));
            Assert.IsNotNull(product);
            Assert.IsTrue(product.ProductId == 2);
        }

        [TestMethod]
        public void Test_Post_Product_ResponseProductNotNull_ResponseProductOjectIdMatch_PostSetsLocationHeader_StatusCodeCreated()
        {
            Mock<Domain.Abstract.IProductRepository> mockRepository = new Moq.Mock<Domain.Abstract.IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product {ProductId = 1,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 2,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 3,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            });

            ProductsController controller = new ProductsController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://location/PostTest");
            controller.Request = request;

            var response = controller.Post(new Domain.Entities.Product { ProductId = 3, Name = "T-Shirt", Price = 22.6M, Description = "Mens Black T-Shirt", Category = "Clothing" });

            Domain.Entities.Product product;
            Assert.IsTrue(response.TryGetContentValue(out product));
            Assert.IsNotNull(product);
            Assert.IsTrue(product.ProductId == 3);
            Assert.AreEqual(response.Headers.Location.AbsoluteUri, "http://location/PostTest");
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void Test_Put_Product_ResponseProductNotNull_ResponseProductOjectIdMatch_PutSetsLocationUrlHeader_StatusCodeOK()
        {
            Mock<Domain.Abstract.IProductRepository> IMockRepository = new Moq.Mock<Domain.Abstract.IProductRepository>();
            IMockRepository.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product {ProductId = 1,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 2,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 3,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            });

            ProductsController controller = new ProductsController(IMockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var request = new HttpRequestMessage(HttpMethod.Put, "http://location/PutTest");
            controller.Request = request;

            var response = controller.Put(new Domain.Entities.Product { ProductId = 3, Name = "T-Shirt", Price = 22.6M, Description = "Mens Black T-Shirt", Category = "Clothing" });
            Domain.Entities.Product product;

            Assert.IsTrue(response.TryGetContentValue(out product));
            Assert.IsNotNull(product);
            Assert.IsTrue(product.ProductId == 3);
            Assert.AreEqual(response.Headers.Location.AbsoluteUri, "http://location/PutTest");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Test_Delete_Product_ResponseProductNotNull_ResponseProductIdMatch_DeleteSetsLocationUrlHeader_StatusCodeOK()
        {
            Mock<Domain.Abstract.IProductRepository> mockRepository = new Moq.Mock<Domain.Abstract.IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product {ProductId = 1,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 2,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 3,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            });

            ProductsController controller = new ProductsController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var request = new HttpRequestMessage(HttpMethod.Delete, "http://location/DeleteTest");
            controller.Request = request;

            mockRepository.Setup(r => r.DeleteProduct(3)).Returns(new Domain.Entities.Product
            {
                ProductId = 3, Name = "T-Shirt", Price = 22.6M, Description = "Mens Black T-Shirt", Category = "Clothing"
            });

            var response = controller.Delete(3);
            Domain.Entities.Product product;
            Assert.IsTrue(response.TryGetContentValue<Domain.Entities.Product>(out product));
            Assert.IsTrue(product.ProductId == 3);
            Assert.AreEqual(response.Headers.Location.AbsoluteUri, "http://location/DeleteTest");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Test_Get_StatusCodeBad_NonPositiveIdParameter()
        {
            Mock<Domain.Abstract.IProductRepository> mockRepository = new Moq.Mock<Domain.Abstract.IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product {ProductId = 1,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 2,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 3,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            });

            ProductsController controller = new ProductsController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://location/DeleteTest";
            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Moq.Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;
            var response = controller.Get(0);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Test_Post_StatusCodeBad_NullProductParameter()
        {
            Mock<Domain.Abstract.IProductRepository> mockRepository = new Moq.Mock<Domain.Abstract.IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product {ProductId = 1,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 2,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 3,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            });

            ProductsController controller = new ProductsController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://location/DeleteTest";
            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Moq.Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            var response = controller.Post(null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Test_Put_StatusCodeBad_NullProductParameter()
        {
            Mock<Domain.Abstract.IProductRepository> mockRepository = new Moq.Mock<Domain.Abstract.IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product {ProductId = 1,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 2,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 3,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            });

            ProductsController controller = new ProductsController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://location/DeleteTest";
            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Moq.Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            var response = controller.Put(null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Test_Delete_StatusCodeBad_NonPositiveIdParameter()
        {
            Mock<Domain.Abstract.IProductRepository> mockRepository = new Moq.Mock<Domain.Abstract.IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product {ProductId = 1,Name="TankTop T",Price = 22.6M, Description="Mens Black TankTop T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 2,Name="T-Shirt",Price = 22.6M, Description="Mens White T-Shirt",Category="Clothing" },
                new Domain.Entities.Product {ProductId = 3,Name="T-Shirt",Price = 22.6M, Description="Mens Black T-Shirt",Category="Clothing" }
            });

            ProductsController controller = new ProductsController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://location/DeleteTest";
            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Moq.Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            var response = controller.Delete(0);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }


        //Test action filter attribute
        [TestMethod]
        public void OnActionExecuting_CustomProductModelValidationActionFilter_ResponseIsNotSet()
        {
            var actionContext = new HttpActionContext();
            actionContext.ControllerContext = new HttpControllerContext();
            actionContext.ControllerContext.Request = new HttpRequestMessage();
            actionContext.ModelState.Clear();
            var attribute = new Attributes.ProductModelValidationFilter
            {
                TestRequestMessage = new HttpRequestMessage()
            };
            attribute.OnActionExecuting(actionContext);
            Assert.IsNull(actionContext.Response);
        }

        [TestMethod]
        public void OnActionExecuting_CustomProductModelValidationActionFilter_ResponseIsSetToBadRequest()
        {
            var actionContext = new HttpActionContext();
            actionContext.ModelState.AddModelError("Name", "Error");
            actionContext.ControllerContext = new HttpControllerContext();
            actionContext.ControllerContext.Request = new HttpRequestMessage();
            var attribute = new Attributes.ProductModelValidationFilter()
            {
                TestRequestMessage = new HttpRequestMessage()
            };
            attribute.OnActionExecuting(actionContext);
            Assert.AreEqual(HttpStatusCode.BadRequest, actionContext.Response.StatusCode);
        }

        //Test exception filter attribute
        [TestMethod]
        public void OnException_Custom500ExceptionFilter_ResponseIsSetToInternalServerError()
        {
            var actionExecutedContext = new HttpActionExecutedContext();
            actionExecutedContext.ActionContext = new HttpActionContext();
            actionExecutedContext.ActionContext.Response = new HttpResponseMessage();
            actionExecutedContext.Exception = new System.Exception("This is a test exception", new System.Exception("This is the inner exception test message"));
            var attribute = new Attributes.InternalServerExceptionFilter();
            attribute.OnException(actionExecutedContext);
            Assert.AreEqual(HttpStatusCode.InternalServerError, actionExecutedContext.Response.StatusCode);
        }
    }
}