using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinkForEmployment.Models;
using jobPortal.Models;

namespace LinkForEmployment.Controllers
{
    public class NationalityGetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NationalityGets
        public ActionResult Index()
        {
            return View(db.NationalityGets.ToList());
        }

        // GET: NationalityGets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NationalityGet nationalityGet = db.NationalityGets.Find(id);
            if (nationalityGet == null)
            {
                return HttpNotFound();
            }
            return View(nationalityGet);
        }

        // GET: NationalityGets/Create
        public ActionResult Create()
        {
            string name;
            string value;
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Eng. Abdalmajeed\Desktop\Github\Nationality.txt");
            NationalityGet counr;
            while ((line = file.ReadLine()) != null)
            {
                int slashIndex = line.IndexOf("/");
                value = line.Substring(0, slashIndex);
                name = line.Substring(slashIndex + 1, line.Length - slashIndex - 1);
                counr = new NationalityGet();
                counr.NationalityValue = value;
                counr.NationalityName = name;
                db.NationalityGets.Add(counr);
                db.SaveChanges();
            }

            file.Close();
            return View();
        }

        // POST: NationalityGets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NationalityValue,NationalityName")] NationalityGet nationalityGet)
        {
            if (ModelState.IsValid)
            {
                db.NationalityGets.Add(nationalityGet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nationalityGet);
        }

        // GET: NationalityGets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NationalityGet nationalityGet = db.NationalityGets.Find(id);
            if (nationalityGet == null)
            {
                return HttpNotFound();
            }
            return View(nationalityGet);
        }

        // POST: NationalityGets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NationalityValue,NationalityName")] NationalityGet nationalityGet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nationalityGet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nationalityGet);
        }

        // GET: NationalityGets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NationalityGet nationalityGet = db.NationalityGets.Find(id);
            if (nationalityGet == null)
            {
                return HttpNotFound();
            }
            return View(nationalityGet);
        }

        // POST: NationalityGets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NationalityGet nationalityGet = db.NationalityGets.Find(id);
            db.NationalityGets.Remove(nationalityGet);
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
