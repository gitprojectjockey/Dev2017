using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Binders
{
    public class CartModelBinder : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            const string sessionKey = "Cart";
            Domain.Entities.Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Domain.Entities.Cart)controllerContext.HttpContext.Session[sessionKey];
                if (cart == null)
                {
                    cart = new Domain.Entities.Cart();
                    if (controllerContext.HttpContext.Session != null)
                    { 
                        controllerContext.HttpContext.Session[sessionKey] = cart;
                    }
                }
            }

            return cart;
        }
    }
}