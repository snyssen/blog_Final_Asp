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
    public class Access_lvlController : Controller
    {
        private EFDBcontext db = new EFDBcontext();

        // GET: Administration/Access_lvl
        public ActionResult Index()
        {
            return View(db.Access_lvls.ToList());
        }

        // GET: Administration/Access_lvl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_lvl access_lvl = db.Access_lvls.Find(id);
            if (access_lvl == null)
            {
                return HttpNotFound();
            }
            return View(access_lvl);
        }

        // GET: Administration/Access_lvl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Access_lvl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDaccess_lvl,Role")] Access_lvl access_lvl)
        {
            if (ModelState.IsValid)
            {
                db.Access_lvls.Add(access_lvl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(access_lvl);
        }

        // GET: Administration/Access_lvl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_lvl access_lvl = db.Access_lvls.Find(id);
            if (access_lvl == null)
            {
                return HttpNotFound();
            }
            return View(access_lvl);
        }

        // POST: Administration/Access_lvl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDaccess_lvl,Role")] Access_lvl access_lvl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(access_lvl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(access_lvl);
        }

        // GET: Administration/Access_lvl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_lvl access_lvl = db.Access_lvls.Find(id);
            if (access_lvl == null)
            {
                return HttpNotFound();
            }
            return View(access_lvl);
        }

        // POST: Administration/Access_lvl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Access_lvl access_lvl = db.Access_lvls.Find(id);
            db.Access_lvls.Remove(access_lvl);
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
