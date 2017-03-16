using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Security.Principal;

namespace OnlineShoppingService.Attributes
{
    public class BasicAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            Domain.Abstract.IUserRepository userRepository = actionContext.Request.GetDependencyScope()
                .GetService(typeof(Domain.Abstract.IUserRepository)) as Domain.Abstract.IUserRepository;

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string[] usernamePasswordArray = Helpers.SecurityHelper
                    .GetDecodedUserNameAndPassordFromAuthorizationHeader(actionContext.Request.Headers.Authorization.Parameter);

                if (userRepository.ClientKeyIsValid(usernamePasswordArray[0], usernamePasswordArray[1]))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(usernamePasswordArray[0]), null);
                }
                else
                {
                   actionContext.Response =  new HttpResponseMessage(HttpStatusCode.Unauthorized)
                   {
                       Content = new StringContent("[{\"Error\":\"Unauthorized\"}]", Encoding.UTF8, "application/json"),
                       ReasonPhrase = "Authentication failed"
                   };
                }
            }
        }
    }
}
