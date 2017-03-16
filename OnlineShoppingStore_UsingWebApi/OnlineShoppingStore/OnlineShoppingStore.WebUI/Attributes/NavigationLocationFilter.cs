using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Attributes
{
    public class NavigationLocationFilter : ActionFilterAttribute
    {
        // This custom action filter is used to keep determine if we a currently interacting on the Cart View
        public class NavigationLocationFilterAttribute : ActionFilterAttribute
        {
            public string CurrentLocation { get; set; }

            public NavigationLocationFilterAttribute(string currentLocation)
            {
                CurrentLocation = currentLocation;
            }

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var controller = (Controller)filterContext.Controller;
                controller.ViewData.Add("NavigationLocation", CurrentLocation);
            }
        }
    }
}