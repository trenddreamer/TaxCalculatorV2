using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxCalculator.Repository.IRepository;

namespace TaxCalculator.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IHttpClientFactory _client;
        public ITaxType_PostalCode_RefRepository TaxType_PostalCode_Ref { get; private set; }
        public IPostalCodeRepository PostalCode { get; private set; }
        public ITaxResultRepository TaxResult { get; private set; }
        public IAccountRepository Account { get; private set; }

        public UnitOfWork(IHttpClientFactory client)
        {
            _client = client;
            TaxType_PostalCode_Ref = new TaxType_PostalCode_RefRepository(_client);
            PostalCode = new PostalCodeRepository(_client);
            TaxResult = new TaxResultRepository(_client);
            Account = new AccountRepository(_client);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
