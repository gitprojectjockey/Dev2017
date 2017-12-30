
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MVC_Identity_Cookie_Auth.ApplicationUsers;
using MVC_Identity_Cookie_Auth.IdentityFactories;
using MVC_Identity_Cookie_Auth.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_Identity_Cookie_Auth.Controllers
{

    //First we attempt to find a user with the provided credentials using  userManager.FindAsync.
    //If the user exists we create a claims identity for the user that can be passed to AuthenticationManager.
    //This will include any custom claims that you've stored.
    //Finally we sign in the user using the cookie authentication middleware SignIn(identity).


    [AllowAnonymous]
    public class AuthController : Controller
    {
        //First we'll make the UserManager<AppDbIdentityUser> instance accessible from the  AuthController:
        //We also dispose of user manager below.
        private readonly UserManager<AppDbIdentityUser> userManager;

        public AuthController() : this(UserManagerFactory.Create())
        {
        }

        public AuthController(UserManager<AppDbIdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> LogInAsync(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("LogIn");
            }

            var user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
            {
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                
                GetAuthenticationManager().SignIn(identity);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
            ModelState.AddModelError( "", "Invalid email or password");
            return View("LogIn");
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //To create the user we call userManager.CreateAsync passing our AppUser instance and the user password
        //(the ASP.NET Identity library will take care of hashing and storing this securely).
        [HttpPost]
        public async Task<ActionResult> Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new AppDbIdentityUser
            {
                UserName = model.Email,
                Country = model.Country,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignIn(user);
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        private async Task SignIn(AppDbIdentityUser user)
        {
            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            GetAuthenticationManager().SignIn(identity);
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}