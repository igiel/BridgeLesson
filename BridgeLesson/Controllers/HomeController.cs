﻿using System.Web.Mvc;

namespace BridgeLesson.Controllers
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
        public ActionResult addNewBiddingSequence()
        {
            return View();
        }

        public ActionResult AddConvention()
        {
            return View();
        }

    }


}