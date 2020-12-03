using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TaxCalculator.Models.Shared;

namespace TaxCalculator.Models.Users
{
    public class User: BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
