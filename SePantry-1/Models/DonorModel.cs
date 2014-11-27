using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SePantry_1.Models
{
    public class DonorModel
    {
        public int Id { get; set; }
         [Required]
        public string FirstName { get; set; }
         [Required]
        public string LastName { get; set; }
         [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

         [DataType(DataType.Date)]
         public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string category { get; set; }
        [Required]

        [Display(Name = "Title")]
        public string title { get; set; }
        //[Required]

        //[Display(Name = "Manufacturer")]
        //public string manufacturer { get; set; }
        [Required]
        [Display(Name = "Is Canned")]
        public Boolean isCanned { get; set; }

        [Display(Name = "Barcode")]
        public string product_code { get; set; }

        //public virtual UserProfile UserProfile { get; set; }
        //public virtual Product_Detail Product_Detail { get; set; }
    }
}