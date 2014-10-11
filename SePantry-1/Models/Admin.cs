using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SePantry_1.Models
{
    public class Admin
    {
        public int Id { get; set; }
         [Required]
        public string username { get; set; }
         [Required]
        public string password { get; set; }
        public int status { get; set; }
    }
}