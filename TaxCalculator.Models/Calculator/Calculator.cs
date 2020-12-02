using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxCalculator.Models.Entities;

namespace TaxCalculator.Models.Calculator
{
    public class Calculator
    {
        private const decimal _flatRate = 0.175M;
        private const decimal _flatValueRate = 0.05M;
        public Calculator(decimal Amount, IEnumerable<ProgressiveTaxRate> ProgressiveRates)
        {
            _amount = Amount;
            _progressiveRates = ProgressiveRates;
        }
        private decimal _amount { get; set; }
        private IEnumerable<ProgressiveTaxRate> _progressiveRates { get; set; }


        public decimal CalculateFlatRateTax()
        {
            //all users pay 17.5% tax on their income

            return Math.Round(_amount * _flatRate,2);
        }

        public decimal CalulateFlatValueTax()
        {
            //10000 per year else if they earn less than 200000 the tax will be 5%

            if (_amount < 200000)
            {
                return Math.Round(_amount * _flatValueRate,2);
            }
            else
            {
                return 10000;
            }

        }

        public decimal CalculateProgressiveTax()
        {
            decimal totalTax = 0;
            
            //loop through the progressive tax table from lowest tax to highest
            foreach (var taxRate in _progressiveRates)
            {
                //compare if the amount remaining to be taxed is greater than the current breakpoint, 
                //if so we calculate the eligible portion of tax at the current rate and reduce the amount by the amount taxed and continue
                //if eligibleIncome is null it will evaluate to the else block and we will calculate the remaining amount at the max rate.
                int? eligibleIncome = taxRate.To.HasValue ? taxRate.To- (taxRate.From) : null;
                if (_amount > eligibleIncome)
                {
                    _amount -= eligibleIncome.Value;
                    totalTax += eligibleIncome.Value * taxRate.Rate;
                }
                else //if the amount is less than the current breakpoint we tax the remaining amount at the current rate and exit the loop
                {
                    totalTax += _amount * taxRate.Rate;
                    break;
                }
            }

            return Math.Round(totalTax, 2);
        }
    }
}
