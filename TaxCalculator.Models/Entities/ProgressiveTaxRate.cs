using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Models.Shared;

namespace TaxCalculator.Models.Entities
{
    public class ProgressiveTaxRate: BaseEntity
    {
        public decimal Rate { get; set; }
        public int From { get; set; }
        public int? To { get; set; }
    }
}
