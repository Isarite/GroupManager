using System;
using System.ComponentModel.DataAnnotations;


/**
 * @(#) Solution.cs
 */

namespace Invensa.Models
{
	public class Solution
	{
        public int Id { get; set; }
        public String Type { get; set; }

        public String Description { get; set; }

        public virtual User affected_user { get; set; }

    }
	
}
