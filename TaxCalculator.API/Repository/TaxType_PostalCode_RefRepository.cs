using TaxCalculator.API.Data;
using TaxCalculator.API.Repository.IRepository;
using TaxCalculator.Models.Entities;

namespace TaxCalculator.API.Repository
{
    public class TaxType_PostalCode_RefRepository : EfRepository<TaxType_PostalCode_Ref>, ITaxType_PostalCode_RefRepository

    {
        private readonly ApplicationDbContext _dbContext;
       
        public TaxType_PostalCode_RefRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
