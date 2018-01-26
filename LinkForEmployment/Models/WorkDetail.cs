using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class WorkDetail
    {
        public int Id { get; set; }
        public DateTime workStartDate { get; set; }
        public DateTime workEndDate { get; set; }
        public bool iWorkNow { get; set; }

        public string workLocation { get; set; }
        public string compName { get; set; }
        public string compWork { get; set; }
        public string compField { get; set; }
        public string workTitle { get; set; }
        public string workDescribe { get; set; }
        public string workCertificate { get; set; }
        public string JobSeekerId { get; set; }
    }
}