using LinkForEmployment.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LinkForEmployment.Controllers
{
    public class HomeJobSeekerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HomeJobSeeker
        public ActionResult Index()
        {
            return View(db.jobs.ToList());
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
            var result = db.jobs.Where(a => a.jobName.Contains(searchName)
            || a.country.Contains(searchName)
            || a.city.Contains(searchName)
            || a.street.Contains(searchName)
            || a.applayConditions.Contains(searchName)
            || a.jobDescrib.Contains(searchName)).ToList();

            return View(result);
        }
        // GET: Search/Details/5
        public ActionResult SearchDetails(int? JobId)
        {
            if (JobId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = db.jobs.Find(JobId);
            if (job == null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = JobId;
            return View(job);
        }

        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(string isApply)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];

            var check = db.ApplyForJobs.Where(a => a.JobId == JobId && a.UserId == UserId).ToList();

            if (check.Count < 1)
            {
                var job = new ApplyForJob();

                job.UserId = UserId;
                job.JobId = JobId;
                job.ApplyDate = DateTime.Now;

                db.ApplyForJobs.Add(job);
                db.SaveChanges();
                ViewBag.Result = "تم التقدم بنجاح!";

            }
            else
            {
                ViewBag.Result = "المعذرة لقد سبق وتقدمت الى نفس الوظيفة في وقت سابق!";
            }
            return View();

        }

        [Authorize]
        public ActionResult GetJobsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var Jobs = db.ApplyForJobs.Where(a => a.UserId == UserId);
            return View(Jobs.ToList());
        }

        [Authorize]
        // GET: Job/Details/5
        public ActionResult DetailsOfJob(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Delete
        [HttpPost]
        public ActionResult Delete(ApplyForJob job)
        {

            // TODO: Add delete logic here
            var myJob = db.ApplyForJobs.Find(job.Id);
            db.ApplyForJobs.Remove(myJob);
            db.SaveChanges();
            return RedirectToAction("GetJobsByUser");

        }

    }
}
