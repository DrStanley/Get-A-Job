using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Get_A_Job.Models
{
	public class AdminViewModel
	{

		[EmailAddress]
		[Required(ErrorMessage = "Please a valid email address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter a valid password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "Password and confirm password do not match")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Please enter a valid phone number")]
		public string PhoneNumber { get; set; }


	}

	public class PostJobViewModel
	{
		[Required(ErrorMessage = "Please enter Job Title")]
		[Display(Name = "Job Title")]
		public string JobTitle { get; set; }

		[Required(ErrorMessage = "Please enter Position"),
			Display(Name = "Position")]
		public string Position { get; set; }


		[Required(ErrorMessage = "Please enter Job Details"),
			Display(Name = "Job Details"), DataType(DataType.MultilineText)]
		public string JobDetails { get; set; }
		
		[Required(ErrorMessage = "Please enter Job Details"),
			Display(Name = "Job Requirements"), DataType(DataType.MultilineText)]
		public string Requirements { get; set; }

		[Display(Name = "Number of Applicant Needed")]
		[Required(ErrorMessage = "Please choose your number of applicants")]
		public int NumApplicant { get; set; }

		[Display(Name = "Deadline Date")]
		[Required(ErrorMessage = "Please choose a Deadline Date")]
		public DateTime Deadline { get; set; }
		
		[Display(Name = "Application Image")]
		[Required(ErrorMessage = "Please choose an Image")]
		public HttpPostedFileBase AppImage { get; set; }
		

	}

}