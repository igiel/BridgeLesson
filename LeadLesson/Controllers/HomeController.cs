using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LeadLesson.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BiddingLesson()
        {
            return View();
        }

        public ActionResult LeadingLesson()
        {
            return View();
        }
        public ActionResult ManageBiddingSystem()
        {
            return View();
        }
        public ActionResult BiddingQuiz()
        {
            return View();
        }
        


    }


}
