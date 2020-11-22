using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Get_A_Job.Models;

namespace Get_A_Job.Interfaces
{
	public interface IAdmin
	{
		string Addadmin(AdminViewModel AdminDetails);
		string GetAdminEmail(int JobId);
	}
}