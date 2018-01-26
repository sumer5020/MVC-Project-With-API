using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jobPortal.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using jobPortal.ViewModelJobSeeker;
using LinkForEmployment.Models;

namespace linkForEmployment.Controllers
{
    public class EmployerInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployerInfoes
        public ActionResult Index()
        {
            return View(db.Employers.ToList());
        }

        // GET: EmployerInfoes/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployerInfo employerInfo = db.Employers.Find(id);
            if (employerInfo == null)
            {
                return HttpNotFound();
            }
            return View(employerInfo);
        }

        // GET: EmployerInfoes/Create
        public ActionResult Create()
        {
            Console.WriteLine("Employer Get Create ");
            EmployerMore ob = new EmployerMore();
            return View(ob);
        }

        // POST: EmployerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployerMore empInfo, HttpPostedFileBase uploadLogo)
        {
            string fileName;
            string fileType;
            int slashIndex;
            var userID = User.Identity.GetUserId(); 

            EmployerInfo BaiscEmployInfo = new EmployerInfo();

            if (ModelState.IsValid)
            {
                fileType = uploadLogo.ContentType;
                slashIndex = fileType.IndexOf('/');
                fileType = fileType.Substring(slashIndex + 1, fileType.Length - slashIndex - 1);
                fileName = userID + "LogoImage" + "." + fileType;
                BaiscEmployInfo.compLogo = fileName;
                BaiscEmployInfo.compLocation = empInfo.compLocation;
                BaiscEmployInfo.Id = userID;
                BaiscEmployInfo.JobTitle = empInfo.JobTitle;
                BaiscEmployInfo.compWorkName = empInfo.compWorkName;
                BaiscEmployInfo.compName = empInfo.compName;
                BaiscEmployInfo.compSize = empInfo.compSize;
                BaiscEmployInfo.receiveApplay = empInfo.receiveApplay;
                BaiscEmployInfo.reportAndUpdate = empInfo.reportAndUpdate;

                string path = Path.Combine(Server.MapPath("~/Uploads"),fileName);
                uploadLogo.SaveAs(path);

                db.Employers.Add(BaiscEmployInfo);
                db.SaveChanges();
                //****************************
                foreach (PhoneNumber item in empInfo.PhoneNumberMore)
                {
                    item.JobSeekerId = userID;
                    db.phoneNumbers.Add(item);
                    db.SaveChanges();
                    
                }
                foreach (WebSite item in empInfo.WebSiteMore)
                {
                    item.JobSeekerId = userID;
                    db.webSites.Add(item);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "jobs");
            }

            return View(empInfo);
        }

        // GET: EmployerInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployerInfo employerInfo = db.Employers.Find(id);
            if (employerInfo == null)
            {
                return HttpNotFound();
            }
            return View(employerInfo);
        }

        // POST: EmployerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,compName,compLocation,compSize,compWorkName,compPhoneNumber,compZipCode,JobTitle,webSite,compLogo,receiveApplay,reportAndUpdate")] EmployerInfo employerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employerInfo);
        }

        // GET: EmployerInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployerInfo employerInfo = db.Employers.Find(id);
            if (employerInfo == null)
            {
                return HttpNotFound();
            }
            return View(employerInfo);
        }

        // POST: EmployerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployerInfo employerInfo = db.Employers.Find(id);
            db.Employers.Remove(employerInfo);
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
