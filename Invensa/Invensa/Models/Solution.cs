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
        public String Type { get; set; }

        public String Description { get; set; }

        public virtual ICollection<User> affected_users { get; set; }

    }

}
