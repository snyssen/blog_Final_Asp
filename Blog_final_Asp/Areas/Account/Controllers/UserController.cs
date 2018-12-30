using Blog_final_Asp.Areas.Account.ViewModels;
using Blog_final_Asp.Filters;
using Blog_final_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_final_Asp.Areas.Account.Controllers
{
    public class UserController : Controller
    {
        // GET: Account/User
        public ActionResult Index(UserSearchViewModel vm) // Page de recherche d'un utilisateur
        {
            return View(vm);
        }
        [AjaxFilter]
        public ActionResult Search(UserSearchViewModel vm)
        {
            IDAL dal = new DAL();
            if (!string.IsNullOrWhiteSpace(vm.SearchStr))
                vm.Users = dal.GetUsers().Where(usr => usr.Login.IndexOf(vm.SearchStr, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            else
                vm.Users = new List<User>();
            return PartialView(vm);
        }

        public ActionResult Show(int? id) // Affiche l'utilisateur avec l'id mentionné
        {
            if (id == null || id < 1)
                return View("Error");
            IDAL dal = new DAL();
            if (!int.TryParse(HttpContext.User.Identity.Name, out int IDloggedUser))
                IDloggedUser = 0;
            UserShowViewModel vm = new UserShowViewModel
            {
                ViewUser = dal.GetViewUser((int)id),
                LoggedUserID = IDloggedUser
            };
            if (vm.ViewUser == null)
                return View("Error");
            if (vm.LoggedUserID == vm.ViewUser.IDuser) // L'utilisateur est sur son propre profil => on récupère ses infos pour modif
            {
                vm.IDuser = vm.ViewUser.IDuser;
                vm.Login = vm.ViewUser.Login;
                vm.Mail = vm.ViewUser.Mail;
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Show(int? id, UserShowViewModel vm) // Affiche l'utilisateur avec l'id mentionné
        {
            IDAL dal = new DAL();
            if (ModelState.IsValid)
            {
                if (id == null || id < 1 || vm.LoggedUserID != int.Parse(HttpContext.User.Identity.Name))
                    return View("Error");
                User TestUser = dal.GetUserLogin(vm.Login);
                if (TestUser == null || TestUser.IDuser == vm.IDuser) // Soit l'user change de login et donc son nouveau login ne doit pas exister, soit il ne change pas de login et donc on le retrouve dans la DB (et il a le même ID)
                {
                    if (vm.Picture != null)
                    {
                        string FileName = System.IO.Path.GetFileName(vm.Picture.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images/profile_pics"), FileName);
                        vm.Picture.SaveAs(path);
                        if (dal.UpdateUser(vm.IDuser, vm.Login, vm.Mail, Url.Content("~/Images/profile_pics/" + FileName)))
                            return RedirectToAction("Show/" + id);
                        else
                            ModelState.AddModelError("User.Login", "L'utilisateur est introuvable !");
                    }
                    else
                    {
                        if (dal.UpdateUser(vm.IDuser, vm.Login, vm.Mail))
                            return RedirectToAction("Show/" + id);
                        else
                            ModelState.AddModelError("User.Login", "L'utilisateur est introuvable !");
                    }
                }
                else
                    ModelState.AddModelError("User.Login", "Ce nom d'utilisateur est déjà pris !");
            }
            vm.ViewUser = dal.GetViewUser(vm.IDuser);
            return View(vm);
        }
    }
}