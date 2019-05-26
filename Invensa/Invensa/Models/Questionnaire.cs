using System;
using System.ComponentModel.DataAnnotations;


/**
 * @(#) Questionnaire.cs
 */

namespace Invensa.Models
{
	public class Questionnaire
	{
        public int Id { get; set; }
		public String AcademicGroup { get; set; }
		
		public String Reason { get; set; }

        public String Answers { get; set; }

        public DateTime Date { get; set; }

        public virtual User user { get; set; }

    }
	
}
