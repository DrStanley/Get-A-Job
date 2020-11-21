using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Get_A_Job.Models;

namespace Get_A_Job.Entities
{
	public class Applications
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string OtherNames { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string State { get; set; }
		public byte[] CV { get; set; }
		public string NameCV { get; set; }
		public string NameLetter { get; set; }
		public string Phonenumber { get; set; }
		public byte[] Letter { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		public int JobID { get; set; }
		public JobOffers jobOffers { get; set; }
	}
}