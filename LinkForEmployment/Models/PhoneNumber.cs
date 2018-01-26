using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Code { get; set; }
        public string JobSeekerId { get; set; }
    }
}