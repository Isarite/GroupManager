using System;
using System.ComponentModel.DataAnnotations;


/**
 * @(#) Question.cs
 */

namespace Invensa.Models
{
	public class Question
	{
        public int Id { get; set; }
		public String Content { get; set; }
        public virtual Protocol protocol { get; set; }
		
	}
	
}
