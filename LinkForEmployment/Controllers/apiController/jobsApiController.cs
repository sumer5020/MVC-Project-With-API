using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LinkForEmployment.Models;
using Microsoft.AspNet.Identity;

namespace LinkForEmployment.Controllers.apiController
{
    public class jobsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/jobsApi/ForCurrentUser
        [Authorize]
        [Route("api/jobsApi/ForCurrentUser")]
        public IQueryable<job> GetjobsForCurrentUser()
        {
            string userId = User.Identity.GetUserId();

            return db.jobs.Where(job => job.UserId == userId);
        }

        // GET: api/jobsApi
        [Authorize]
        public IQueryable<job> Getjobs()
        {
            return db.jobs;
        }

        // GET: api/jobsApi/5
        [ResponseType(typeof(job))]
        [Authorize]
        public IHttpActionResult Getjob(int id)
        {
            job job = db.jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/jobsApi/5
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult Putjob(int id, job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.Id)
            {
                return BadRequest();
            }
            var userId = User.Identity.GetUserId();

            if (userId != job.UserId)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }

            db.Entry(job).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // POST: api/jobsApi
        [ResponseType(typeof(job))]
        [Authorize]
        public IHttpActionResult Postjob(job Job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = User.Identity.GetUserId();
            Job.UserId = userId;

            db.jobs.Add(Job);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = Job.Id }, Job);
        }

        // DELETE: api/jobsApi/5
        [ResponseType(typeof(job))]
        [Authorize]
        public IHttpActionResult Deletejob(int id)
        {
            job job = db.jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }
            string userId = User.Identity.GetUserId();
            if (userId != job.UserId)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }

            db.jobs.Remove(job);
            db.SaveChanges();

            return Ok(job);
        }

        //Get: api/jobsApi/Search/{keyword}
        [Authorize]
        [Route("api/jobsApi/Search/{keyword}")]
        [HttpGet]
        public IQueryable<job> SearchIdeas(string keyword)
        {
            return db.jobs
                .Where(jobs => jobs.jobName.Contains(keyword)
                || jobs.country.Contains(keyword)
                || jobs.jobDescrib.Contains(keyword)
                || jobs.applayConditions.Contains(keyword));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool jobExists(int id)
        {
            return db.jobs.Count(e => e.Id == id) > 0;
        }
    }
}