using Blog_final_Asp.Areas.Account.ViewModels;
using Blog_final_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog_final_Asp.Areas.Account.Controllers
{
    public class LoginController : Controller
    {
        private IDAL dal;

        public LoginController()
        {
            dal = new DAL();
        }
        // GET: Account/Login
        public ActionResult Index()
        {
            LoginViewModel vm = new LoginViewModel { Authenticated = HttpContext.User.Identity.IsAuthenticated };
            if (vm.Authenticated)
            {
                vm.User = dal.GetUser(HttpContext.User.Identity.Name);
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel vm, string returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(vm.User.Login) && !string.IsNullOrWhiteSpace(vm.User.Password))
            {
                User user = dal.AuthUser(vm.User.Login, vm.User.Password);
                if (user != null)
                {
                    // Solution trouvée ici -> https://stackoverflow.com/a/2342196
                    // Création d'un cookie d'authentification
                    var authTicket = new FormsAuthenticationTicket(
                        1,                              // Version du ticket
                        user.IDuser.ToString(),             // ID de l'utilisateur
                        DateTime.Now,                   // Date de création
                        DateTime.Now.AddDays(2),        // Date d'expiration
                        true,                           // Est persistant (survit à la fermeture du browser)
                        user.Access_Lvl.Role     // On stocke le rôle
                        );
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    //HttpContext.Current.Response.Cookies.Add(authCookie);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }
                ModelState.AddModelError("User.Login", "Login et/ou mot de passe incorrect(s)");
            }
            return View(vm);
        }

        public ActionResult Registration()
        {
            RegistrationViewModel vm = new RegistrationViewModel { Authenticated = HttpContext.User.Identity.IsAuthenticated };
            if (vm.Authenticated)
            {
                vm.Login = dal.GetUser(HttpContext.User.Identity.Name).Login;
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IDAL dal = new DAL();
                if (dal.GetUserLogin(vm.Login) == null)
                {
                    dal.AddUser(vm.Login, vm.Mail, Crypto.SHA256(vm.Password), 1, ProfilePicGenerator.GenerateProfilePic());

                    return Redirect("/Account/Login");
                }
                ModelState.AddModelError("Login", "Cet utilisateur existe déjà !");
            }

            return View(vm);
        }

        public ActionResult Disconnect()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}