using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * @(#) Book.cs
 */

namespace Invensa.Models
{
	public class Book
	{
        public int Id;
        [DisplayName("Pavadinimas")]
		public String Title { get; set; }
		
        [DisplayName("Kiekis")]
        public int Quantity { get; set; }

        [DisplayName("Autorius")]
        public String Author { get; set; }

        [DisplayName("Apraðymas")]
        public String Description { get; set; }

        public virtual ICollection<Reservation> reservations { get; set; }

        public virtual ICollection<Review> reviews { get; set; }

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
