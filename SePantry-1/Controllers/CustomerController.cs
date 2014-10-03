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
    public class CustomerController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Customer/

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
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
            var customer = from s in db.Customers
                          select s;
            //sorting data
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstName" : "";
            ViewBag.NameSortParm1 = String.IsNullOrEmpty(sortOrder) ? "lastName" : "";
            ViewBag.NameSortParm2 = String.IsNullOrEmpty(sortOrder) ? "emailAddress" : "";
            ViewBag.NameSortParm3 = String.IsNullOrEmpty(sortOrder) ? "wNumber" : "";
            ViewBag.NameSortParm4 = String.IsNullOrEmpty(sortOrder) ? "passwrord" : "";
            switch (sortOrder)
            {
                case "firstName":
                    customer = customer.OrderBy(s => s.firstName);
                    break;
                case "lastName":
                    customer = customer.OrderBy(s => s.lastName);
                    break;
                case "emailAddress":
                    customer = customer.OrderBy(s => s.emailAddress);
                    break;
                case "wNumber":
                    customer = customer.OrderBy(s => s.wNumber);
                    break;
                case "password":
                    customer = customer.OrderBy(s => s.password);
                    break;
                default:
                    customer = customer.OrderBy(s => s.firstName);
                    break;
            }
            //end of sorting
            //for searching data

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();//ignore white space
                customer = customer.Where(s => s.firstName.Contains(searchString)
                        || s.lastName.Contains(searchString)
                         || s.emailAddress.Contains(searchString)
                           || s.wNumber.Contains(searchString));
            }


            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(customer.ToPagedList(pageNumber, pageSize));
            
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //
        // GET: /Customer/Edit/5
        
        public ActionResult Edit(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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