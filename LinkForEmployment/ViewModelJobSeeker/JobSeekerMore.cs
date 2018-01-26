using jobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobPortal.ViewModelJobSeeker
{
    public class JobSeekerMore
    {
        public string Id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime bornDate { get; set; }
        public string gender { get; set; }
        public string personalPhoto { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string socialStatus { get; set; }
        public int phoneNumber { get; set; }
        public string countryCode { get; set; }
        public string Email { get; set; }
        public string dreamJobTitle { get; set; }
        public string jobField { get; set; }
        public string experienceLevels { get; set; }
        public string dreamJobLocation { get; set; }
        public string jobTime { get; set; }
        public bool isYouWork { get; set; }
        public bool hasCourse { get; set; }
        public bool hasworldCert { get; set; }
        public bool isVoluntaryWork { get; set; }
        public List<NationalitySet> nationalitys { get { return _nationalitys; } }

        
          private  List<NationalitySet> _nationalitys = new List<NationalitySet>();

        public List<WorkDetail> MoreWorkDetails { get { return _MoreWorkDetails; } }
        private List<WorkDetail> _MoreWorkDetails = new List<WorkDetail>();
        public List<AcadimicDetail> MoreAcadimicDetials { get { return _MoreAcadimicDetials; } }
        private List<AcadimicDetail> _MoreAcadimicDetials = new List<AcadimicDetail>();

        public List<CourseDetail> MoreCourseDetials { get { return _MoreCourseDetials; } }
        private List<CourseDetail> _MoreCourseDetials = new List<CourseDetail>();

        public List<ExamDetail> MoreExamDetials { get { return _MoreExamDetials; } }
        private List<ExamDetail> _MoreExamDetials = new List<ExamDetail>();

        public List<VoluntaryWorkDetail> MoreVoluntaryWorkDetials { get { return _MoreVoluntaryWorkDetials; } }
        private List<VoluntaryWorkDetail> _MoreVoluntaryWorkDetials = new List<VoluntaryWorkDetail>();

        public List<Skill> Skills { get { return _Skills; } }
        private List<Skill> _Skills = new List<Skill>();

        public List<NationalityGet> getNationalities { get { return _getNationalities; } }
        private List<NationalityGet> _getNationalities = new List<NationalityGet>();

        public List<Country> getContries { get { return _getContries; } }
        private List<Country> _getContries = new List<Country>();
       

    }
   

}
