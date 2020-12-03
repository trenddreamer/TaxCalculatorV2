using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TaxCalculator.Models.Shared;

namespace TaxCalculator.Models.Users
{
    public class User: BaseEntity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
