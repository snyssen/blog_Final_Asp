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
        private readonly int PostsPerPage = 5;
        // GET: Home
        public ActionResult Index(int? id) // l'id correspond au numéro de page actuelle
        {
            int NumPage;
            if (id == null || id < 1)
                id = 1;
            NumPage = (int)id;
            IDAL dal = new DAL();
            int PostsNumber = dal.GetPostsNumber(); // On récupère le nombre total de posts
            HomeViewModel vm = new HomeViewModel
            {
                LoadedPosts = dal.GetPosts(PostsPerPage, NumPage),
                // On calcule le nombre de pages total, ce qui nous permet de déterminer le numéro de la dernière page
                LastPage = (PostsNumber % PostsPerPage == 0 ? PostsNumber / PostsPerPage : (PostsNumber / PostsPerPage) + 1), // Vu qu'on fait une division sur des entiers, au cas où il y a un reste, il faut rajouter une page sur laquelle sera affichée les derniers posts
                PageNum = NumPage
            };
            if (NumPage <= vm.LastPage)
                return View(vm);
            else
                return View("Error");
        }
    }
}