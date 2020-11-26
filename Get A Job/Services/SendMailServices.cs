using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Get_A_Job.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Get_A_Job.Services
{
	public class SendMailServices : ISendMail
	{

		//Using SendGrid to notify user or admin of actions taken in the appplication
		public async Task SendMail(string fromMail, string toMail, string subjectMail, string htmlContentMAil)
		{
			var apiKey = WebConfigurationManager.AppSettings["SENDGRID_KEY"];
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress(fromMail, "JB Limited");
			var subject = "Sending with SendGrid is Fun";
			var to = new EmailAddress(toMail, "Reciever");
			var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlContentMAil, htmlContentMAil);
			var response = await client.SendEmailAsync(msg);
		}
	}
}