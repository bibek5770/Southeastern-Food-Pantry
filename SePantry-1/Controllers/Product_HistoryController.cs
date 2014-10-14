using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SePantry_1.Models;

namespace SePantry_1.Controllers
{
    public class Product_HistoryController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Product_History/
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View(db.Product_Historys.ToList());
        }

        //
        // GET: /Product_History/Details/5

        public ActionResult Details(int id = 0)
        {
            Product_History product_history = db.Product_Historys.Find(id);
            if (product_history == null)
            {
                return HttpNotFound();
            }
            return View(product_history);
        }

        //
        // GET: /Product_History/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product_History/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product_History product_history)
        {
            if (ModelState.IsValid)
            {
                db.Product_Historys.Add(product_history);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_history);
        }

        //
        // GET: /Product_History/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product_History product_history = db.Product_Historys.Find(id);
            if (product_history == null)
            {
                return HttpNotFound();
            }
            return View(product_history);
        }

        //
        // POST: /Product_History/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product_History product_history)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_history).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_history);
        }

        //
        // GET: /Product_History/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product_History product_history = db.Product_Historys.Find(id);
            if (product_history == null)
            {
                return HttpNotFound();
            }
            return View(product_history);
        }

        //
        // POST: /Product_History/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_History product_history = db.Product_Historys.Find(id);
            db.Product_Historys.Remove(product_history);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}