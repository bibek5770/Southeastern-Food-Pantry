using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SePantry_1.Models;

namespace SePantry_1.Controllers
{
    public class DonorModelsController : Controller
    {
        private UsersContext db = new UsersContext();

        // GET: DonorModels
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View(db.Donors.ToList());
        }

        // GET: DonorModels/Details/5
         [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorModel donorModel = db.Donors.Find(id);
            if (donorModel == null)
            {
                return HttpNotFound();
            }
            return View(donorModel);
        }
         [Authorize(Roles = "Admin")]
        // GET: DonorModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonorModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,Date,category,title,isCanned,product_code")] DonorModel donorModel)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(donorModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donorModel);
        }

        // GET: DonorModels/Edit/5 
        [Authorize(Roles="Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorModel donorModel = db.Donors.Find(id);
            if (donorModel == null)
            {
                return HttpNotFound();
            }
            return View(donorModel);
        }

        // POST: DonorModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,Date,category,title,isCanned,product_code")] DonorModel donorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donorModel);
        }

        // GET: DonorModels/Delete/5
         [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorModel donorModel = db.Donors.Find(id);
            if (donorModel == null)
            {
                return HttpNotFound();
            }
            return View(donorModel);
        }

        // POST: DonorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            DonorModel donorModel = db.Donors.Find(id);
            db.Donors.Remove(donorModel);
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
