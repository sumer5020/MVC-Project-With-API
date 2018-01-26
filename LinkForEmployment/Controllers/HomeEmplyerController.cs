using LinkForEmployment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkForEmployment.Controllers
{
    public class HomeEmplyerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HomeEmplyer
        public ActionResult Index()
        {
            return View();
        }

        //Get : Search
        public ActionResult Search()
        {
            return View();
        }

        //Post : Search
        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Users.Where(a => a.FirstName.Contains(searchName)
            || a.LastName.Contains(searchName)).ToList();

            return View(result);
        }

    }
}