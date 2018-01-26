using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class AcadimicDetail
    {
        public int Id { get; set; }
        public string acadimicName { get; set; }
        public string acadimicType { get; set; }
        public string acadimicTitle { get; set; }
        public DateTime acadimicEndDate { get; set; }
        public string acadimicCountry { get; set; }
        public string acadimicCity { get; set; }
        public string acadimicCertificate { get; set; }
        public string JobSeekerId { get; set; }
    }
}