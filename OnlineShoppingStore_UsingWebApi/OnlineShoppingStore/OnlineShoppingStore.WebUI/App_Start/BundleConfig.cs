
using System.Web.Optimization;

namespace OnlineShoppingStore.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate*"                      
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryintel").Include(
                        "~/scripts/jquery-3.1.1.intellisense.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                         "~/Scripts/bootstrap.js"
                         ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-theme.css",
                        "~/Content/site.css"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/onlineshoppingcartJs").Include(
                     "~/scripts/onlineshoppingcart.js"
                     ));


            // < script src = "~/scripts/jquery-3.1.1.js" ></ script >

            // < script src = "~/scripts/jquery.validate.js" ></ script >

            // < script src = "~/scripts/jquery.validate.unobtrusive.js" ></ script >

            //  < script src = "~/scripts/jquery-3.1.1.intellisense.js" ></ script >

            // < script src = "~/scripts/bootstrap.js" ></ script >

            // < link href = "~/Content/bootstrap.css" rel = "stylesheet" />

            // < link href = "~/Content/bootstrap-theme.css" rel = "stylesheet" />

            // < link href = "~/Content/Site.css" rel = "stylesheet" />

            // < script src = "~/scripts/modernizr-2.8.3.js" ></ script >

            // < script src = "~/scripts/onlineshoppingcart.js" ></ script >

        }
    }
}