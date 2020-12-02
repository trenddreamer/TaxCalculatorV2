using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.Models.Shared;

namespace TaxCalculator.Models.Entities
{
    public class TaxType_PostalCode_Ref: BaseEntity
    {
        [ForeignKey("PostalCode")]
        public int PostalCodeID { get; set; }
        [ForeignKey("TaxType")]
        public int TaxTypeID { get; set; }
        public virtual TaxType TaxType { get; set; }
    }
}
