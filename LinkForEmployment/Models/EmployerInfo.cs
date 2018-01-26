using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class EmployerInfo
    {
        public string Id { get; set; }
        public string compName { get; set; }
        public string compLocation { get; set; }
        public string compSize { get; set; }
        public string compWorkName { get; set; }
        public string JobTitle { get; set; }  // Size it 20 chars
        public string compLogo { get; set; }
        public bool receiveApplay { get; set; }
        public bool reportAndUpdate { get; set; }

    }
}