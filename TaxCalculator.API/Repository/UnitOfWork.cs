using Microsoft.Extensions.Options;
using TaxCalculator.API.Data;
using TaxCalculator.API.Repository.IRepository;

namespace TaxCalculator.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IOptions<AppSettings> _appSettings;
        public ITaxType_PostalCode_RefRepository TaxType_PostalCode_Ref { get; private set; }
        public IPostalCodeRepository PostalCode { get; private set; }
        public ITaxResultRepository TaxResult { get; private set; }
        public IProgressiveTaxRateRepository ProgressiveTaxRate { get; private set; }
        public IUserRepository User { get; private set; }


        public UnitOfWork(ApplicationDbContext dbContext, IOptions<AppSettings> appSettings)
        {
            _dbContext = dbContext;
            _appSettings = appSettings;
            TaxType_PostalCode_Ref = new TaxType_PostalCode_RefRepository(_dbContext);
            PostalCode = new PostalCodeRepository(_dbContext);
            TaxResult = new TaxResultRepository(_dbContext);
            ProgressiveTaxRate = new ProgressiveTaxRateRepository(_dbContext);
            User = new UserRepository(_dbContext,_appSettings);
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
