using Postal;
using SePantry_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace SePantry_1.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }
        
        
        // GET: /Account/Register
        [Authorize(Roles = "Admin")]
      
        public ActionResult MassEmail()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]

        public ActionResult MassEmail(string subject, string message)
        {
           
                using (var ctx = new UsersContext())
                {
                    var model = new MailModel();
                    //var customer = ctx.UserProfiles.ToList();
                    model.UserProfiles = ctx.UserProfiles.ToList();

                    foreach (var models in model.UserProfiles)
                    {
                        dynamic email = new Email("RegEMail");
                        email.To = models.Email;
                        email.UserName = models.UserName;
                        email.FirstName = models.FirstName;
                        email.isBodyHtml = true;
                        
                        email.message = message;

                        email.subject = subject;
                        email.Send();
                    };
                }
            
            return RedirectToAction("EmailSendSuccess", "Email");
        }
        public ActionResult EmailSendSuccess ()
        {
            return View();

        }
        public ActionResult RegisterStepTwo()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterConfirmation(string Id)
        {
            if (String.IsNullOrEmpty(Id))
            {
                return View();
            }
            //UsersContext db = new UsersContext();
            //UserProfile userProfile = db.UserProfiles.Find(Id);

            if (WebSecurity.ConfirmAccount(Id))
            {
                return RedirectToAction("ConfirmationSuccess", "ACcount");
            }
            return RedirectToAction("ConfirmationFailure","Account");

        }
       

    }
}