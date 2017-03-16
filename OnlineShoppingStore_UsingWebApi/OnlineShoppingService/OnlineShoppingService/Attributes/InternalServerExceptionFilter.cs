using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace OnlineShoppingService.Attributes
{
    public class InternalServerExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("[{\"Error\":\"An unhandled exception was thrown by the Products service.\"}]", Encoding.UTF8, "application/json"),
                ReasonPhrase = string.Format("Internal Server Error. Please Contact your Administrator. {0}", exceptionMessage)
            };
            // This would be a good place to log the issue
            actionExecutedContext.Response = response;
        }
    }
}