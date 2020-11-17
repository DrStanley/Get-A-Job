using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Get_A_Job.Entities;
using Get_A_Job.Interfaces;
using Get_A_Job.Models;

namespace Get_A_Job.Services
{
	public class ApplicantServices : IApplicant
	{
		public ApplicationDbContext dbContext;
		public ApplicantServices(ApplicationDbContext db)
		{
			dbContext = db;
		}
		public string CreateApplicants(RegisterViewModel registerApplicant, string userid)
		{
			string result = "";
			try
			{
				Applicants newApplicant = new Applicants()
				{
					FirstName = registerApplicant.FirstName,
					OtherNames = registerApplicant.OtherNames,
					LastName = registerApplicant.LastName,
					Address = registerApplicant.Address,
					State = registerApplicant.State,
					DateCreated = DateTime.Now,
					UserId = userid

				};
				dbContext.applicants.Add(newApplicant);
				dbContext.SaveChanges();
				result = "Success";
			}
			catch (Exception e)
			{
				result = "Error: "+e.Message;
			}
			return result;

		}

	}
}