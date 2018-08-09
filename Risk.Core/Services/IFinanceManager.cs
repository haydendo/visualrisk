using System.Collections.Generic;

namespace Risk.Core.Services
{
    public interface IFinanceManager
    {
        double CalculateNetPresentValue(double initialInvestment, double discountRate, List<double> cashFlows);
    }
}
