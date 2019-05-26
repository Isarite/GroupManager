using System;
using System.ComponentModel.DataAnnotations;


/**
 * @(#) Report.cs
 */

namespace Invensa.Models
{
	public class Report
	{
        public int Id { get; set; }

		public int year { get; set; }

        public int timeline { get; set; }

        public int equity { get; set; }

        public int assets { get; set; }

        public int sales { get; set; }

        public double profit { get; set; }

        public double price { get; set; }

        public int dividends { get; set; }

        public int shares { get; set; }

        public double ROA { get; set; }

        public double ROE { get; set; }

        public double NM { get; set; }

        public double LEV { get; set; }

        public double AT { get; set; }

        public double PS { get; set; }

        public double PB { get; set; }

        public double PE { get; set; }

        public Boolean _Public { get; set; }

        public void Insert(  )
		{
			
		}
		
	}
	
}
