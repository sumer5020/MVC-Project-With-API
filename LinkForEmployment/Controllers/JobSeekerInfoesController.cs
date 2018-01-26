using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jobPortal.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using jobPortal.ViewModelJobSeeker;
using System.Threading.Tasks;
using LinkForEmployment.Models;

namespace LinkForEmployment.Controllers
{


    public class JobSeekerInfoesController : Controller
    {
        JobSeekerMore h = new JobSeekerMore();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobSeekerInfoes
        public ActionResult Index()
        {
            return View(db.JobSeekerInfoes.ToList());
        }

        // GET: JobSeekerInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeekerInfo jobSeekerInfo = db.JobSeekerInfoes.Find(id);
            if (jobSeekerInfo == null)
            {
                return HttpNotFound();
            }
            return View(jobSeekerInfo);
        }

        // GET: JobSeekerInfoes/Create
        public ActionResult Create()
        {
            ApplicationDbContext db = new ApplicationDbContext();


            var dropdownNationalities = new SelectList(db.NationalityGets.ToList(), "NationalityValue", "NationalityName");
            var dropdownCountries = new SelectList(db.Countries.ToList(), "CountryValue", "CountryName");
            ViewData["countriesList"] = dropdownCountries;
            ViewData["Nationalities"] = dropdownNationalities;
            ViewData["countries_"] = db.Countries.ToList();
            ViewData["nationalities_"] = db.NationalityGets.ToList();

            /*  var countries_List = db.Countries.ToList();
            ViewBag["countriesList"] = countries_List;*/
            JobSeekerMore ob = new JobSeekerMore();
            return View(ob);
        }

        // POST: JobSeekerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //    [ValidateAntiForgeryToken]

