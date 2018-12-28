using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Blog_final_Asp.Models;

namespace Blog_final_Asp.Areas.Administration.Controllers
{
    public class UsersController : Controller
    {
        private EFDBcontext db = new EFDBcontext();

        // GET: Administration/Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Access_Lvl);
            return View(users.ToList());
        }

        // GET: Administration/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Administration/Users/Create
        public ActionResult Create()
        {
            ViewBag.IDaccess_lvl = new SelectList(db.Access_lvls, "IDaccess_lvl", "Role");
            return View();
        }

        // POST: Administration/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDuser,Login,Mail,Password,IDaccess_lvl,Profile_pic")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Crypto.SHA256(user.Password);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDaccess_lvl = new SelectList(db.Access_lvls, "IDaccess_lvl", "Role", user.IDaccess_lvl);
            return View(user);
        }

        // GET: Administration/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDaccess_lvl = new SelectList(db.Access_lvls, "IDaccess_lvl", "Role", user.IDaccess_lvl);
            return View(user);
        }

        // POST: Administration/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDuser,Login,Mail,Password,IDaccess_lvl,Profile_pic")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Crypto.SHA256(user.Password);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDaccess_lvl = new SelectList(db.Access_lvls, "IDaccess_lvl", "Role", user.IDaccess_lvl);
            return View(user);
        }

        // GET: Administration/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Administration/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
