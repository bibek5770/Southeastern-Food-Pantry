using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SePantry_1.Models;
using System.Data;
using System.Data.Entity;

namespace SePantry_1.Controllers
{
    public class AdminDashboardController : Controller
    {

        private UsersContext db = new UsersContext();

        // GET: AdminDashboard
        public ActionResult Index()
        {
            //Let the authorized admin view the Dashboard
            if (Roles.GetRolesForUser().Contains("Admin"))
            {
                return View();
            }
            else
            {
                //Redirect the non-authorized users to homepage
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: /Active_Products/Create
        [Authorize(Roles = "admin")]
        public ActionResult CreateProducts()
        {
            return View();
        }

        //
        // POST: /Active_Products/Create

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProducts(Active_Product active_product)
        {
            if (ModelState.IsValid)
            {
                db.Active_Products.Add(active_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(active_product);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Search_Inventory()
        {
            if (!string.IsNullOrEmpty(Request.Form["search-inventory"]))
            {
                
            }
            return View();
        }
    }
}