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
    public class EmployerInfoesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EmployerInfoesApi/ForCurrentUser
        [Authorize]
        [Route("api/EmployerInfoesApi/ForCurrentUser")]
        public IQueryable<EmployerInfo> GetEmployersForCurrentUser()
        {
            string userId = User.Identity.GetUserId();
            return db.Employers.Where(EmployerInfo => EmployerInfo.Id == userId);
        }

        // GET: api/EmployerInfoesApi
        [Authorize]
        public IQueryable<EmployerInfo> GetEmployers()
        {
            return db.Employers;
        }

        // GET: api/EmployerInfoesApi/5
        [Authorize]
        [ResponseType(typeof(EmployerInfo))]
        public IHttpActionResult GetEmployerInfo(string id)
        {
            EmployerInfo employerInfo = db.Employers.Find(id);
            if (employerInfo == null)
            {
                return NotFound();
            }

            return Ok(employerInfo);
        }

        // PUT: api/EmployerInfoesApi/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployerInfo(string id, EmployerInfo employerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employerInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(employerInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerInfoExists(id))
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

        // POST: api/EmployerInfoesApi
        [Authorize]
        [ResponseType(typeof(EmployerInfo))]
        public IHttpActionResult PostEmployerInfo(EmployerInfo employerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = User.Identity.GetUserId();
            employerInfo.Id= userId;

            db.Employers.Add(employerInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployerInfoExists(employerInfo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employerInfo.Id }, employerInfo);
        }

        // DELETE: api/EmployerInfoesApi/5
        [Authorize]
        [ResponseType(typeof(EmployerInfo))]
        public IHttpActionResult DeleteEmployerInfo(string id)
        {
            EmployerInfo employerInfo = db.Employers.Find(id);
            if (employerInfo == null)
            {
                return NotFound();
            }

            db.Employers.Remove(employerInfo);
            db.SaveChanges();

            return Ok(employerInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployerInfoExists(string id)
        {
            return db.Employers.Count(e => e.Id == id) > 0;
        }
    }
}