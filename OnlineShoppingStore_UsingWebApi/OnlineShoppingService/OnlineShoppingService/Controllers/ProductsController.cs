using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;


namespace OnlineShoppingService.Controllers
{
   
    [Attributes.InternalServerExceptionFilter]
    public class ProductsController : ApiController
    {
        private readonly Domain.Abstract.IProductRepository _productRepository;

        public ProductsController(Domain.Abstract.IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            List<Domain.Entities.Product> products = _productRepository.Products.ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, products);
            return response;
        }
      
        public HttpResponseMessage Get(int id)
        {
            if (id <= 0)
            {
                var respEx = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("[{\"Error\":\"Request for product must contain a positive integer id value\"}]", Encoding.UTF8, "application/json"),
                    ReasonPhrase = "Invalid parameter"
                };
                return respEx;
            }
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { id = id });
            }
           
            var response = Request.CreateResponse(HttpStatusCode.OK, product);
            response.Headers.Location = new Uri(Request.RequestUri.ToString());
            return response;
        }
      
        [Attributes.BasicAuthenticationFilter]
        [Attributes.ProductModelValidationFilter]
        public HttpResponseMessage Post([FromBody]Domain.Entities.Product product)
        {
            if (product == null)
            {
                var respEx = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("[{\"Error\":\"Product entity parameter cannot be null.\"}]", Encoding.UTF8, "application/json"),
                    ReasonPhrase = "Invalid parameter"
                };
                return respEx;
            }

            var savedProduct = _productRepository.SaveProduct(product);
            var response = Request.CreateResponse(HttpStatusCode.Created, savedProduct);
            response.Headers.Location = new Uri(Request.RequestUri.ToString());
            return response;
        }

        [Attributes.BasicAuthenticationFilter]
        [Attributes.ProductModelValidationFilter]
        public HttpResponseMessage Put([FromBody]Domain.Entities.Product product)
        {
            try
            {
                if (product == null)
                {
                    var respEx = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("[{\"Error\":\"Product entity parameter cannot be null.\"}]", Encoding.UTF8, "application/json"),
                        ReasonPhrase = "Invalid parameter"
                    };
                    return respEx;
                }
                var savedProduct = _productRepository.SaveProduct(product);
                var response = Request.CreateResponse(HttpStatusCode.OK, savedProduct);
                response.Headers.Location = new Uri(Request.RequestUri.ToString());
                return response;
            }
            catch (KeyNotFoundException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Product Id {0} was not found for update.", product.ProductId));
            }
        }

        [Attributes.BasicAuthenticationFilter]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    var respEx = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("[{\"Error\":\"Request for delete must contain a positive integer id value.\"}]", Encoding.UTF8, "application/json"),
                        ReasonPhrase = "Invalid parameter"
                    };
                    return respEx;
                }
                var product = _productRepository.DeleteProduct(id);
                var response = Request.CreateResponse(HttpStatusCode.OK, product);
                response.Headers.Location = new Uri(Request.RequestUri.ToString());
                return response;
            }
            catch (KeyNotFoundException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Product Id {0} was not found for delete.", id));
            }
        }
    }
}
