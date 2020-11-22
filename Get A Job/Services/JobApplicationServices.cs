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

		ISendMail isendMail;
		IAdmin iadmin;
		public JobApplicationServices(ApplicationDbContext db, ISendMail sendMail, IAdmin admin)
		{
			dbContext = db;
			isendMail = sendMail;
			iadmin = admin;
		}

		//this method enables admin to post jobs which is stored in the database
		public string CreateJobOffer(PostJobViewModel jobViewModel, string userId)
		{
			string result = "";
			try
			{
			
				JobOffers newJobOffers = new JobOffers()
				{
					Title = jobViewModel.JobTitle,
					AplicationDetails = jobViewModel.JobDetails,
					Deadline = jobViewModel.Deadline,
					DateCreated = DateTime.Now,
					Position = jobViewModel.Position,
					NoOfApplicant = jobViewModel.NumApplicant,
					AplicationRequirement = jobViewModel.Requirements,
					Image = JobApplicationServices.ConvertToByte(jobViewModel.AppImage),
					UserId = userId

				};
				dbContext.jobOffers.Add(newJobOffers);
				dbContext.SaveChanges();
		
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

		//this method gets the specific job user clicks to display the whole details
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

		//this method helps in converting  byte to string Readable Image to be displayed
		public static string ImageConvertToString(byte[] bytes)
		{
			string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

			return "data:image/png;base64," + base64String;
		}


		//this method submits applicants form to the database and notifies the Admin that posted the job.
		public string SubmitApplication(ApplicationFormViewModel applicationForm, string NameLetter
			, string userid, string NameCV)
		{
			string result = "";
			try
			{
				Applications newApplications = new Applications()
				{
					FirstName = applicationForm.FirstName,
					OtherNames = applicationForm.OtherNames,
					LastName = applicationForm.LastName,
					Address = applicationForm.Address,
					Phonenumber = applicationForm.Phonenumber,
					State = applicationForm.State,
					JobID = applicationForm.JobID,
					UserId = userid,
					Email = applicationForm.Email,
					NameCV = NameCV,
					NameLetter = NameLetter,
					CV = JobApplicationServices.ConvertToByte(applicationForm.CV),
					Letter = JobApplicationServices.ConvertToByte(applicationForm.Letter),
					DateCreated = DateTime.Now,

				};

				string HTMLcontent = "This is to inform you that <b>" + applicationForm.FirstName
					+ " " + applicationForm.LastName + "</b> Has applied for the job offer you posted on JB Limited";

				var res = isendMail.SendMail(
					"ozoezistanley@gmail.com",
					iadmin.GetAdminEmail(applicationForm.JobID),
					"NEW APPLICANT",
					HTMLcontent
					);
				if (res.IsCompleted)
				{
					dbContext.applications.Add(newApplications);
					dbContext.SaveChanges();
					result = "Success";

				}
				else
				{
					result = "An internal Error Occured. Please check you Network";
				}



			}
			catch (Exception e)
			{
				result = "Error: " + e.Message;

			}
			return result;

		}

		//this method gets the first 20 words in application details to preview to the user when seeing all the applications
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

		//this method helps in converting HttpPostedFileBase to byte to enable it to be stored in Database
		public static byte[] ConvertToByte(HttpPostedFileBase file)
		{
			Byte[] bytes = null;

			Stream fs = file.InputStream;

			BinaryReader br = new BinaryReader(fs);

			bytes = br.ReadBytes((Int32)fs.Length);

			return bytes;
		}

	}
}