using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharmacita.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace Pharmacita.Controllers
{
    public class DrugsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Drugs
        public ActionResult Index()
        {
            var drugs = db.Drugs.Include(d => d.category);
            return View(drugs.ToList());
        }

        // GET: Drugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        // GET: Drugs/Create
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Drugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Drug drug, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/upload"), upload.FileName);
                upload.SaveAs(path);
                drug.DrugImage = upload.FileName;
                drug.UserId = User.Identity.GetUserId();
                db.Drugs.Add(drug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryId = new SelectList(db.Categories, "Id", "CategoryName", drug.categoryId);
            return View(drug);
        }

        // GET: Drugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryId = new SelectList(db.Categories, "Id", "CategoryName", drug.categoryId);
            return View(drug);
        }

        // POST: Drugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DrugName,DrugDescribtion,Quantity,DrugImage,Expire,Off,categoryId")] Drug drug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = new SelectList(db.Categories, "Id", "CategoryName", drug.categoryId);
            return View(drug);
        }

        // GET: Drugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        // POST: Drugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drug drug = db.Drugs.Find(id);
            db.Drugs.Remove(drug);
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
