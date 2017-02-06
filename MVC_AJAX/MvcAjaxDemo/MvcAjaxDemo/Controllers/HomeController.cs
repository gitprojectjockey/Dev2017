
using MvcAjaxDemo.Data.UnitOfWork.Abstract;
using System.Web.Mvc;

namespace MvcAjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetAllProducts()
        {
           
           if( Request.IsAjaxRequest())
            { }
            var model = _unitOfWork.Products.GetAll();
                return PartialView("_Product", model);
           
        }
        public PartialViewResult GetMostExpensiveProducts(int count)
        {
            var model = _unitOfWork.Products.GetMostExpensiveProducts(count);
            return PartialView("_Product", model);
        }

        public PartialViewResult GetLeastExpensiveProducts(int count)
        {
            var model = _unitOfWork.Products.GetLeastExpensiveProducts(count);
            return PartialView("_Product", model);
        }
    }
}