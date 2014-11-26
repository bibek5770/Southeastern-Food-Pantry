using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SePantry_1.Models
{
    public class Donor
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Error!! FirstName is required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Error!! LastName is required")]
        public string LastName { get; set; }

        public string ItemsDonated { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Your email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
       
    }
}