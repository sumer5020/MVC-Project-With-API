using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class NationalitySet
    {
        public int Id { get; set; }
        public string nationality { get; set; }
        public string JobSeekerId { get; set; }
    }
}