using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculator.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITaxType_PostalCode_RefRepository TaxType_PostalCode_Ref { get; }
        IPostalCodeRepository PostalCode { get; }
        ITaxResultRepository TaxResult { get; }
        IAccountRepository Account { get; }
        bool Save();
    }
}
