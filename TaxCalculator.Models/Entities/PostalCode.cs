using TaxCalculator.Models.Shared;

namespace TaxCalculator.Models.Entities
{
    public class PostalCode : BaseEntity
    {
        public string Description { get; set; }
        //I implemented sort so I could use my sort filter :)
        public int SortOrder { get; set; }
    }
}