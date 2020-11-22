using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Get_A_Job.Models;

namespace Get_A_Job.Interfaces
{
	public interface IJobApplication
	{

		string CreateJobOffer(PostJobViewModel jobViewModel, string userId);
		List<GetJobOffersView> GetAllJobOffers(string type);
		GetJobOffersView GetAJobOffer(int id);
		string SubmitApplication(ApplicationFormViewModel applicationForm, string NameLetter
		   , string userid, string NameCV);
	}
}
