using TaxCalculator.API.Data;
using TaxCalculator.API.Repository.IRepository;
using TaxCalculator.Models.Entities;

namespace TaxCalculator.API.Repository
{
    class TaxResultRepository : EfRepository<TaxResult>, ITaxResultRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TaxResultRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
