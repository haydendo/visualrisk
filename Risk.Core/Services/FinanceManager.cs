using System;
using System.Collections.Generic;
using System.Linq;

namespace Risk.Core.Services
{
    public class FinanceManager : IFinanceManager
    {
        public double CalculateNetPresentValue(double initialInvestment, double discountRate, List<double> cashFlows)
        {
            cashFlows.Insert(0, -initialInvestment);
            var netPresentValue = cashFlows.Select(
                (
                    cashFlow, index) => cashFlow / Math.Pow(1 + (discountRate / 100), index)
                ).Sum();
            return Math.Round(netPresentValue, 2);
        }
    }
}
