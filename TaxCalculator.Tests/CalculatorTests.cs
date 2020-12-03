using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TaxCalculator.API.Repository.IRepository;
using TaxCalculator.Models.Calculator;
using TaxCalculator.Models.Entities;

namespace TaxCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        #region Setup
        private List<ProgressiveTaxRate> rateTable;
        private List<ProgressiveTaxRate> getRateTable()
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
            return progTaxRate.OrderBy(t => t.LowBand).ToList();
        }

        [SetUp]
        public void Setup()
        {
            rateTable = getRateTable();
        }
        #endregion
        #region calculator
       
        #endregion
        #region ProgressiveTax
        [Test]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void CalculateProgressiveTax_WhenCalledWithARangeOfAmounts_IsNotNull(decimal Amount)
        {
            var calculater = new Calculator(Amount, rateTable);
            var result = calculater.CalculateProgressiveTax();
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase(100, 10)]
        [TestCase(9000, 932.5)]
        [TestCase(45000.32, 7437.58)]
        [TestCase(90456.20, 19047.74)]
        [TestCase(123456, 28287.68)]
        [TestCase(190000, 47842.5)]
        [TestCase(400000, 117683.5)]
        public void CalculateProgressiveTax_WhenCalledWithAnAmount_ReturnsTheExpectedResult(decimal Amount, decimal expectedResult)
        {
            var calculater = new Calculator(Amount, rateTable);
            var result = calculater.CalculateProgressiveTax();
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        #endregion

        #region FlatRateTax
        //all users pay 17.5% tax on their income
        [Test]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void CalculateFlatRateTax_WhenCalledWithARangeOfAmounts_IsNotNull(decimal Amount)
        {
            var calculater = new Calculator(Amount, null);
            var result = calculater.CalculateFlatRateTax();
            Assert.IsNotNull(result);
        }
        [Test]
        [TestCase(100, 17.5)]
        public void Calculator_WhenUsingNullForRateTable_CalculatesFlatRateTax(decimal Amount, decimal expectedResult)
        {

            var calculater = new Calculator(Amount, null);
            var result = calculater.CalculateFlatRateTax();
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [Test]
        [TestCase(100,17.5)]
        [TestCase(500, 87.5)]
        [TestCase(14235, 2491.12)]
        [TestCase(20025.80, 3504.52)]
        public void CalculateFlatRateTax_WhenCalledWithAnAmount_ReturnsTheExpectedResult(decimal Amount,decimal expectedResult)
        {
            var calculater = new Calculator(Amount, null);
            var result = calculater.CalculateFlatRateTax();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion

        #region FlatValueTax
        //10000 per year else if they earn less than 200000 the tax will be 5%
        [Test]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void CalulateFlatValueTax_WhenCalledWithARangeOfAmounts_IsNotNull(decimal Amount)
        {
            var calculater = new Calculator(Amount, null);
            var result = calculater.CalulateFlatValueTax();
            Assert.IsNotNull(result);
        }
        [Test]
        [TestCase(125000.45, 6250.02)]
        public void Calculator_WhenUsingNullForRateTable_CalculatesFlatValueTax(decimal Amount, decimal expectedResult)
        {
            var calculater = new Calculator(Amount, null);
            var result = calculater.CalulateFlatValueTax();
            Assert.That(result, Is.EqualTo(expectedResult));
        }
       
        [Test]
        [TestCase(125000.45, 6250.02)]
        [TestCase(190000, 9500)]
        [TestCase(450000, 10000)]
        [TestCase(200000.01, 10000)]
        public void CalulateFlatValueTax_WhenCalledWithAnAmount_ReturnsTheExpectedResult(decimal Amount, decimal expectedResult)
        {
            var calculater = new Calculator(Amount, null);
            var result = calculater.CalulateFlatValueTax();
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        #endregion


    }
}



