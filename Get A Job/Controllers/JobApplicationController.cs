using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Get_A_Job.Controllers
{
    public class JobApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Application
        public ActionResult AllJobs ()
        {
            return View();
        }
        
        public ActionResult JobsDetail ()
        {
            return View();
        }
        
        public ActionResult ApplicationForm ()
        {
            return View();
        }
    }
}