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
        public ActionResult Index(PostIndexViewModel vm) // Ajout d'un billet
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
                    IdPost = dal.AddPost(vm.Title, vm.Body, DateTime.Now, Url.Content("~/Images/Posts/" + FileName));
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
            if (!int.TryParse(HttpContext.User.Identity.Name, out int IDloggedUser))
                IDloggedUser = 0;
            PostShowViewModel vm = new PostShowViewModel
            {
                Post = dal.GetPost((int)id),
                Writers = dal.GetWritersFromPost((int)id),
                Comments = dal.GetCommentsPost((int)id),
                LoggedUserID = IDloggedUser
            };
            if (IDloggedUser > 0)
                vm.LoggedUserRole = dal.GetViewUser(IDloggedUser).Access_lvl;
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
            if (!int.TryParse(HttpContext.User.Identity.Name, out int IDloggedUser))
                IDloggedUser = 0;
            PostShowViewModel vm = new PostShowViewModel
            {
                Post = dal.GetPost((int)id),
                Writers = dal.GetWritersFromPost((int)id),
                Comments = dal.GetCommentsPost((int)id),
                LoggedUserID = IDloggedUser,

                Title = POSTdata.Title,
                Body = POSTdata.Body,
                IDparentComm = POSTdata.IDparentComm
            };
            if (vm.Post == null)
                return View("Error");
            if (ModelState.IsValid)
            {
                dal.AddComment(vm.Title, vm.Body, DateTime.Now, int.Parse(HttpContext.User.Identity.Name), vm.Post.IDpost, vm.IDparentComm);
                return RedirectToAction("Show/" + vm.Post.IDpost); // Redirection pour vider le ViewModel et charger le nouveau commentaire
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

        [Authorize(Roles = ("Admin,Moderateur,Auteur"))]
        public ActionResult Settings(int? id) // Modification/Retrait d'un billet ou ajout/retrait d'un collaborateur
        {
            if (id == null || id < 1)
                return View("Error");
            IDAL dal = new DAL();
            Post post = dal.GetPost((int)id);
            if (post == null)
                return View("Error");
            PostSettingsViewModel vm = new PostSettingsViewModel // Pas besoin de vérifier que l'ID des cookies est set vu que le filtre Authorize nous assure déjà que l'user est authentifié
            {
                IDpost = post.IDpost,   
                Title = post.Title,
                Body = post.Body,
                PostPic = post.Picture,
                Writers = dal.GetWritersFromPost((int)id),
                Auteurs = dal.GetAllAuteurs(),
                LoggedUserID = int.Parse(HttpContext.User.Identity.Name),
                LoggedUserRole = dal.GetViewUser(int.Parse(HttpContext.User.Identity.Name)).Access_lvl
            };
            // Vérification d'identité
            // L'utilisateur peut modifier le billet si 1) il en est un des auteurs, 2) si il est modérateur ou admin
            if(vm.Writers.Where(user => user.IDuser == vm.LoggedUserID).Count() > 0 || vm.LoggedUserRole == "Moderateur" || vm.LoggedUserRole == "Admin")
            {
                // On retire des auteurs ceux qui sont déjà gestionnaires du post
                foreach (User user in vm.Writers)
                {
                    User ToRemove = vm.Auteurs.FirstOrDefault(aut => aut.IDuser == user.IDuser);
                    if (ToRemove != null)
                        vm.Auteurs.Remove(ToRemove);
                }
                return View(vm);
            }
            return RedirectToAction("Index", "Login", new { Area = "Account", returnUrl = HttpContext.Request.RawUrl });
        }
        [Authorize(Roles = ("Admin,Moderateur,Auteur"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Settings(int? id, PostSettingsViewModel vm) // Modification/Retrait d'un billet ou ajout/retrait d'un collaborateur
        {
            if (id == null || id < 1)
                return View("Error");
            IDAL dal = new DAL();
            Post post = dal.GetPost((int)id);
            if (post == null)
                return View("Error");
            // On récupère les auteurs
            vm.Writers = dal.GetWritersFromPost(post.IDpost);
            // Vérification d'identité
            // L'utilisateur peut modifier le billet si 1) il en est un des auteurs, 2) si il est modérateur ou admin
            if (vm.Writers.Where(user => user.IDuser == vm.LoggedUserID).Count() > 0 || vm.LoggedUserRole == "Moderateur" || vm.LoggedUserRole == "Admin")
            {
                if (ModelState.IsValid)
                {
                    if (vm.Picture != null)
                    {
                        string FileName = System.IO.Path.GetFileName(vm.Picture.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images/Posts"), FileName);
                        vm.Picture.SaveAs(path);
                        if (!dal.UpdatePost(vm.IDpost, vm.Title, vm.Body, Url.Content("~/Images/Posts/" + FileName), DateTime.Now))
                            return View("Error");
                    }
                    else
                        if (!dal.UpdatePost(vm.IDpost, vm.Title, vm.Body, DateTime.Now))
                            return View("Error");
                    return Redirect("/");
                }
                return View(vm);
            }
            return RedirectToAction("Index", "Login", new { Area = "Account"});
        }
        [Authorize(Roles =("Admin,Moderateur"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePic(PostSettingsViewModel vm) // Suppression de l'image
        {
            IDAL dal = new DAL();
            if (!dal.PostRemovePic(vm.IDpost))
                return View("Error");
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = ("Admin,Moderateur"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(PostSettingsViewModel vm) // Suppression de l'image
        {
            IDAL dal = new DAL();
            if (!dal.DeletePost(vm.IDpost))
                return View("Error");
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = ("Admin,Moderateur"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAutor(PostSettingsViewModel vm) // Ajout d'un collaborateur
        {
            IDAL dal = new DAL();
            dal.AddAutor(vm.IDpost, vm.IDauteur);
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = ("Admin,Moderateur"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAutor(PostSettingsViewModel vm) // Retrait d'un collaborateur
        {
            IDAL dal = new DAL();
            if (dal.DeleteAutor(vm.IDauteur, vm.IDpost))
                return RedirectToAction("Index", "Home");
            return View("Error");
        }
    }
}