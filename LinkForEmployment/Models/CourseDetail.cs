using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class CourseDetail
    {          
        public int Id { get; set; }
        public string courseTitle { get; set; }
        public string courseCertificate { get; set; }
        public string JobSeekerId { get; set; }
    }
}