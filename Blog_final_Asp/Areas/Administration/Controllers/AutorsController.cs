using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog_final_Asp.Models;

namespace Blog_final_Asp.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AutorsController : Controller
    {
        private EFDBcontext db = new EFDBcontext();

        // GET: Administration/Autors
        public ActionResult Index()
        {
            var autors = db.Autors.Include(a => a.Post).Include(a => a.User);
            return View(autors.ToList());
        }

        // GET: Administration/Autors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autors.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // GET: Administration/Autors/Create
        public ActionResult Create()
        {
            ViewBag.IDpost = new SelectList(db.Posts, "IDpost", "Title");
            ViewBag.IDuser = new SelectList(db.Users, "IDuser", "Login");
            return View();
        }

        // POST: Administration/Autors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDautor,IDuser,IDpost")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Autors.Add(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDpost = new SelectList(db.Posts, "IDpost", "Title", autor.IDpost);
            ViewBag.IDuser = new SelectList(db.Users, "IDuser", "Login", autor.IDuser);
            return View(autor);
        }

        // GET: Administration/Autors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autors.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDpost = new SelectList(db.Posts, "IDpost", "Title", autor.IDpost);
            ViewBag.IDuser = new SelectList(db.Users, "IDuser", "Login", autor.IDuser);
            return View(autor);
        }

        // POST: Administration/Autors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDautor,IDuser,IDpost")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDpost = new SelectList(db.Posts, "IDpost", "Title", autor.IDpost);
            ViewBag.IDuser = new SelectList(db.Users, "IDuser", "Login", autor.IDuser);
            return View(autor);
        }

        // GET: Administration/Autors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autors.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // POST: Administration/Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autor autor = db.Autors.Find(id);
            db.Autors.Remove(autor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
