using Pharmacita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacita.Controllers
{
    [Authorize(Roles = "Admins")]
    public class UsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        

      

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
           
          var user=   db.Users.Where(a => a.Id == id).FirstOrDefault();
            if (user!=null)
            {
                return View(user);
            }
            return HttpNotFound();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(string id,ApplicationUser user)
        {
            try
            {
                // TODO: Add delete logic here
                user = db.Users.Where(a => a.Id == id).FirstOrDefault();
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.ToString());
            }
        }
    }
}
