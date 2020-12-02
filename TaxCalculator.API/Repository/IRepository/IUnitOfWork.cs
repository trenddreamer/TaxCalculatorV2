using System;

namespace TaxCalculator.API.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
       ITaxType_PostalCode_RefRepository TaxType_PostalCode_Ref { get; }
       IPostalCodeRepository PostalCode { get; }
       ITaxResultRepository TaxResult { get; }
       IProgressiveTaxRateRepository ProgressiveTaxRate { get; }
       IUserRepository User { get; }
       bool Save();
    }
}
