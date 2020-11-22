using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_A_Job.Interfaces
{
	public interface ISendMail
	{
	 Task SendMail(string fromMail, string toMail, string subjectMail, string htmlContentMAil);
	}
}
