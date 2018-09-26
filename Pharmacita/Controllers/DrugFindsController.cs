using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharmacita.Models;
using Microsoft.AspNet.Identity;

namespace Pharmacita.Controllers
{
    public class DrugFindsController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
         [Authorize]
        // GET: DrugFinds
        public ActionResult Index()
        {
            return View(db.DrugFinds.ToList());
        }

        // GET: DrugFinds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugFind drugFind = db.DrugFinds.Find(id);
            if (drugFind == null)
            {
                return HttpNotFound();
            }
            return View(drugFind);
        }

        // GET: DrugFinds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugFinds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DrugName,DrugDescribtion,Quantity")] DrugFind drugFind)
        {
            if (ModelState.IsValid)
            {
                drugFind.UserId = User.Identity.GetUserId();
                db.DrugFinds.Add(drugFind);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drugFind);
        }

        // GET: DrugFinds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugFind drugFind = db.DrugFinds.Find(id);
            if (drugFind == null)
            {
                return HttpNotFound();
            }
            return View(drugFind);
        }

        // POST: DrugFinds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DrugName,DrugDescribtion,Quantity")] DrugFind drugFind)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drugFind).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drugFind);
        }

        // GET: DrugFinds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugFind drugFind = db.DrugFinds.Find(id);
            if (drugFind == null)
            {
                return HttpNotFound();
            }
            return View(drugFind);
        }

        // POST: DrugFinds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrugFind drugFind = db.DrugFinds.Find(id);
            db.DrugFinds.Remove(drugFind);
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
