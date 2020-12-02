using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxCalculator.Models.Entities;
using TaxCalculator.Repository.IRepository;

namespace TaxCalculator.Repository
{
    public class PostalCodeRepository: Repository<PostalCode>,IPostalCodeRepository
    {
        private readonly IHttpClientFactory _client;
        public PostalCodeRepository(IHttpClientFactory client) : base (client)
        {
            _client = client;
        }
    }
}
