using Blog_final_Asp.Areas.Account.ViewModels;
using Blog_final_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        /*public ActionResult Index()
        {
            LoginViewModel vm = new LoginViewModel { Authenticated = HttpContext.User.Identity.IsAuthenticated };
            if (vm.Authenticated)
            {
                vm.User = dal.GetUser(HttpContext.User.Identity.Name);
            }
            return View(vm);
        }
        [HttpPost]
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
                        user.Access_lvl.ToString()      // On stocke le niveau d'accès
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
        }*/
    }
}