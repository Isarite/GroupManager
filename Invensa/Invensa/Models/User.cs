using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/**
 * @(#) User.cs
 */

namespace Invensa.Models
{
	public class User
	{
        public int Id { get; set; }
        public String name { get; set; }

        public String surname { get; set; }

        public String email { get; set; }

        public Status status { get; set; }

        public String password { get; set; }

        public virtual IEnumerable<Questionnaire> Questionnaires { get; set; }
        public virtual IEnumerable<Reservation> Reservations { get; set; }
        public virtual IEnumerable<Review> Reviews { get; set; }
    }
	
}
