using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using static OnlineShoppingStore.WebUI.Attributes.NavigationLocationFilter;

namespace OnlineShoppingStore.WebUI.Controllers
{
    
    public class CartController : Controller
    {
        private readonly Domain.Abstract.IProductRepository _productRepository;
        private readonly Domain.Abstract.IOrderProcessor _orderProcessor;
       
        public CartController(Domain.Abstract.IProductRepository repo, Domain.Abstract.IOrderProcessor op)
        {
            _productRepository = repo;
            _orderProcessor = op;
        }


        //NavigationLocationFilter is used to disable the Menu Check Out button when ever we have navigate to the Check out view.
        [HttpGet]
        [NavigationLocationFilter("Cart")]
        public ViewResult Index(Domain.Entities.Cart cart, string returnUrl, bool menuCheckOutClicked = false )
        {
            return View(new Models.CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl});
        }

        //NavigationLocationFilter is used to disable the Menu Check Out button when ever we have navigate to the Check out view.
        public PartialViewResult CartSummary(Domain.Entities.Cart cart, string location)
        {
            if (location != null && location.Equals("Cart"))
                ViewBag.DisableMenuCheckOut = true;

            return PartialView(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        [NavigationLocationFilter("Cart")]
        public async System.Threading.Tasks.Task<RedirectToRouteResult> AddToCart(Domain.Entities.Cart cart, int productId, string returnUrl)
        {
            string key = ConfigurationManager.AppSettings.Get("ProductListCacheKey");
            IEnumerable<Domain.Entities.Product> productList = await _productRepository.Products(key);
            Domain.Entities.Product product = productList.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [NavigationLocationFilter("Cart")]
        public async System.Threading.Tasks.Task<RedirectToRouteResult> RemoveFromCart(Domain.Entities.Cart cart, int productId, string returnUrl)
        {
            IEnumerable<Domain.Entities.Product> productList = await _productRepository.Products();
            Domain.Entities.Product product = productList.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveCartItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpGet]
        [NavigationLocationFilter("Cart")]
        public ActionResult Checkout(Domain.Entities.Cart cart, string returnUrl)
        {
            if (cart.CartItems.Count() > 0)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View(new Domain.Entities.ShippingDetails());
            }
            else
            {
                return RedirectToAction("Index", new { returnUrl, cartIsEmpty = true});
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [NavigationLocationFilter("Cart")]
        public ViewResult Checkout(Domain.Entities.Cart cart, Domain.Entities.ShippingDetails shippingDetails)
        {
            if (cart.CartItems.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry but your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                _orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.ClearCartItems();
                return View("Completed");
            }
            else
            {
                return View(new Domain.Entities.ShippingDetails());
            }
        }
    }
}