        public ActionResult Create(JobSeekerMore AllJobSeekerInfos, HttpPostedFileBase personalPhoto, HttpPostedFileBase[] workCertificate, HttpPostedFileBase[] acadimicCertificate, HttpPostedFileBase[] courseCertificate, HttpPostedFileBase[] examCertificate, HttpPostedFileBase[] voluntaryCertificate)
        {
            HttpPostedFileBase img;
            JobSeekerInfo jobSeekerInfo = new JobSeekerInfo();
            var userID = User.Identity.GetUserId();
            string path;
            string fileName;
            string fileType;
            int slashIndex;
            int i = 0;
            if (ModelState.IsValid)
            {
                i = 0;
                foreach (AcadimicDetail item in AllJobSeekerInfos.MoreAcadimicDetials)
                {
                    img = acadimicCertificate[i];
                    fileType = img.ContentType;
                    slashIndex = fileType.IndexOf('/');
                    fileType = fileType.Substring(slashIndex + 1, fileType.Length - slashIndex - 1);
                    fileName = userID + "acadimicCertificate"+ (i + 1) + "." + fileType;
                    item.acadimicCertificate = fileName;
                    path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    img.SaveAs(path);
                    ++i;
                   
                    item.JobSeekerId = userID;
                    db.AcadimicDetails.Add(item);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ee)
                    {
                        string mes = ee.InnerException.Message;
                        Exception d=new Exception();                       
                        object f  = ee.InnerException.Data;
                        f = ee.InnerException.HelpLink;
                        f = ee.InnerException.HResult;
                        f = ee.InnerException.Source;
                        f = ee.HelpLink;
                        f = ee.HResult;
                        f = ee.Source;
                        f = ee.Data;
                        string tem = ee.StackTrace;
                    }
                }
                i = 0;
                foreach (CourseDetail item in AllJobSeekerInfos.MoreCourseDetials)
                {
                    
                    img = courseCertificate[i];
                    fileType = img.ContentType;
                    slashIndex = fileType.IndexOf('/');
                    fileType = fileType.Substring(slashIndex + 1, fileType.Length - slashIndex - 1);
                    fileName = userID + "CourseCertificate"+(i+1)+"."+fileType;
                    item.courseCertificate = fileName;
                    path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    img.SaveAs(path);
                    ++i;
                    item.JobSeekerId = userID;
                    db.CourseDetails.Add(item);
                    db.SaveChanges();
                }
                i = 0;
                foreach (ExamDetail item in AllJobSeekerInfos.MoreExamDetials)
                {
                    img = examCertificate[i];
                    fileType = img.ContentType;
                    slashIndex = fileType.IndexOf('/');
                    fileType = fileType.Substring(slashIndex + 1, fileType.Length - slashIndex - 1);
                    fileName = userID + "examCertificate"+ (i + 1) + "." + fileType;
                    item.examCertificate = fileName;
                    path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    img.SaveAs(path);
                    ++i;
                    item.JobSeekerId = userID;
                     db.ExamDetails.Add(item);
                    db.SaveChanges();
                }
                foreach (NationalitySet item in AllJobSeekerInfos.nationalitys)
                {
                    item.JobSeekerId = userID;
                    db.NationalitySets.Add(item);
                    db.SaveChanges();
                }
                foreach (Skill item in AllJobSeekerInfos.Skills)
                {
                    item.JobSeekerId = userID;
                    db.Skills.Add(item);
                    db.SaveChanges();
                }
                i = 0;
                foreach (VoluntaryWorkDetail item in AllJobSeekerInfos.MoreVoluntaryWorkDetials)
                {
                    img = voluntaryCertificate[i];
                    fileType = img.ContentType;
                    slashIndex = fileType.IndexOf('/');
                    fileType = fileType.Substring(slashIndex + 1, fileType.Length - slashIndex - 1);
                    fileName = userID + "voluntaryCertificate" + (i + 1) + "." + fileType;
                    item.voluntaryCertificate = fileName;
                    path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    img.SaveAs(path);
                    ++i;
                    item.JobSeekerId = userID;
                    db.VoluntaryWorkDetails.Add(item);
                    db.SaveChanges();
                }
                i = 0;
                foreach (WorkDetail item in AllJobSeekerInfos.MoreWorkDetails)
                {
                    img = workCertificate[i];
                    fileType = img.ContentType;
                    slashIndex = fileType.IndexOf('/');
                    fileType=fileType.Substring(slashIndex + 1, fileType.Length - slashIndex - 1);
                    fileName = userID + "workCertificate" + (i + 1) + "." + fileType;
                    item.workCertificate = fileName;
                    path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    img.SaveAs(path);
                    ++i;
                    item.JobSeekerId = userID;
                    db.WorkDetails.Add(item);
                    db.SaveChanges();

                }

                fileType = personalPhoto.ContentType;
                slashIndex = fileType.IndexOf('/');
                fileType = fileType.Substring(slashIndex + 1, fileType.Length - slashIndex - 1);

                fileName = userID + "PersonalPhoto"+"."+ fileType;
                jobSeekerInfo.Id = userID;
                jobSeekerInfo.bornDate = AllJobSeekerInfos.bornDate;
                jobSeekerInfo.city = AllJobSeekerInfos.city;
                jobSeekerInfo.country = AllJobSeekerInfos.country;
                jobSeekerInfo.countryCode = AllJobSeekerInfos.countryCode;
                jobSeekerInfo.dreamJobLocation = AllJobSeekerInfos.dreamJobLocation;
                jobSeekerInfo.dreamJobTitle = AllJobSeekerInfos.dreamJobTitle;
                jobSeekerInfo.Email = AllJobSeekerInfos.Email;
                jobSeekerInfo.experienceLevels = AllJobSeekerInfos.experienceLevels;
                jobSeekerInfo.firstName = AllJobSeekerInfos.firstName;
                jobSeekerInfo.gender = AllJobSeekerInfos.gender;
                jobSeekerInfo.isVoluntaryWork = AllJobSeekerInfos.isVoluntaryWork;
                jobSeekerInfo.isYouWork = AllJobSeekerInfos.isYouWork;
                jobSeekerInfo.jobField = AllJobSeekerInfos.jobField;
                jobSeekerInfo.jobTime = AllJobSeekerInfos.jobTime;
                jobSeekerInfo.lastName = AllJobSeekerInfos.lastName;
                jobSeekerInfo.middleName = AllJobSeekerInfos.middleName;

                jobSeekerInfo.personalPhoto = fileName;
                path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                personalPhoto.SaveAs(path);

                jobSeekerInfo.phoneNumber = AllJobSeekerInfos.phoneNumber;
                jobSeekerInfo.socialStatus = AllJobSeekerInfos.socialStatus;
                jobSeekerInfo.street = AllJobSeekerInfos.street;

                db.JobSeekerInfoes.Add(jobSeekerInfo);
                db.SaveChanges();

                return RedirectToAction("Index", "HomeJobSeeker");
            }

            return View(jobSeekerInfo);
        }

        // GET: JobSeekerInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeekerInfo jobSeekerInfo = db.JobSeekerInfoes.Find(id);
            if (jobSeekerInfo == null)
            {
                return HttpNotFound();
            }
            return View(jobSeekerInfo);
        }

        // POST: JobSeekerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstName,middleName,lastName,bornDate,gender,personalPhoto,nationality,country,city,street,socialStatus,phoneNumber,countryCode,Email,dreamJobTitle,jobField,experienceLevels,dreamJobLocation,jobTime,isYouWork,workStartDate,workEndDate,iWorkNow,workLocation,compName,compWork,compField,workTitle,workDescribe,workCertificate,acadimicName,acadimicType,acadimicTitle,acadimicEndDate,acadimicCountry,acadimicCity,acadimicCertificate,courseTitle,courseCertificate,examTitle,examCertificate,isVoluntaryWork,voluntaryWorkTitle,voluntaryWorkStartDate,voluntaryWorkEndDate,voluntaryWorkDescribe,voluntaryCertificate,skill")] JobSeekerInfo jobSeekerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSeekerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobSeekerInfo);
        }

        // GET: JobSeekerInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeekerInfo jobSeekerInfo = db.JobSeekerInfoes.Find(id);
            if (jobSeekerInfo == null)
            {
                return HttpNotFound();
            }
            return View(jobSeekerInfo);
        }

        // POST: JobSeekerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobSeekerInfo jobSeekerInfo = db.JobSeekerInfoes.Find(id);
            db.JobSeekerInfoes.Remove(jobSeekerInfo);
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
