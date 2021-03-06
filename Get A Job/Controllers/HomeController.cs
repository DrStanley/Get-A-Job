﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Get_A_Job.Interfaces;
using Get_A_Job.Models;
using Microsoft.AspNet.Identity;

namespace Get_A_Job.Controllers
{
	public class HomeController : Controller
	{
		IAdmin iadmin;
		IJobApplication ijobApplication;
		private string userId;

		public HomeController(IAdmin admin,IJobApplication jobApplication)
		{
			iadmin = admin;
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

		public ActionResult Index()
		{
			AdminViewModel model = new AdminViewModel();
			model.Email = "oga@gmail.com";
			model.Password = "Stan115.";
			model.PhoneNumber = "08182878405";
			iadmin.Addadmin(model);
			var jobs = ijobApplication.GetAllJobOffers("short");
			return View(jobs);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}