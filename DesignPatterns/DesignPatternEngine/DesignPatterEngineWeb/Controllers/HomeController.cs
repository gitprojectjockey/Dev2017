using System.Web.Mvc;
using DesignPatternEngine.InjectedLoggerPattern.Abstract;
using System;

namespace DesignPatterEngineWeb.Controllers
{
    public class HomeController : Controller
    {
        ICommonLogger _commonLogger;

        public HomeController(ICommonLogger commenLogger)
        {
            _commonLogger = commenLogger;
        }
        
        public ActionResult Index()
        {
            _commonLogger.InformationMessage = "Im in home controller index action";
            _commonLogger.LogMessage(this);
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(int Id)
        {
            try
            {
                _commonLogger.InformationMessage = "About to throw an excetion to common logger";
                _commonLogger.LogMessage(this);
                return View("Index");
            }
            catch (Exception ex)
            {
                _commonLogger.InformationMessage = "This is an error logging test";
                _commonLogger.Exp = ex; 
                _commonLogger.LogMessage(this);
                return View("Index");
            }
        }
    }
}