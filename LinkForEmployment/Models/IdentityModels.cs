using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace LinkForEmployment.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string QSecurity { get; set; }
        public string Answer { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<LinkForEmployment.Models.job> jobs { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.EmployerInfo> Employers { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.Skill> Skills { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.AcadimicDetail> AcadimicDetails { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.CourseDetail> CourseDetails { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.ExamDetail> ExamDetails { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.NationalityGet> NationalityGets { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.NationalitySet> NationalitySets { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.VoluntaryWorkDetail> VoluntaryWorkDetails { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.WorkDetail> WorkDetails { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.JobSeekerInfo> JobSeekerInfoes { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.Country> Countries { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.PhoneNumber> phoneNumbers { get; set; }
        public System.Data.Entity.DbSet<jobPortal.Models.WebSite> webSites { get; set; }

        public System.Data.Entity.DbSet<LinkForEmployment.Models.ApplyForJob> ApplyForJobs { get; set; }

    }
}