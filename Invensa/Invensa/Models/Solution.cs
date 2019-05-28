using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


/**
 * @(#) Solution.cs
 */

namespace Invensa.Models
{
	public class Solution
	{
        public int Id { get; set; }
        [Display(Name = "Tipas")]
        public String Type { get; set; }
        [Display(Name = "Aprašymas")]
        public String Description { get; set; }

        public virtual ICollection<User> affected_users { get; set; }
        public virtual Protocol protocol { get; set; }

    }

}
