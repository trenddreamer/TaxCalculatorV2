using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.Models.Shared;

namespace TaxCalculator.Models.Entities
{
    public class TaxType : BaseEntity
    {
        public string Description { get; set; }
    }
}
