using System;
using System.ComponentModel.DataAnnotations;


/**
 * @(#) Reservation.cs
 */

namespace Invensa.Models
{
	public class Reservation
	{
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public DateTime ReturnDate { get; set; }

        public Boolean IsReturned { get; set; }

        public void EditDate(  )
		{
			
		}
		
		public void SelectCount(  )
		{
			
		}
		
		public void UpdateCount(  )
		{
			
		}
		
		public void UpdateDate(  )
		{
			
		}
		
	}
	
}
