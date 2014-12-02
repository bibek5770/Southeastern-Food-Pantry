using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SePantry_1.Models;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace SePantry_1.Controllers
{
    public class UserProfilesController : Controller
    {
        private UsersContext db = new UsersContext();

        [Authorize(Roles = "admin")]
        // GET: UserProfiles
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
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
                var customer = from s in db.UserProfiles
                               select s;
                //sorting data
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "UserName" : "";
                ViewBag.NameSortParm1 = String.IsNullOrEmpty(sortOrder) ? "FirstName" : "";
                ViewBag.NameSortParm2 = String.IsNullOrEmpty(sortOrder) ? "LastName" : "";
                ViewBag.NameSortParm3 = String.IsNullOrEmpty(sortOrder) ? "Email" : "";
                ViewBag.NameSortParm4 = String.IsNullOrEmpty(sortOrder) ? "WNumber" : "";
                // ViewBag.NameSortParm4 = String.IsNullOrEmpty(sortOrder) ? "passwrord" : "";
                switch (sortOrder)
                {
                    case "firstName":
                        customer = customer.OrderBy(s => s.UserName);
                        break;
                    case "lastName":
                        customer = customer.OrderBy(s => s.FirstName);
                        break;
                    case "emailAddress":
                        customer = customer.OrderBy(s => s.LastName);
                        break;
                    case "wNumber":
                        customer = customer.OrderBy(s => s.Email);
                        break;
                    case "WNumber":
                        customer = customer.OrderBy(s => s.WNumber);
                        break;
                    default:
                        customer = customer.OrderBy(s => s.FirstName);
                        break;
                }
                //end of sorting
                //for searching data

                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.Trim();//ignore white space
                    customer = customer.Where(s => s.UserName.Contains(searchString)
                            || s.FirstName.Contains(searchString)
                             || s.LastName.Contains(searchString)
                               || s.Email.Contains(searchString)
                               || s.WNumber.Contains(searchString)); ;
                }


                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(customer.ToPagedList(pageNumber, pageSize));
                //return View(db.UserProfiles.ToList());
            }
        }
        [Authorize(Roles = "admin")]
        // GET: UserProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }
        [Authorize(Roles = "admin")]
        // GET: UserProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,FirstName,LastName,Email,WNumber")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "UserId,UserName,FirstName,LastName,Email,WNumber")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tmpuser = "";
            var ctx = new UsersContext();
            using (ctx)
            {
                var firstOrDefault = ctx.UserProfiles.FirstOrDefault(us => us.UserId == id);
                if (firstOrDefault != null)
                    tmpuser = firstOrDefault.UserName;
            }

            string[] allRoles = Roles.GetRolesForUser(tmpuser);
            Roles.RemoveUserFromRoles(tmpuser, allRoles);

            //Roles.RemoveUserFromRole(tmpuser, "RoleName");

            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(tmpuser);
            Membership.Provider.DeleteUser(tmpuser, true);
            Membership.DeleteUser(tmpuser, true);
            //UserProfile userProfile = db.UserProfiles.Find(id);
            
            ////webpages_UsersInRoles webpages_UsersInRoles = db.webpages_UsersInRoles.Find(id);
            //db.UserProfiles.Remove(userProfile);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult autocomplete_users(string keyword)
        {
            return Json(getUsers(keyword), JsonRequestBehavior.AllowGet);
        }

        public List<UserProfile> getUsers(string keyword)
        {
            return (
               from u in db.UserProfiles
               select u
               ).ToList();
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
