using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SePantry_1.Models
{
    public class Active_Product
    {
        public int Id { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string manufacturer { get; set; }
        public Boolean isCanned { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product_Detail Product_Detail { get; set; }
    }
    public class Product_Detail
    {
        public int Id { get; set; }
        public string category { get; set; }
        public int limit { get; set; }
        public ICollection<Active_Product> Active_Products { get; set; }
    }
    public class Product_History
    {
        public int Id { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string manufacturer { get; set; }
        public Boolean isCanned { get; set; }
        public virtual Customer Customer { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateCheckedOut { get; set; }

    }   
}