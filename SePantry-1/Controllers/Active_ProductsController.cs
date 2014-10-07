using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SePantry_1.Models;
using PagedList;
using PagedList.Mvc;


namespace SePantry_1.Controllers
{
    public class Active_ProductsController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Active_Products/

        public ActionResult Index(string sortOrder,string searchString,string currentFilter,int? page)
        {
            //paging
            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var product = from s in db.Active_Products
                          select s;
            //sorting data
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "category" : "";
            ViewBag.NameSortParm1 = String.IsNullOrEmpty(sortOrder) ? "title": "";
            ViewBag.NameSortParm2 = String.IsNullOrEmpty(sortOrder) ? "manufacturer" : "";
            ViewBag.NameSortParm3 = String.IsNullOrEmpty(sortOrder) ? "isCanned" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            switch (sortOrder)
            {
                case "category":
                    product = product.OrderBy(s => s.category);
                    break;
                case "title":
                    product = product.OrderBy(s => s.title);
                    break;
                case "manufacturer":
                    product = product.OrderBy(s => s.manufacturer);
                    break;
                case "isCanned":
                    product = product.OrderBy(s => s.isCanned);
                    break;
                default:
                    product = product.OrderBy(s => s.category);
                    break;
            }
            //end of sorting
           
            //for searching data
            
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();//ignore white space
                product = product.Where(s => s.category.Contains(searchString)
                        || s.title.Contains(searchString)
                         || s.manufacturer.Contains(searchString));
            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(product.ToPagedList(pageNumber, pageSize));
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
                db.Entry(active_product).State = System.Data.Entity.EntityState.Modified;
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