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
		public DateTime Date { get; set; }

        public Boolean Quorum { get; set; }

        public virtual Participant participant { get; set; }

        public virtual IEnumerable<Solution> Solutions { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }

		
	}
	
}
