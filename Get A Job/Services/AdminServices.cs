using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Get_A_Job.Interfaces;
using Get_A_Job.Models;

namespace Get_A_Job.Services
{
	public class AdminServices : IAdmin
	{
		public static ApplicationDbContext dbContext;

		public AdminServices( ApplicationDbContext db)
		{
			dbContext = db;
		}

		public string Addadmin(AdminViewModel AdminDetails)
		{
			var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
			var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));

			ApplicationUser user = new ApplicationUser()
			{
				Email = AdminDetails.Email,
				UserName = AdminDetails.Email,
				EmailConfirmed = true,
				PhoneNumber = AdminDetails.PhoneNumber,
				DateCreated = DateTime.Now
			};

			IdentityResult result = manager.Create(user, AdminDetails.Password);
			if (result.Succeeded)
			{
				if (!rolemanager.RoleExists("Admin"))
				{
					IdentityRole role = new IdentityRole();
					role.Name = "Admin";
					rolemanager.Create(role);

					manager.AddToRole(user.Id, "Admin");
				}
				manager.AddToRole(user.Id, "Admin");

				return "Successful";
			}
			else
			{
				return "Unsuccessful";
			}

			
		}

	}
}