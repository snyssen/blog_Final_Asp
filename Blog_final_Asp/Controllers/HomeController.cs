using Blog_final_Asp.Models;
using Blog_final_Asp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_final_Asp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IDAL dal = new DAL();
            HomeViewModel vm = new HomeViewModel { Posts = dal.GetPosts() };
            return View(vm);
        }

        [Filters.AjaxFilter]
        public ActionResult LoadPosts(int IDofLastPost)
        {
            return PartialView();
        }
    }
}