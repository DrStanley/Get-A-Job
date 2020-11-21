using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Get_A_Job.Models
{
	public class ApplicationFormViewModel
	{
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Other Names")]
        public string OtherNames { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Phone Number")]
        public string Phonenumber { get; set; }

      
        [Display(Name = "Address")]
        public string Address { get; set; }

      
        [Display(Name = "Residing State")]
        public string State { get; set; }

      
        [Display(Name = "Curriculum vitae (CV)")]
        public HttpPostedFileBase CV { get; set; }

        [Display(Name = "Cover Letter")]
        public HttpPostedFileBase Letter { get; set; }
	}
}