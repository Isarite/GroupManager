using System;
using System.ComponentModel.DataAnnotations.Schema;


/**
 * @(#) Participant.cs
 */

namespace Invensa.Models
{
	public class Participant
	{
        public int Id { get; set; }
		public DateTime Date { get; set; }
		
		public String Role { get; set; }
        [ForeignKey("user")]
        public int userId { get; set; }
        public virtual User user { get; set; }
    }
	
}
