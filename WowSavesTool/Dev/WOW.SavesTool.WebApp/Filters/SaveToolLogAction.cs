using System;
using System.Web.Mvc;
using WOW.SavesTool.WebApp.Controllers;
using WOW.SaveTool.Data;

namespace WOW.SavesTool.WebApp.Filters
{
    public class SaveToolLogAction:Attribute,IActionFilter
    {

        public ILogRepository LogRepository { get; set; }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Controller.GetType() == typeof (HomeController) &&
                filterContext.ActionDescriptor.ActionName == "index")
            {
                //log index 
            }
        }
    }
}