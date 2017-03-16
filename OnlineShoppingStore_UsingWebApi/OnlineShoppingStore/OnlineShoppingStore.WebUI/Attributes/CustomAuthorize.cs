
using Ninject;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace OnlineShoppingStore.WebUI.Attributes
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        [Inject]
        public Domain.Abstract.IUserRepository InjectedUserRepository { get; set; }
        public CustomAuthorize(params string[] roleKeys)
        {
            var roles = new List<string>();
            var allRoles = (NameValueCollection)ConfigurationManager.GetSection("CustomRoles");
            foreach (var roleKey in roleKeys)
            {
                roles.AddRange(allRoles[roleKey].Split(new[] { ',' }));
            }
            Roles = string.Join(",", roles);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary()
                {
                    { "controller", "AuthorizationDenied"},
                    { "action", "Index"} ,
                    { "returnController", filterContext.RequestContext.RouteData.Values["Controller"]},
                    { "returnAction", "Index"}
                }); 
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
          
            var authCookie = httpContext.Request.Cookies[httpContext.User.Identity.Name];
            if (authCookie != null && !string.IsNullOrEmpty(this.Roles))
            {
                string[] configRoles = this.Roles.Split(new[] { ',' });
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                List<Domain.Entities.UserRole> roles = InjectedUserRepository.UserRoles(authTicket.Name, authTicket.UserData);
                string[] databaseRoles = roles.Select(r => r.Role).ToArray<string>();
                bool hasMatch = configRoles.Select(x => x)
                            .Intersect(databaseRoles)
                            .Any();
                if (hasMatch)
                {
                    return true;
                }
            }
           
            return base.AuthorizeCore(httpContext);
        }
    }
}