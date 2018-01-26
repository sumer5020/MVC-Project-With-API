using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobPortal.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string skillName { get; set; }
        public string JobSeekerId { get; set; }
    }
}