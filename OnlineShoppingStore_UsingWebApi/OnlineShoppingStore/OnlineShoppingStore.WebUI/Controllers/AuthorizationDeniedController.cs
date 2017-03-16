using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class AuthorizationDeniedController : Controller
    {
        // GET: AuthorizationDenied
        public ActionResult Index(string returnController, string returnAction)
        {
            TempData["AuthorizationWarningMessage"] = "You do not have sufficient privleges to complete this action";
            return View();
        }
    }
}