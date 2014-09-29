using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SePantry_1.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int status { get; set; }
    }
}