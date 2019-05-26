using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/**
 * @(#) Company.cs
 */

namespace Invensa.Models
{
	public class Company
	{
		public String Title { get; set; }

        public String Director { get; set; }

        public String Description { get; set; }

        public String Country { get; set; }
        public virtual IEnumerable<Report> Reports { get; set; }
		
		public void InsertNewCompany(  )
		{
			
		}
		
		public void Select(  )
		{
			
		}
		
	}
	
}
