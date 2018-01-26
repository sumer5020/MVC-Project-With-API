using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class Country
    {
        public string CountryName { get; set; }
        [Key]
        public string CountryValue { get; set; }
    }
}