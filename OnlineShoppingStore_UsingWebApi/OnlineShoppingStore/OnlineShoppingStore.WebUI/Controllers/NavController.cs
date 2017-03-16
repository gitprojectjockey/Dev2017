using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly Domain.Abstract.IProductRepository _productRepository;
        public NavController(Domain.Abstract.IProductRepository repo)
        {
            _productRepository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            // This does not get called async because as of mvc 5 async is not supported in child actions.

            string key = ConfigurationManager.AppSettings.Get("ProductResponseCacheKey");
            ViewBag.SelectedCategory = category;
            IEnumerable<Domain.Entities.Product> productList =  _productRepository.ProductsSynchronous(key);
            IEnumerable<string> categories = productList
                .Select(c => c.Category)
                .Distinct()
                .OrderBy(c => c);

            return PartialView(categories.ToList());
        }
    }
}