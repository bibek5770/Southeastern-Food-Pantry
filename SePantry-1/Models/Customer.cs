using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SePantry_1.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string wNumber { get; set; }
        public string password { get; set; }
        public ICollection<Active_Product> Active_Products { get; set; }
        public ICollection<Product_History> FoodCheckedOuts { get; set; }
    }
}