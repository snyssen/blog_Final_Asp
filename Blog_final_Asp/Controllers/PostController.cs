using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_final_Asp.Models;
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
        [ValidateAntiForgeryToken]
        public ActionResult Index(PostIndexViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IDAL dal = new DAL();
                if (vm.Picture != null)
                {
                    string FileName = System.IO.Path.GetFileName(vm.Picture.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/Posts"), FileName);
                    vm.Picture.SaveAs(path);
                    dal.AddPost(vm.Title, vm.Body, DateTime.Now, path);
                }
                else
                    dal.AddPost(vm.Title, vm.Body, DateTime.Now);
                return Redirect("/");
            }
            return View(vm);
        }

        public ActionResult ID(int ID) // Affiche un billet par son ID
        {
            throw new NotImplementedException();
        }
    }
}