using TaxCalculator.API.Data;
using TaxCalculator.API.Repository.IRepository;
using TaxCalculator.Models.Entities;

namespace TaxCalculator.API.Repository
{ 
    public class PostalCodeRepository : EfRepository<PostalCode>, IPostalCodeRepository
    {
        private readonly ApplicationDbContext _dbContext;
       
        public PostalCodeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
