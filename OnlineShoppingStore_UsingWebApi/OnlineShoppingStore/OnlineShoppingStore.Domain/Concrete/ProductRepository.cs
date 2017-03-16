using Newtonsoft.Json;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private static HttpClient _httpClient;
        private Uri _uri;
        private readonly ICacheService _cacheHandler; 

        public ProductRepository(HttpClient httpClient, Uri uri,ICacheService cacheHandler)
        {
            _httpClient = httpClient;
            _uri = uri;
            _cacheHandler = cacheHandler;
        }

        #region Async Methods
        public async Task<IEnumerable<Product>> Products()
        {
            List<Product> products; products = JsonConvert.DeserializeObject<List<Product>>(await _httpClient.GetStringAsync(_uri));
            return products;
        }

        public async Task<IEnumerable<Product>> Products(string key)
        {
            List<Product> products = await _cacheHandler
                .GetOrSet(key, async () => JsonConvert.DeserializeObject<List<Product>>(await _httpClient.GetStringAsync(_uri)) as List<Product>);

            return products;
        }

        public async Task<Product> Product(Product product)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", _uri, product.ProductId));
            return JsonConvert.DeserializeObject<Product>(await _httpClient.GetStringAsync(ub.Uri));
        }

        public async Task<Product> SaveProduct(Entities.Product product, string userEmail, string password)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userEmail}:{password}")));

            HttpResponseMessage response;
            if (product.ProductId == 0)
            {
               response = await _httpClient.PostAsJsonAsync(_uri.AbsoluteUri, product);
            }
            else
            {
               response = await _httpClient.PutAsJsonAsync(_uri.AbsoluteUri, product);
            }
            var p = response.Content.ReadAsAsync<Product>();
            return await p;
        }
        public async Task<Product> DeleteProduct(int productId, string userEmail, string password)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", _uri, productId));
            HttpResponseMessage response = await _httpClient.DeleteAsync(ub.Uri);
            var product = response.Content.ReadAsAsync<Product>();
            return await product;
        }
        #endregion

        #region Sync Methods
        public IEnumerable<Product> ProductsSynchronous()
        {
            // This was written because as of mvc 5 async operations are not supported in child actions
            // such as partial views
            var response = _httpClient.GetAsync(_uri).Result;
            if (response.IsSuccessStatusCode)
            {
                // by calling .Result you are performing a synchronous call
                var responseContent = response.Content;
                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Product>>(responseString);
            }
            else
            {
                throw new HttpException((int)response.StatusCode, "Unable to get products");
            }
        }
        public IEnumerable<Product> ProductsSynchronous(string key)
        {
            // This was written because as of mvc 5 async operations are not supported in child actions
            // such as partial views
            var response = _cacheHandler
               .GetOrSet(key, () => (_httpClient.GetAsync(_uri).Result) as HttpResponseMessage);

            //var response = _httpClient.GetAsync(_uri).Result;
            if (response.IsSuccessStatusCode)
            {
                // by calling .Result you are performing a synchronous call
                var responseContent = response.Content;
                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Product>>(responseString);
            }
            else
            {
                throw new HttpException((int)response.StatusCode, "Unable to get products");
            }
        }
        public Product SaveProductSyncronous(Entities.Product product, string userEmail, string password)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userEmail}:{password}")));

            HttpResponseMessage response;
            if (product.ProductId == 0)
            {
                response = _httpClient.PostAsJsonAsync(_uri.AbsoluteUri, product).Result;
            }
            else
            {
                response = _httpClient.PutAsJsonAsync(_uri.AbsoluteUri, product).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Product>().Result;
            }
            else
            {
                throw new HttpException((int)response.StatusCode, "Unable update product.");
            }
        }

        public Product DeleteProductSyncronous(int productId, string userEmail, string password)
        {

            _httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userEmail}:{password}")));

            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", _uri, productId));
            HttpResponseMessage response = _httpClient.DeleteAsync(ub.Uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsAsync<Product>();
                return product.Result;
            }
            else
            {
                throw new HttpException((int)response.StatusCode,"Unable to delete product.");
            }
        }

        #endregion
    }
}

