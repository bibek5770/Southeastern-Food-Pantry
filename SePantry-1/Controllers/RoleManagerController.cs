using SePantry_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SePantry_1.Controllers
{
    public class RoleManagerController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: RoleManager
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RoleCreate()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleCreate(string RoleName)
        {
            if (!string.IsNullOrWhiteSpace(RoleName))
            {
                Roles.CreateRole(Request.Form["RoleName"]);
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("RoleIndex", "RoleManager");
            }
            ViewBag.ResultMessage = "Error!! Please enter a Valid name";
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RoleIndex()
        {
            var roles = Roles.GetAllRoles();
            
            return View(roles);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {

            if (Roles.IsUserInRole(UserName, RoleName))
            {
                Roles.RemoveUserFromRole(UserName, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "Error!!This user doesn't belong to selected role.";
            }
            ViewBag.RolesForThisUser = Roles.GetRolesForUser(UserName);
            SelectList list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;


            return View("RoleAddToUser");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RoleAddToUser()
        {
            SelectList list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string RoleName, string UserName)
        {
            if ((Roles.IsUserInRole(UserName, "User")|| (Roles.IsUserInRole(UserName, "Admin"))))
            {
                if (Roles.IsUserInRole(UserName, RoleName))
                {
                    ViewBag.ResultMessage = "Error!!This user already has the role specified !";
                }
                else
                {
                    Roles.AddUserToRole(UserName, RoleName);
                    ViewBag.ResultMessage = "Username added to the role succesfully !";
                }
            
             }
            else
            {
                ViewBag.ResultMessage = "Error!!Given UserName doesn't exist";
            }
            SelectList list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;
            return View();
        }
      
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            SelectList list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                if ((Roles.IsUserInRole(UserName, "User") || (Roles.IsUserInRole(UserName, "Admin"))))
                {
                    ViewBag.RolesForThisUser = Roles.GetRolesForUser(UserName);
                    
                }
            }
            else
            {
                ViewBag.ResultMessage = "Error!! Given UserName doesn't exist";
                return View("RoleAddToUser");
            }
             return View("RoleAddToUser");
        }


    }
}