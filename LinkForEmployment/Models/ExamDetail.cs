using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class ExamDetail
    {
        public int Id { get; set; }
        public string examTitle { get; set; }
        public string examCertificate { get; set; }
        public string JobSeekerId { get; set; }
    }
}