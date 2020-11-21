using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Get_A_Job.Interfaces;
using Get_A_Job.Models;
using Microsoft.AspNet.Identity;

namespace Get_A_Job.Controllers
{
	public class JobApplicationController : Controller
	{


		IJobApplication ijobApplication;
		private string userId;

		public JobApplicationController(IJobApplication jobApplication)
		{
			ijobApplication = jobApplication;
		}

		public string UserId
		{
			get
			{
				return userId ?? HttpContext.User.Identity.GetUserId();
			}
			set
			{
				userId = value;
			}
		}

	
		// GET: Application

		public ActionResult AllJobs()
		{
			var jobs = ijobApplication.GetAllJobOffers("short");

			return View(jobs);
		}


		public ActionResult JobsDetail(int jobId)
		{
			var jobs = ijobApplication.GetAJobOffer(jobId);

			return View(jobs);
		}

		[Authorize]
		public ActionResult ApplicationForm(int jobId)
		{
			var jobs = ijobApplication.GetAJobOffer(jobId);
			return View();
		}

		[HttpPost]
		[Authorize]
		public ActionResult ApplicationForm(ApplicationFormViewModel applicationForm,
			HttpPostedFileBase file1, HttpPostedFileBase file2)
		{

			try
			{

				if (file2.ContentLength > 0 && file1.ContentLength > 0)
				{
					if (ModelState.IsValid)
					{

					}
					else
					{
						ViewBag.ModelMessage = "Empty fields";
					ModelState.AddModelError("","Empty Feilds");
						return View(applicationForm);
					}
				}
				else
				{
					ViewBag.ModelMessage = "Please Upload a CV And Letter";
					return View(applicationForm);

				}
			}
			catch (Exception e)
			{
				ViewBag.ModelMessage = "ERROR:  " + e.Message.ToString();
			}
			return View();
		}
	}
}