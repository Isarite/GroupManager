using System;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * @(#) Book.cs
 */

namespace Invensa.Models
{
	public class Book
	{
		public String Title { get; set; }
		
		public int Quantity { get; set; }

        public String Author { get; set; }

        public String Description { get; set; }

        public virtual Reservation reservation { get; set; }

        public virtual Review review { get; set; }

        public void TakeBookInfo(  )
		{
			
		}
		
		public void UpdateInfo(  )
		{
			
		}
		
		public void InsertBook(  )
		{
			
		}
		
		public void DeleteBook(  )
		{
			
		}
		
		public void SelectAll(  )
		{
			
		}
		
		public void SelectBook(  )
		{
			
		}
		
	}
	
}
