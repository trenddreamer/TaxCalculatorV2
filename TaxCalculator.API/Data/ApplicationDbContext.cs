using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using TaxCalculator.Models.Entities;
using TaxCalculator.Models.Users;

namespace TaxCalculator.API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base (options)
        {

        }

        public DbSet<TaxType_PostalCode_Ref> TaxType_PostalCode_Refs { get; set; }
        public DbSet<TaxType> TaxTypes { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<ProgressiveTaxRate> ProgressiveTaxRates { get; set; }
        public DbSet<TaxResult> TaxResults { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../TaxCalculator.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("TaxCalculatorConnection");
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
