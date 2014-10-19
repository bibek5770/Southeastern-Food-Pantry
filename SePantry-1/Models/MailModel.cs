using Postal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SePantry_1.Models
{
    public class MailModel: Email
    {
        public string From { get; set; }
        public string To { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public List<UserProfile> UserProfiles { get; set; }
    }
}