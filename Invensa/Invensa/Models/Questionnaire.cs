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
        [Display(Name = "Akademinė grupė")]
        public String AcademicGroup { get; set; }
        [Display(Name = "Prisijungimo prie Invensos priežastis")]
        public String Reason { get; set; }
        [Display(Name = "Atsakymai")]
        public String Answers { get; set; }
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
        public virtual User user { get; set; }

    }
	
}
