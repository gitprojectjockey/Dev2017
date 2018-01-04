using System.Web.Mvc;

namespace WOW.SavesTool.WebApp.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult HttpError403(string error)
        {
            ViewData["Title"] = "WOW Saves Tool 403 Error";
            ViewData["Description"] = "Sorry, an error occurred while processing your request. (403)";

            //TODO: Log the error message

            return View("Index");
        }

        public ActionResult HttpError404(string error)
        {
            ViewData["Title"] = "WOW Saves Tool 404 Error";
            ViewData["Description"] = "Sorry, an error occurred while processing your request. (404)";

            //TODO: Log the error message

            return View("Index");
        }

        public ActionResult HttpError500(string error)
        {
            ViewData["Title"] = "WOW Saves Tool 500 Error";
            ViewData["Description"] = "Sorry, an error occurred while processing your request. (500)";

            //TODO: Log the error message

            return View("Index");
        }

        public ActionResult General(string error)
        {
            ViewData["Title"] = "WOW Saves Tool General Error";
            ViewData["Description"] = "Sorry, an error occurred while processing your request. (General Application Error)";

            //TODO: Log the error message

            return View("Index");
        }
    }
}