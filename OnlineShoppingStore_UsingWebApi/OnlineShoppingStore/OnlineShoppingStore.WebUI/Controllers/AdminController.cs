using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Configuration;

namespace OnlineShoppingStore.WebUI.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        private readonly Domain.Abstract.IProductRepository _productRepository;
        public AdminController(Domain.Abstract.IProductRepository repo)
        {
            _productRepository = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View("Index", await _productRepository.Products());
        }

        [HttpGet]
        public async Task<ViewResult> Update(int productId)
        {
            IEnumerable<Domain.Entities.Product> productList = await _productRepository.Products();

            var model = new Models.AdminViewModel()
            {
                Product = productList.FirstOrDefault(p => p.ProductId == productId),
                Catagories = productList.Select(c => c.Category).Distinct().OrderBy(c => c).ToList<string>()
            };

            return View(model);
        }

        [HttpPost]
        [Attributes.CustomAuthorize("UserAuthorizeRolesMedium")]
        [ValidateAntiForgeryToken()]
        public ActionResult Update(Domain.Entities.Product product)
        {
            string userData = null;
            if (Helpers.FormsAuth.Authenticated && Helpers.FormsAuth.GetUserData(Request, HttpContext.User.Identity.Name) != null)
            {
                userData = Helpers.FormsAuth.GetUserData(Request, HttpContext.User.Identity.Name);
            }
            else
            {
                TempData["WarningMessage"] = string.Format("Product ({0}) could not be updated because the user credentials are invlid.", product.Name);
                ModelState.AddModelError("NullCredential", string.Format("Product ({0}) could not be updated because the user credentials are invalid.", product.Name));
            }

            if (ModelState.IsValid)
            {
                _productRepository.SaveProductSyncronous(product, HttpContext.User.Identity.Name, userData);
                TempData["SuccessfulMessage"] = string.Format("Product ({0}) was saved successfully.", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Domain.Entities.Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        [Attributes.CustomAuthorize("UserAuthorizeRolesSuper")]
        public ActionResult Create(Domain.Entities.Product product)
        {
            string userData = null;
            if (Helpers.FormsAuth.Authenticated && Helpers.FormsAuth.GetUserData(Request, HttpContext.User.Identity.Name) != null)
            {
                userData = Helpers.FormsAuth.GetUserData(Request, HttpContext.User.Identity.Name);
            }
            else
            {
                TempData["WarningMessage"] = string.Format("Product ({0}) could not be created because the user credentials are invalid.", product.Name);
                ModelState.AddModelError("NullCredential", string.Format("Product ({0}) could not be created because the user credentials are invalid.", product.Name));
            }
            if (ModelState.IsValid)
            {
                Domain.Entities.Product savedProduct = _productRepository.SaveProductSyncronous(product, HttpContext.User.Identity.Name, userData);
                TempData["SuccessfulMessage"] = string.Format("Product ({0}) was saved successfully.", savedProduct.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpDelete]
        [Attributes.CustomAuthorize("UserAuthorizeRolesAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int productId)
        {
            string userData = null;
            if (Helpers.FormsAuth.Authenticated && Helpers.FormsAuth.GetUserData(Request, HttpContext.User.Identity.Name) != null)
            {
                userData = Helpers.FormsAuth.GetUserData(Request, HttpContext.User.Identity.Name);
            }
            else
            {
                TempData["WarningMessage"] = string.Format("Product ({0}) could not be deleted because the user credentials are invalid.", productId);
                ModelState.AddModelError("NullCredential", string.Format("Product ({0}) could not be deleted because the user credentials are invalid.", productId));
            }

            Domain.Entities.Product deletedProduct = _productRepository.DeleteProductSyncronous(productId, HttpContext.User.Identity.Name, userData);
            TempData["SuccessfulMessage"] = string.Format("Product ({0}) was deleted successfully.", deletedProduct.Name);
            return RedirectToAction("Index");
        }
    }
}