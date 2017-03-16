using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace OnlineShoppingService.Controllers
{
    [RoutePrefix("eservices/users")]
    [Attributes.InternalServerExceptionFilter]
    public class UsersController : ApiController
    {
        private readonly Domain.Abstract.IUserRepository _userRepository;

        public UsersController(Domain.Abstract.IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("IsClientKeyValid")]
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage IsClientKeyValid()
        {
            if (Request.Headers.Authorization == null)
            {
                var respEx = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("[{\"Error\":\"No authorization parameter found in request header.\"}]", Encoding.UTF8, "application/json"),
                    ReasonPhrase = "Invalid parameter"
                };
                return respEx;
            }

            string[] usernamePasswordArray = Helpers.SecurityHelper.GetDecodedUserNameAndPassordFromAuthorizationHeader(Request.Headers.Authorization.Parameter);
            var isValid = _userRepository.ClientKeyIsValid(usernamePasswordArray[0], usernamePasswordArray[1]);
            var response = Request.CreateResponse(HttpStatusCode.OK, isValid);
            response.Headers.Location = new Uri(Request.RequestUri.ToString());
            return response;
        }

       
       
        [HttpGet]
        [Route("GetUserRoles")]
        [Attributes.BasicAuthenticationFilter]
        public HttpResponseMessage GetUserRoles()
        {
            if (Request.Headers.Authorization == null)
            {
                var respEx = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("[{\"Error\":\"No authorization parameter found in request header.\"}]", Encoding.UTF8, "application/json"),
                    ReasonPhrase = "Invalid parameter"
                };
                return respEx;
            }

            string[] usernamePasswordArray = Helpers.SecurityHelper.GetDecodedUserNameAndPassordFromAuthorizationHeader(Request.Headers.Authorization.Parameter);
            var roles = _userRepository.GetUserRoles(usernamePasswordArray[0]).ToList();
            if (roles.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { UserId = usernamePasswordArray[0] });
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, roles);
            response.Headers.Location = new Uri(Request.RequestUri.ToString());
            return response;
        }
    }
}