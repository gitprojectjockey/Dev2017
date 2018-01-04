using System.ComponentModel;
using System.Web;
using System.Web.Mvc;

namespace WOW.SavesTool.WebApp.Models
{
    public class HomeModelBinder : DefaultModelBinder
    {
        //public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //     var propertyName = bindingContext.ModelName;
        //    HttpRequestBase request = controllerContext.HttpContext.Request;
        //    var accountNumber = request.Form.Get("AccountNumber");
        //    var homeModel = new HomeModel { AccountNumber = accountNumber.Trim() };

        //    bindingContext.ModelState.SetModelValue(propertyName, new ValueProviderResult(homeModel));

        //    return homeModel;
        //}

        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor, object value)
        {
            if (propertyDescriptor.Name == "AccountNumber")
            {
                if (value != null)
                {
                    value = ((string)value).Trim();
                }
            }

            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);

            base.OnModelUpdated(controllerContext, bindingContext);
        }
    }
}