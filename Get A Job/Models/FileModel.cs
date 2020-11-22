using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Get_A_Job.Models
{
	public class FileModel
	{
		public class FileDetailsModel
		{
			public int Id { get; set; }
			public String FileName { get; set; }
			public byte[] FileContent { get; set; }


		}
	}
}