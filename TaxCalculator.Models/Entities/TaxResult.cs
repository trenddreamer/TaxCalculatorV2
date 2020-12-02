using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TaxCalculator.Models.Shared;

namespace TaxCalculator.Models.Entities
{
    public class TaxResult : BaseEntity
    {
        //I am assuming that it is not valid to add a number higher than 99999999999
        [Range(0.01, 99999999999, ErrorMessage = "Please enter a valid amount.")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Please enter a valid amount.")]
        [Required(ErrorMessage = "Please enter a valid amount.")]
        [Display(Name="Amount (R)")]
        public decimal Amount { get; set; }
        [Display(Name="Postal Code")]
        public int PostalCodeID { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
