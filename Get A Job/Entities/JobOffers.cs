﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Get_A_Job.Models;

namespace Get_A_Job.Entities
{
	public class JobOffers
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Position { get; set; }
        public string Title { get; set; }
        public string AplicationDetails { get; set; }
        public string AplicationRequirement { get; set; }
        public int NoOfApplicant { get; set; }
        public byte[] Image { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}