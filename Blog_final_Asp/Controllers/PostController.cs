using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_final_Asp.ViewModels;

namespace Blog_final_Asp.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        [Authorize(Roles = ("Admin,Moderateur,Auteur"))]
        public ActionResult Index() // Gère l'ajout d'un billet
        {
            PostIndexViewModel vm = new PostIndexViewModel { };
            return View(vm);
        }

        [Authorize(Roles = ("Admin,Moderateur,Auteur"))]
        [HttpPost]
        public ActionResult Index(PostIndexViewModel vm)
        {
            return View(vm);
        }

        public ActionResult ID(int ID) // Affiche un billet par son ID
        {
            throw new NotImplementedException();
        }
    }
}