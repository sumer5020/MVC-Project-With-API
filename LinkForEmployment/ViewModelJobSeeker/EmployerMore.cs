using jobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobPortal.ViewModelJobSeeker
{
    public class EmployerMore
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
        public List<PhoneNumber> PhoneNumberMore { get { return _PhoneNumberMore; } }
        private List<PhoneNumber> _PhoneNumberMore = new List<PhoneNumber>();

        public List<WebSite> WebSiteMore { get { return _webSiteMore; } }
        private List<WebSite> _webSiteMore = new List<WebSite>();
    }
}