using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Get_A_Job.Entities;
using Get_A_Job.Interfaces;
using Get_A_Job.Models;

namespace Get_A_Job.Services
{
	public class JobApplicationServices : IJobApplication
	{
		public ApplicationDbContext dbContext;
		public JobApplicationServices(ApplicationDbContext db)
		{
			dbContext = db;
		}
		public string CreateJobOffer(PostJobViewModel jobViewModel, string userId)
		{
			string result = "";
			try
			{
				//var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
				//var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));

				JobOffers newJobOffers = new JobOffers()
				{
					Title = jobViewModel.JobTitle,
					AplicationDetails = jobViewModel.JobDetails,
					Deadline = jobViewModel.Deadline,
					DateCreated = DateTime.Now,
					Position = jobViewModel.Position,
					NoOfApplicant = jobViewModel.NumApplicant,
					AplicationRequirement = jobViewModel.Requirements,
					Image = JobApplicationServices.ImageConvertToByte(jobViewModel.AppImage),
					UserId = userId

				};
				dbContext.jobOffers.Add(newJobOffers);
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
			catch (Exception e)
			{
				result = "Error: " + e.Message;
			}
			return result;

		}




		public List<GetJobOffersView> GetAllJobOffers(string type)
		{
			var jobs = dbContext.jobOffers.OrderByDescending(o => o.Id).ToList();
			var allOffers = new List<GetJobOffersView>();
			if (type == "short")
			{

				foreach (var item in jobs)
				{
					GetJobOffersView getJob = new GetJobOffersView()
					{
						Id = item.Id,
						AplicationDetails = JobApplicationServices.Get20(item.AplicationDetails),
						AplicationRequirement = item.AplicationRequirement,
						Deadline = item.Deadline,
						NoOfApplicant = item.NoOfApplicant,
						Position = item.Position,
						Title = item.Title,
						UserId = item.UserId,
						Image = JobApplicationServices.ImageConvertToString(item.Image),
						DateCreated = item.DateCreated
					};
					allOffers.Add(getJob);
				}
			}
			else
			{
				foreach (var item in jobs)
				{
					GetJobOffersView getJob = new GetJobOffersView()
					{
						Id = item.Id,
						AplicationDetails = item.AplicationDetails,
						AplicationRequirement = item.AplicationRequirement,
						Deadline = item.Deadline,
						NoOfApplicant = item.NoOfApplicant,
						Position = item.Position,
						Title = item.Title,
						UserId = item.UserId,
						Image = JobApplicationServices.ImageConvertToString(item.Image),
						DateCreated = item.DateCreated
					};
					allOffers.Add(getJob);
				}
			}


			return allOffers;
		}


		public GetJobOffersView GetAJobOffer(int id)
		{
			var jobs = dbContext.jobOffers.Where(j => j.Id == id).FirstOrDefault();



			GetJobOffersView getJob = new GetJobOffersView()
			{
				Id = jobs.Id,
				AplicationDetails = JobApplicationServices.Get20(jobs.AplicationDetails),
				AplicationRequirement = jobs.AplicationRequirement,
				Deadline = jobs.Deadline,
				NoOfApplicant = jobs.NoOfApplicant,
				Position = jobs.Position,
				Title = jobs.Title,
				UserId = jobs.UserId,
				Image = JobApplicationServices.ImageConvertToString(jobs.Image),
				DateCreated = jobs.DateCreated
			};
		
			

			return getJob;
		}

	public static string ImageConvertToString(byte[] bytes)
	{
		string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

		return "data:image/png;base64," + base64String;
	}


	public static string Get20(string text)
	{
		string new100 = "";

		string[] splits = text.Split(' ');
		for (int w = 0; w < 20; w++)
		{
			if (w == 19)
			{
				new100 += splits[w] + "...";
				break;
			}
			new100 += splits[w] + " ";
		}

		return new100;
	}



	public static byte[] ImageConvertToByte(HttpPostedFileBase file)
	{
		Byte[] bytes = null;

		Stream fs = file.InputStream;

		BinaryReader br = new BinaryReader(fs);

		bytes = br.ReadBytes((Int32)fs.Length);

		return bytes;
	}




}
}