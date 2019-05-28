using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * @(#) Book.cs
 */

namespace Invensa.Models
{
	public class Book
	{
        [DisplayName("Pavadinimas")]
		public String Title { get; set; }
		
        [DisplayName("Kiekis")]
        public int Quantity { get; set; }

        [DisplayName("Autorius")]
        public String Author { get; set; }

        [DisplayName("Apraðymas")]
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
