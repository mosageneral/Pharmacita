using Microsoft.AspNet.Identity.EntityFramework;
using Pharmacita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacita.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Roles .ToList ());
        }

        // GET: Roles/Details/5
      

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid )
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
       
        public ActionResult Delete(string id)
        {
         var role=   db.Roles.Find(id);
            if (role==null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, IdentityRole role)
        {
            try
            {

                // TODO: Add delete logic here
                var findrole = db.Roles.Find(id);
                db.Roles.Remove(findrole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ex = ex;
                return View();
            }
        }
    }
}
