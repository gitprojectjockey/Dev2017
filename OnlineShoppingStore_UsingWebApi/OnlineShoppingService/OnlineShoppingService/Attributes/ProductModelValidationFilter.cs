using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OnlineShoppingService.Attributes
{
    public class ProductModelValidationFilter : ActionFilterAttribute
    {
        public HttpRequestMessage TestRequestMessage { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            PerformValidation(actionContext, TestRequestMessage ?? actionContext.Request);
        }
        private void PerformValidation(HttpActionContext actionContext, HttpRequestMessage request)
        {
            var modelState = actionContext.ModelState;

            if (!modelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            }
        }
    }
}