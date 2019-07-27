using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharmacita.Models;

namespace Pharmacita.Controllers
{
    public class NewsCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewsCategories
        public ActionResult Index()
        {
            return View(db.NewsCategories.ToList());
        }

        // GET: NewsCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategories newsCategories = db.NewsCategories.Find(id);
            if (newsCategories == null)
            {
                return HttpNotFound();
            }
            return View(newsCategories);
        }

        // GET: NewsCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] NewsCategories newsCategories)
        {
            if (ModelState.IsValid)
            {
                db.NewsCategories.Add(newsCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsCategories);
        }

        // GET: NewsCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategories newsCategories = db.NewsCategories.Find(id);
            if (newsCategories == null)
            {
                return HttpNotFound();
            }
            return View(newsCategories);
        }

        // POST: NewsCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] NewsCategories newsCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsCategories);
        }

        // GET: NewsCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategories newsCategories = db.NewsCategories.Find(id);
            if (newsCategories == null)
            {
                return HttpNotFound();
            }
            return View(newsCategories);
        }

        // POST: NewsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsCategories newsCategories = db.NewsCategories.Find(id);
            db.NewsCategories.Remove(newsCategories);
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
