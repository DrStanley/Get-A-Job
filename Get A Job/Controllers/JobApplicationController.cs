using System;
using System.Collections.Generic;
using System.IO;
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
		IApplicant iapplicant;
		private string userId;

		public JobApplicationController(IJobApplication jobApplication, IApplicant applicant)
		{
			ijobApplication = jobApplication;
			iapplicant = applicant;
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
			var userDetails = iapplicant.GetApplicantsDetails(UserId);
			userDetails.JobID = jobId;

			return View(userDetails);
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
					String FileExt1 = Path.GetExtension(file1.FileName).ToUpper();
					String FileExt2 = Path.GetExtension(file2.FileName).ToUpper();

					if (FileExt1 == ".PDF" && FileExt2 == ".PDF")
					{
						applicationForm.CV = file1;
						applicationForm.Letter = file2;
						if (ModelState.IsValid)
						{
							var res = ijobApplication.SubmitApplication(applicationForm, file2.FileName, UserId, file1.FileName);
							if (res == "Success")
							{
								ViewBag.ModelMessage = "Submit Succesfull";
							}
							else
							{
								ViewBag.ModelMessage = "Submit Unuccesfull";
							}
						}
						else
						{
							ViewBag.ModelMessage = "Empty fields";
							ModelState.AddModelError("", "Empty Feilds");
							return View(applicationForm);
						}
					}
					else
					{

						ViewBag.FileStatus = "Invalid file format.";
						return View();

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


		//	[HttpGet]
		//public FileResult DownLoadFile(int id)
		//{
		////	var file = iapplicant.

		//	return File(file.FileContent, "application/pdf", file.FileName);

		//}
	}
}