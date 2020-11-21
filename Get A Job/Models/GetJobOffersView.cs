using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Get_A_Job.Models
{
	public class GetJobOffersView
	{
        public int Id { get; set; }
        public string Position { get; set; }
        public string Title { get; set; }
        public string AplicationDetails { get; set; }
        public string AplicationRequirement { get; set; }
        public int NoOfApplicant { get; set; }
        public string Image { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
    }
}