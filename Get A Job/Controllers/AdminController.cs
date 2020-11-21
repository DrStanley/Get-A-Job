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
    public class AdminController : Controller
    {
		private string userId;
		IJobApplication iapplication;
		public AdminController(IJobApplication application)
		{
			iapplication = application;
		}
		public AdminController(string UseurId)
		{
			userId = UserId;
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
		// GET: Admin
        [Authorize(Roles = "Admin")]
		public ActionResult Index()
        {
            return View();
        }
        // GET: Admin
        [Authorize(Roles = "Admin")]
		public ActionResult PostJob()
        {
            return View();
        }


        // GET: Admin
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult PostJob(PostJobViewModel jobViewModel, HttpPostedFileBase file)
        {
			try
			{
				if (file != null && file.ContentLength > 0)
				{

					if (file.FileName != null)

					{
						jobViewModel.AppImage = file;
						var d = jobViewModel.AppImage;
						//if (ModelState.IsValid)
						//{
							var res = iapplication.CreateJobOffer(jobViewModel, UserId);
							if (res == "Success")
							{
								ViewBag.ModelMessage = jobViewModel.JobTitle + " Posted";
								return View();
							}
							else
							{
								ViewBag.ModelMessage = "Error Occurred";
								return View(jobViewModel);
							}

						//}
						//ViewBag.ModelMessage = "Model Error Occurred";
						//return View(jobViewModel);
					}
				}
				else
				{
					ViewBag.ModelMessage = "Please Upload an Image";
					return View(jobViewModel);

				}
			}
			catch (Exception ex)
			{
				ViewBag.Message = "ERROR:" + ex.Message.ToString();
			}

			return View();
        }
    }
}