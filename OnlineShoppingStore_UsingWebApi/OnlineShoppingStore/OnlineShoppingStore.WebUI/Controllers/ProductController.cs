using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly Domain.Abstract.IProductRepository _productRepository;
        public int _PageSize = 4;
        public ProductController(Domain.Abstract.IProductRepository repo)
        {
            _productRepository = repo;
        }

        [AllowAnonymous]
        public async Task<ViewResult> List(string category, int page = 1)
        {
            string key = ConfigurationManager.AppSettings.Get("ProductListCacheKey");
            IEnumerable<Domain.Entities.Product> productList = await _productRepository.Products(key);
            Models.ProductsViewModel model = new Models.ProductsViewModel()
            {
                Products = productList
                .Where(p => p.Category == category || category == null)
                .OrderBy(P => P.ProductId)
                .Skip((page - 1) * _PageSize)
                .Take(_PageSize),
                PagingInfo = new Models.PagingInfo { CurrentPage = page, ItemsPerPage = _PageSize, TotalItems = productList.Where(p => p.Category == category || category == null).Count() },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
