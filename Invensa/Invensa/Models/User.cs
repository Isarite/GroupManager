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
        [Display(Name = "Vardas")]
        public String name { get; set; }
        [Display(Name = "Pavardė")]
        public String surname { get; set; }
        [Display(Name = "El paštas")]
        public String email { get; set; }
        [Display(Name = "Statusas")]
        public Status status { get; set; }
        [Display(Name = "Slaptažodis")]
        public String password { get; set; }

        public virtual IEnumerable<Questionnaire> Questionnaires { get; set; }
        public virtual IEnumerable<Reservation> Reservations { get; set; }
        public virtual IEnumerable<Review> Reviews { get; set; }
    }
	
}
