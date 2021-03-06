﻿using Microsoft.AspNet.Identity;
using Pharmacita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacita.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [AllowAnonymous ]
        public ActionResult Index()
        {
            return View(db.Categories .ToList ());
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var drug = db.Drugs.Find(id);
            if (drug ==null)
            {
                return HttpNotFound();
            }
            Session["DrugId"] = drug.Id;
            return View(drug);
        }
        [Authorize ]
        public ActionResult GetDrugsBySeller()
        {
            var UserId = User.Identity.GetUserId();
            var drugs = from app in db.BuyTheDrugs
                       join Drug in db.Drugs
                       on app.DrugId equals Drug.Id 
                       where Drug.User.Id == UserId
                       select app;

            var groubed = from d in drugs
                          group d by d.drug.DrugName
                        into gr
                          select new DrugViewModel
                          {
                              DrugName = gr.Key,
                              Items = gr

                          };
            return View(groubed.ToList());
        }

        [AllowAnonymous ]
        public ActionResult Search(string searchName)
        {
            var result = db.Drugs.Where(a => a.DrugName .Contains(searchName)
             || a.DrugDescribtion .Contains(searchName)
             || a.category .CategoryName .Contains(searchName)
            ).ToList();

            return View(result);
        }
        [Authorize ]
        public ActionResult GetdrugsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var drugs = db.BuyTheDrugs.Where(a => a.UserId == UserId);
            return View(drugs.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var drug = db.BuyTheDrugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }
        // POST: Roles/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(BuyTheDrug Drug)
        {
            try
            {
                // TODO: Add delete logic here
                var mydrug = db.BuyTheDrugs.Find(Drug.Id);
                db.BuyTheDrugs.Remove(mydrug);
                db.SaveChanges();
                return RedirectToAction("GetDrugsByUser");
            }
            catch
            {
                return View(Drug);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Buy()
        {
            ViewBag.Message = "اكتب رسالتك هنا";

            return View();
        }
        [HttpPost ]
        [Authorize ]
        public ActionResult Buy(string Message)
        {

            var UserId = User.Identity.GetUserId();
            var DrugId = (int)Session["DrugId"];
            var check = db.BuyTheDrugs .Where(a => a.DrugId == DrugId && a.UserId == UserId).ToList();
            if (check.Count < 1)
            {

                var drug = new BuyTheDrug();
                drug.DrugId = DrugId;
                drug.UserId = UserId;
                drug.Message = Message;
                drug.BuyDate = DateTime.Now;
                db.BuyTheDrugs.Add(drug);
                db.SaveChanges();
                ViewBag.Result = "تمت اضافة طلبك";
                
            }
            else
            {
                ViewBag.Result = "حدث خطأ إما أنك قد تقدمت بالطلب مسبقا";
            }
            return View();
        }
    }
}