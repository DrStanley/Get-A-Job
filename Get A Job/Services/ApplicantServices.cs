using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Get_A_Job.Entities;
using Get_A_Job.Interfaces;
using Get_A_Job.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Get_A_Job.Services
{
	public class ApplicantServices : IApplicant
	{
		public ApplicationDbContext dbContext;
		public ApplicantServices(ApplicationDbContext db)
		{
			dbContext = db;
		}
		public string CreateApplicants(RegisterViewModel registerApplicant, ApplicationUser user)
		{
			string result = "";
			try
			{
				//var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
				//var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));

				Applicants newApplicant = new Applicants()
				{
					FirstName = registerApplicant.FirstName,
					OtherNames = registerApplicant.OtherNames,
					LastName = registerApplicant.LastName,
					Address = registerApplicant.Address,
					Phonenumber=registerApplicant.Phonenumber,
					State = registerApplicant.State,
					DateCreated = DateTime.Now,
					UserId = user.Id

				};
				dbContext.applicants.Add(newApplicant);
				dbContext.SaveChanges();
				/*IdentityResult res = manager.Create(user, registerApplicant.Password);
				if (res.Succeeded)
				{
					if (!rolemanager.RoleExists("Applicant"))
					{
						IdentityRole role = new IdentityRole();
						role.Name = "Applicant";
						rolemanager.Create(role);

						manager.AddToRole(user.Id, "Applicant");
					}
					manager.AddToRole(user.Id, "Applicant");


					
					
				}*/
				result = "Success";
			}
			catch (DbEntityValidationException e)
			{
				result = "Error: " + e.Message;

				foreach (var eve in e.EntityValidationErrors)
				{
					Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
			return result;

		}

	}
}