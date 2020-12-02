using TaxCalculator.API.Data;
using TaxCalculator.API.Repository.IRepository;
using TaxCalculator.Models.Entities;

namespace TaxCalculator.API.Repository
{
    public class ProgressiveTaxRateRepository : EfRepository<ProgressiveTaxRate>, IProgressiveTaxRateRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProgressiveTaxRateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
