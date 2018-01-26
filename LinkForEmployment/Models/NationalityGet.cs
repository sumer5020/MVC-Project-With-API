using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class NationalityGet
    {
       public string NationalityName { get; set; }
        [Key]
       public string NationalityValue { get; set; }
    }
}