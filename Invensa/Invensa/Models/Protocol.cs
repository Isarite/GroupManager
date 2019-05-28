using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


/**
 * @(#) Protocol.cs
 */

namespace Invensa.Models
{
	public class Protocol
	{
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
        [Display(Name = "Ar yra Kvorumas?")]
        public Boolean Quorum { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }

        public virtual ICollection<Solution> Solutions { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

		
	}
	
}
