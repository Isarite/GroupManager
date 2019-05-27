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
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String email { get; set; }
        [Display(Name = "Statusas")]
        public Status status { get; set; }
        [Display(Name = "Slaptažodis")]
        public String password { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }

    }

}
