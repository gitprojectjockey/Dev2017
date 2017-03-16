using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly Domain.Abstract.IUserRepository _userRepository;
        public UserController(Domain.Abstract.IUserRepository repo)
        {
            _userRepository = repo;
        }
        public UserController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(Domain.Entities.User user)
        {
            if (ModelState.IsValid)
            {
                string encryptedPassword = Helpers.Sha256Crypto.EncryptSha256(user.Password);
                user.Password = encryptedPassword;
                var isValid = _userRepository.IsValid(user.Email, encryptedPassword);
                if (isValid)
                {
                    if (!Helpers.FormsAuth.Authenticate(user) || !Helpers.FormsAuth.CreateTicket(user, Request, Response))
                    {
                        TempData["WarningMessage"] = string.Format("Unable to set authentication for user {0}. Please see your system administrator", user.Email);
                    }
                }
                else
                {
                    TempData["WarningMessage"] = string.Format("Credential for user ({0}) were invalid.", user.Email);
                }
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Helpers.FormsAuth.SignOut();
            return RedirectToAction("List", "Product");
        }
    }
}