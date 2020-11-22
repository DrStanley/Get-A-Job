using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
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

		//this method creates applicants in the platform
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
					Phonenumber = registerApplicant.Phonenumber,
					State = registerApplicant.State,
					Email = registerApplicant.Email,
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

		public static byte[] ConvertToByte(HttpPostedFileBase f)
		{
			Stream str = f.InputStream;
			BinaryReader Br = new BinaryReader(str);
			Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
			return FileDet;
		}

		//this method helps in getting byte file from Database
		public Applications GetFile(int AppID)
		{
			var file = dbContext.applications.Where(a => a.Id == AppID).FirstOrDefault();

			return file;
		}

		//gets Applicants details to put in application form for easier applicaton
		public ApplicationFormViewModel GetApplicantsDetails(string userId)
		{

			var a = dbContext.applicants.Where(o => o.UserId == userId).FirstOrDefault();
			ApplicationFormViewModel m = new ApplicationFormViewModel()
			{
				FirstName = a.FirstName,
				OtherNames = a.OtherNames,
				LastName = a.LastName,
				Address = a.Address,
				Phonenumber = a.Phonenumber,
				State = a.State,
				Email = a.Email,

			};

			return m;
		}



	}
}