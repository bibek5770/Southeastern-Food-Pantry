using SePantry_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SePantry_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            
            ViewBag.Message = "Your contact page.";
            var context = new UsersContext();
            var username = User.Identity.Name;
            var user = context.UserProfiles.SingleOrDefault(u => u.UserName == username);
            ViewBag.Email = user.Email;
            return View();
        }
    }
}
