using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxCalculator.Models.Entities;
using TaxCalculator.Repository.IRepository;

namespace TaxCalculator.Repository
{
    public class TaxType_PostalCode_RefRepository : Repository<TaxType_PostalCode_Ref>, ITaxType_PostalCode_RefRepository
    {
        private readonly IHttpClientFactory _client;
        public TaxType_PostalCode_RefRepository(IHttpClientFactory client) : base(client)
        {
            _client = client;

        }
    }
}
