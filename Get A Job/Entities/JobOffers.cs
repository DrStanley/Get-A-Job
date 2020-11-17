using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Get_A_Job.Entities
{
	public class JobOffers
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Position { get; set; }
        public string Title { get; set; }
        public string AplicationDetails { get; set; }
        public string Dead { get; set; }
        public string State { get; set; }
        public int NoOfApplicant { get; set; }
        public DateTime Deeadline { get; set; }
        public DateTime DateCreated { get; set; }
    }
}