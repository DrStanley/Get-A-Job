using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Get_A_Job.Models;

namespace Get_A_Job.Entities
{
	public class Applicants
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string OtherNames { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}