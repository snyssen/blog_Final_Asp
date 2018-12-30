using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_final_Asp.Filters;
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
                int IdPost;

                /* --- Ajout du post --- */
                if (vm.Picture != null)
                {
                    string FileName = System.IO.Path.GetFileName(vm.Picture.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/Posts"), FileName);
                    vm.Picture.SaveAs(path);
                    IdPost = dal.AddPost(vm.Title, vm.Body, DateTime.Now, path);
                }
                else
                    IdPost = dal.AddPost(vm.Title, vm.Body, DateTime.Now);

                /* --- Ajout de l'auteur --- */
                dal.AddAutor(int.Parse(HttpContext.User.Identity.Name), IdPost);

                return Redirect("/");
            }
            return View(vm);
        }

        public ActionResult Show(int? id) // Affiche un billet par son ID
        {
            if (id == null || id < 1)
                return View("Error");
            IDAL dal = new DAL();
            PostShowViewModel vm = new PostShowViewModel
            {
                Post = dal.GetPost((int)id),
                Writers = dal.GetWritersFromPost((int)id),
                Comments = dal.GetCommentsPost((int)id),
                UserIsConnected = HttpContext.User.Identity.IsAuthenticated
            };
            if (vm.Post == null)
                return View("Error");
            return View(vm);
        }
        [HttpPost]
        public ActionResult Show(int? id, PostShowViewModel POSTdata) // post d'un commentaire
        {
            if (id == null || id < 1)
                return View("Error");
            IDAL dal = new DAL();
            PostShowViewModel vm = new PostShowViewModel
            {
                Post = dal.GetPost((int)id),
                Writers = dal.GetWritersFromPost((int)id),
                Comments = dal.GetCommentsPost((int)id),
                UserIsConnected = HttpContext.User.Identity.IsAuthenticated,

                Title = POSTdata.Title,
                Body = POSTdata.Body,
                IDparentComm = POSTdata.IDparentComm
            };
            if (vm.Post == null)
                return View("Error");
            if (ModelState.IsValid)
            {
                dal.AddComment(vm.Title, vm.Body, DateTime.Now, int.Parse(HttpContext.User.Identity.Name), vm.Post.IDpost, vm.IDparentComm);
            }
            return View(vm);
        }
        [AjaxFilter]
        public ActionResult GetResForm(int IDpost, int IDparentComm) // Renvoie le formulaire pour poster une réponse à un commentaire
        {
            if (IDpost == 0 || IDparentComm == 0)
                return null;
            PostShowViewModel vm = new PostShowViewModel
            {
                Post = new Post { IDpost = IDpost },
                IDparentComm = IDparentComm
            };
            return PartialView(vm);
        }
    }
}