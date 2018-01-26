using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkForEmployment.Models
{
    public class job
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("اسم الوظيفة")]
        public string jobName { get; set; }
        [Required]
        [DisplayName("مدة عقد العمل")]
        public string DurationOfEmploymentContract { get; set; }
        [Required]
        [DisplayName("عدد ساعات العمل")]
        public string WorkingHours { get; set; }

        [DisplayName("المرتب")]
        public int jobsalary { get; set; }
        [DisplayName("العملة")]
        public string currency { get; set; }
        [DisplayName("مدة تسليم المرتب")]
        public string SalaryPaymentPeriod { get; set; }
        [Required]
        [DisplayName("مكان العمل")]
        public string country { get; set; }
        [Required]
        [DisplayName("المدينة")]
        public string city { get; set; }
        [Required]
        [DisplayName("المنطقة")]
        public string street { get; set; }
        [DisplayName("المدة المتاحة للتقدم")]
        public int DurationAvailableForApply { get; set; }
        [DisplayName("المدة المتاحة للتقدم")]
        public string applayPeriod { get; set; }
        [DisplayName("شروط التقدم")]
        public string applayConditions { get; set; }
        [DisplayName("وصف الوظيفة")]
        public string jobDescrib { get; set; }
        public string UserId { get; set; }
    }
}