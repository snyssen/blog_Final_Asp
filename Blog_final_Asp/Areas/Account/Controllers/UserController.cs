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
                User = dal.GetViewUser((int)id),
                LoggedUserID = IDloggedUser
            };
            if (vm.User == null)
                return View("Error");
            return View(vm);
        }
    }
}