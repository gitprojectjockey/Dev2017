using System;
using System.ServiceModel;
using System.Web.Mvc;

namespace WOW.SavesTool.WebApp.Filters
{
    public class SaveToolErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception.GetType() ==
                typeof (FaultException<SaveTool.Data.ProductQuery.ParameterFaultException>))
            {
                filterContext.Result=new ViewResult
                {
                    ViewName = "CustomerNotFound"
                };
                return;
            }

            filterContext.Result = new ViewResult
            {
                ViewName = "UnknownError"
            };
        }
    }
}