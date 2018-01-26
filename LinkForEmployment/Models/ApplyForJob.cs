using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkForEmployment.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        public DateTime ApplyDate { get; set; }
        public int JobId { get; set; }
        public string isApply { get; set; }
        public string UserId { get; set; }

        public virtual job job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}
