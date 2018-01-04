using System.Web.Mvc;
using WOW.SavesTool.WebApp.Models;

namespace WOW.SavesTool.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IModelValidator _modelValidator;

        public HomeController(IModelValidator modelValidator)
        {
            _modelValidator = modelValidator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([ModelBinder(typeof(HomeModelBinder))] HomeModel homeModel)
        {
            if (_modelValidator.IsValid(ModelState))
            {
                return RedirectToAction("Index", "Customer", new {Id = homeModel.AccountNumber});
            }
            return View("Index", homeModel);
        }
    }

    public interface IModelValidator
    {
        bool IsValid(ModelStateDictionary modelState);
        
    }

    public class CustomModelValidator : IModelValidator
    {
        public bool IsValid(ModelStateDictionary modelState)
        {
            return modelState.IsValid;
        }
    }
}