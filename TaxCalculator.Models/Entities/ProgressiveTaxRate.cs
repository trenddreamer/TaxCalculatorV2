using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Models.Shared;

namespace TaxCalculator.Models.Entities
{
    public class ProgressiveTaxRate: BaseEntity
    {
        public decimal Rate { get; set; }
        public int LowBand { get; set; }
        public int? HighBand { get; set; }
    }
}
