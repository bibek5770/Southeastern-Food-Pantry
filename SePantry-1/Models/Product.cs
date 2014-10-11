﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SePantry_1.Models
{
    public class Active_Product
    {
        public int Id { get; set; }
       [ Required]
        public string category { get; set; }
          [Required]
        public string title { get; set; }
          [Required]
        public string manufacturer { get; set; }
          [Required]
        public Boolean isCanned { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual Product_Detail Product_Detail { get; set; }
    }
    public class Product_Detail
    {
        public int Id { get; set; }
          [Required]
        public string category { get; set; }
          [Required]
        public int limit { get; set; }
        public ICollection<Active_Product> Active_Products { get; set; }
    }
    public class Product_History
    {
        public int Id { get; set; }
          [Required]
        public string category { get; set; }
          [Required]
        public string title { get; set; }
          [Required]
        public string manufacturer { get; set; }
          [Required]
        public Boolean isCanned { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateCheckedOut { get; set; }

    }   
}