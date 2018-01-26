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
using jobPortal.Models;
using Microsoft.AspNet.Identity;

namespace LinkForEmployment.Controllers.apiController
{
    public class JobSeekerInfoesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/JobSeekerInfoesApi/ForCurrentUser
        [Authorize]
        [Route("api/JobSeekerInfoesApi/ForCurrentUser")]
        public IQueryable<JobSeekerInfo> GetJobSeekersForCurrentUser()
        {
            string userId = User.Identity.GetUserId();
            return db.JobSeekerInfoes.Where(JobSeekerInfo => JobSeekerInfo.Id == userId);
        }

        // GET: api/JobSeekerInfoesApi
        [Authorize]
        public IQueryable<JobSeekerInfo> GetJobSeekerInfoes()
        {
            return db.JobSeekerInfoes;
        }

        // GET: api/JobSeekerInfoesApi/5
        [Authorize]
        [ResponseType(typeof(JobSeekerInfo))]
        public IHttpActionResult GetJobSeekerInfo(string id)
        {
            JobSeekerInfo jobSeekerInfo = db.JobSeekerInfoes.Find(id);
            if (jobSeekerInfo == null)
            {
                return NotFound();
            }

            return Ok(jobSeekerInfo);
        }

        // PUT: api/JobSeekerInfoesApi/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobSeekerInfo(string id, JobSeekerInfo jobSeekerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobSeekerInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(jobSeekerInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobSeekerInfoExists(id))
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

        // POST: api/JobSeekerInfoesApi
        [Authorize]
        [ResponseType(typeof(JobSeekerInfo))]
        public IHttpActionResult PostJobSeekerInfo(JobSeekerInfo jobSeekerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = User.Identity.GetUserId();
            jobSeekerInfo.Id = userId;
            db.JobSeekerInfoes.Add(jobSeekerInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JobSeekerInfoExists(jobSeekerInfo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jobSeekerInfo.Id }, jobSeekerInfo);
        }

        // DELETE: api/JobSeekerInfoesApi/5
        [Authorize]
        [ResponseType(typeof(JobSeekerInfo))]
        public IHttpActionResult DeleteJobSeekerInfo(string id)
        {
            JobSeekerInfo jobSeekerInfo = db.JobSeekerInfoes.Find(id);
            if (jobSeekerInfo == null)
            {
                return NotFound();
            }

            db.JobSeekerInfoes.Remove(jobSeekerInfo);
            db.SaveChanges();

            return Ok(jobSeekerInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobSeekerInfoExists(string id)
        {
            return db.JobSeekerInfoes.Count(e => e.Id == id) > 0;
        }
    }
}