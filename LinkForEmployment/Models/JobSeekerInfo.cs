using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class JobSeekerInfo
    {
       
        public string Id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime bornDate { get; set; }
        public string gender { get; set; }
        public string personalPhoto { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string socialStatus { get; set; }
        public int phoneNumber { get; set; }
        public string countryCode { get; set; }
        public string Email { get; set; }
        public string dreamJobTitle { get; set; }
        public string jobField { get; set; }
        public string experienceLevels { get; set; }
        public string dreamJobLocation { get; set; }
        public string jobTime { get; set; }
        public bool isYouWork { get; set; }
        public bool hasCourse { get; set; }
        public bool hasworldCert { get; set; }
        public bool isVoluntaryWork { get; set; }
       

    }
}
