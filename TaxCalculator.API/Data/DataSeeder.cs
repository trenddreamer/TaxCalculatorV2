using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxCalculator.API.Repository.IRepository;
using TaxCalculator.Models.Entities;
using TaxCalculator.Models.Users;

namespace TaxCalculator.API.Data
{

    public class DataSeeder
    {
        //I use the DataSeeder class to initialize the database with the starter values provided.
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var User = new User()
                {
                    Username="admin",Password="admin",Role="admin"
                };
                context.Users.Add(User);
                context.SaveChanges();
            }
            if (!context.TaxTypes.Any())
            {
                var taxtypes = new List<TaxType>()
                  {
                     new TaxType {Description = "Progressive" },
                     new TaxType {Description = "Flat Value" },
                     new TaxType {Description = "Flat Rate" },
                  };
                context.TaxTypes.AddRange(taxtypes);
                context.SaveChanges();
            }

            if (!context.PostalCodes.Any())
            {
                var postalCodes = new List<PostalCode>()
                 {
                    new PostalCode { Description = "7441", SortOrder = 1 },
                    new PostalCode { Description = "A100", SortOrder = 2 },
                    new PostalCode { Description = "7000", SortOrder = 3 },
                    new PostalCode { Description = "1000", SortOrder = 4 },

                 };
                context.PostalCodes.AddRange(postalCodes);
                context.SaveChanges();
            }

            if (!context.ProgressiveTaxRates.Any())
            {
                var progTaxRate = new List<ProgressiveTaxRate>()
                {
                    new ProgressiveTaxRate{Rate = 0.10M,LowBand = 0 ,HighBand = 8350},
                    new ProgressiveTaxRate{Rate = 0.15M,LowBand = 8350 ,HighBand = 33950},
                    new ProgressiveTaxRate{Rate = 0.25M,LowBand = 33950 ,HighBand = 82250},
                    new ProgressiveTaxRate{Rate = 0.28M,LowBand = 82250 ,HighBand = 171550},
                    new ProgressiveTaxRate{Rate = 0.33M,LowBand = 171550 ,HighBand = 372950},
                    new ProgressiveTaxRate{Rate = 0.35M,LowBand = 372950 ,HighBand = null}
                };
                context.ProgressiveTaxRates.AddRange(progTaxRate);
                context.SaveChanges();
            }

            if (!context.TaxType_PostalCode_Refs.Any() && context.PostalCodes.Any() && context.TaxTypes.Any())
            {
                //im linking the pre-entered TaxType and PostalCode Ids to my ref table
                try
                {

                    var tax_code_refs = new List<TaxType_PostalCode_Ref>()
                    {
                        new TaxType_PostalCode_Ref { PostalCodeID = context.PostalCodes.Where(t => t.Description == "7441").SingleOrDefault().Id,
                                                     TaxTypeID = context.TaxTypes.Where(t => t.Description == "Progressive").SingleOrDefault().Id },
                        new TaxType_PostalCode_Ref { PostalCodeID = context.PostalCodes.Where(t => t.Description == "A100").SingleOrDefault().Id,
                                                     TaxTypeID = context.TaxTypes.Where(t => t.Description == "Flat Value").SingleOrDefault().Id },
                        new TaxType_PostalCode_Ref { PostalCodeID = context.PostalCodes.Where(t => t.Description == "7000").SingleOrDefault().Id,
                                                     TaxTypeID = context.TaxTypes.Where(t => t.Description == "Flat Rate").SingleOrDefault().Id },
                        new TaxType_PostalCode_Ref { PostalCodeID = context.PostalCodes.Where(t => t.Description == "1000").SingleOrDefault().Id,
                                                     TaxTypeID = context.TaxTypes.Where(t => t.Description == "Progressive").SingleOrDefault().Id  },
                    };
                    context.TaxType_PostalCode_Refs.AddRange(tax_code_refs);
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }


        }
    }
}
