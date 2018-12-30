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
    public class CommentsController : Controller
    {
        private EFDBcontext db = new EFDBcontext();

        // GET: Administration/Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.ParentComm).Include(c => c.Post).Include(c => c.User);
            return View(comments.ToList());
        }

        // GET: Administration/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Administration/Comments/Create
        public ActionResult Create()
        {
            ViewBag.IDparentComm = new SelectList(db.Comments, "IDcomment", "Title");
            ViewBag.IDpost = new SelectList(db.Posts, "IDpost", "Title");
            ViewBag.IDuser = new SelectList(db.Users, "IDuser", "Login");
            return View();
        }

        // POST: Administration/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDcomment,Title,Body,Date_posted,IDuser,IDpost,IDparentComm")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDparentComm = new SelectList(db.Comments, "IDcomment", "Title", comment.IDparentComm);
            ViewBag.IDpost = new SelectList(db.Posts, "IDpost", "Title", comment.IDpost);
            ViewBag.IDuser = new SelectList(db.Users, "IDuser", "Login", comment.IDuser);
            return View(comment);
        }

        // GET: Administration/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDparentComm = new SelectList(db.Comments, "IDcomment", "Title", comment.IDparentComm);
            ViewBag.IDpost = new SelectList(db.Posts, "IDpost", "Title", comment.IDpost);
            ViewBag.IDuser = new SelectList(db.Users, "IDuser", "Login", comment.IDuser);
            return View(comment);
        }

        // POST: Administration/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDcomment,Title,Body,Date_posted,IDuser,IDpost,IDparentComm")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDparentComm = new SelectList(db.Comments, "IDcomment", "Title", comment.IDparentComm);
            ViewBag.IDpost = new SelectList(db.Posts, "IDpost", "Title", comment.IDpost);
            ViewBag.IDuser = new SelectList(db.Users, "IDuser", "Login", comment.IDuser);
            return View(comment);
        }

        // GET: Administration/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Administration/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
