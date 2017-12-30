using MVC_Identity_Cookie_Auth.ApplicationUsers;
using System.Security.Claims;
using System.Web.Mvc;

namespace MVC_Identity_Cookie_Auth.CustomBaseView
{
    //This is my pageBaseType for all razor view from now on.
    //It allows me addess to all MVC razor view methods as well as my AppUser Identity data.
    //Open up /views/web.config and the set the pageBaseType
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUserPrinciple CurrentUser
        {
            get
            {
                return new AppUserPrinciple(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}