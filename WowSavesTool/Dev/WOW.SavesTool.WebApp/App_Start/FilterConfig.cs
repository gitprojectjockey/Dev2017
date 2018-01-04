using System.Web;
using System.Web.Mvc;
using WOW.SavesTool.WebApp.Controllers;
using WOW.SavesTool.WebApp.Filters;

namespace WOW.SavesTool.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SaveToolErrorAttribute());
            filters.Add(new SaveToolLogAction());
        }
    }
}
