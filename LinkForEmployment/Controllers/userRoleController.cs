using LinkForEmployment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace LinkForEmployment.Controllers
{
    public class userRoleController : Controller
    {
        ApplicationDbContext db;
        //GET: userRole
        public ActionResult Index()
        {
            return View();
        }
        // Post: userRole
        [HttpPost]
        public ActionResult Index(string userType)
        {
            db = new ApplicationDbContext();
            var userID = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(a => a.Id == userID).SingleOrDefault();
            if (userType == "باحث عن وظيفة")
            {
                CurrentUser.UserType = "باحث عن وظيفة";
                db.SaveChanges();

                return RedirectToAction("Create", "JobSeekerInfoes");
            }
            else
            {
                CurrentUser.UserType = "مزود وظائف";
                db.SaveChanges();
                return RedirectToAction("Create", "EmployerInfoes");
            }

        }

    }
}