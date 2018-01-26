using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkForEmployment.Controllers
{
    public class HelpController : Controller
    {
        // GET: Help
        public ActionResult Index()
        {
            return View();
        }

        // GET: userAgreement
        public ActionResult userAgreement()
        {
            return View("userAgreement");
        }

        // GET: privacyPolicy
        public ActionResult privacyPolicy()
        {
            return View("privacyPolicy");
        }

        // GET: CockesPolicy
        public ActionResult CockesPolicy()
        {
            return View("CockesPolicy");
        }

        //        // GET: ؟؟؟؟؟؟؟
        //        public ActionResult ؟؟؟؟؟؟؟()
        //        {
        //            return View("؟؟؟؟؟؟؟");
        //    }

        //GET: ؟؟؟؟؟؟؟
        //    public ActionResult ؟؟؟؟؟؟؟()
        //        {
        //            return View("؟؟؟؟؟؟؟");
        //}

        //// GET: ؟؟؟؟؟؟؟
        //public ActionResult ؟؟؟؟؟؟؟()
        //        {
        //            return View("؟؟؟؟؟؟؟");
        //        }

        //        // GET: ؟؟؟؟؟؟؟
        //        public ActionResult ؟؟؟؟؟؟؟()
        //        {
        //            return View("؟؟؟؟؟؟؟");
        //        }

        //        // GET: ؟؟؟؟؟؟؟
        //        public ActionResult ؟؟؟؟؟؟؟()
        //        {
        //            return View("؟؟؟؟؟؟؟");
        //        }
    }
}