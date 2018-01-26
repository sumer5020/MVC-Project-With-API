using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class VoluntaryWorkDetail
    {
        public int Id { get; set; }
        public string voluntaryWorkTitle { get; set; }
        public DateTime voluntaryWorkStartDate { get; set; }
        public DateTime voluntaryWorkEndDate { get; set; }
        public string voluntaryWorkDescribe { get; set; }
        public string voluntaryCertificate { get; set; }
        public string JobSeekerId { get; set; }

    }
}