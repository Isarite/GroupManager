using System;
using System.ComponentModel.DataAnnotations;

/**
 * @(#) Review.cs
 */

namespace Invensa.Models
{
	public class Review
	{
        public int Id { get; set; }
        public String Text { get; set; }

        public DateTime Date { get; set; }

        public void InsertReview(  )
		{
			
		}
		
		public void SelectAllReviews(  )
		{
			
		}
		
	}
	
}
