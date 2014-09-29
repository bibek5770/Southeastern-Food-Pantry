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
    public class Product_DetailController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Product_Detail/

        public ActionResult Index()
        {
            return View(db.Product_Details.ToList());
        }

        //
        // GET: /Product_Detail/Details/5

        public ActionResult Details(int id = 0)
        {
            Product_Detail product_detail = db.Product_Details.Find(id);
            if (product_detail == null)
            {
                return HttpNotFound();
            }
            return View(product_detail);
        }

        //
        // GET: /Product_Detail/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product_Detail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product_Detail product_detail)
        {
            if (ModelState.IsValid)
            {
                db.Product_Details.Add(product_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_detail);
        }

        //
        // GET: /Product_Detail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product_Detail product_detail = db.Product_Details.Find(id);
            if (product_detail == null)
            {
                return HttpNotFound();
            }
            return View(product_detail);
        }

        //
        // POST: /Product_Detail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product_Detail product_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_detail);
        }

        //
        // GET: /Product_Detail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product_Detail product_detail = db.Product_Details.Find(id);
            if (product_detail == null)
            {
                return HttpNotFound();
            }
            return View(product_detail);
        }

        //
        // POST: /Product_Detail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Detail product_detail = db.Product_Details.Find(id);
            db.Product_Details.Remove(product_detail);
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