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
    public class Active_ProductsController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Active_Products/

        public ActionResult Index()
        {
            return View(db.Active_Products.ToList());
        }

        //
        // GET: /Active_Products/Details/5

        public ActionResult Details(int id = 0)
        {
            Active_Product active_product = db.Active_Products.Find(id);
            if (active_product == null)
            {
                return HttpNotFound();
            }
            return View(active_product);
        }

        //
        // GET: /Active_Products/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Active_Products/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Active_Product active_product)
        {
            if (ModelState.IsValid)
            {
                db.Active_Products.Add(active_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(active_product);
        }

        //
        // GET: /Active_Products/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Active_Product active_product = db.Active_Products.Find(id);
            if (active_product == null)
            {
                return HttpNotFound();
            }
            return View(active_product);
        }

        //
        // POST: /Active_Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Active_Product active_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(active_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(active_product);
        }

        //
        // GET: /Active_Products/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Active_Product active_product = db.Active_Products.Find(id);
            if (active_product == null)
            {
                return HttpNotFound();
            }
            return View(active_product);
        }

        //
        // POST: /Active_Products/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Active_Product active_product = db.Active_Products.Find(id);
            db.Active_Products.Remove(active_product);
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