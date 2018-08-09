using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk.Core.Services;
using System.Collections.Generic;

namespace Risk.Tests
{
    [TestClass]
    public class FinanceManagerTest
    {
        [TestMethod]
        public void CalculateNpvReturnsCorrectValue1()
        {
            //Arrange
            var initialInvestment = 10;
            var cashFlows = new List<double>
            {
                100, 200
            };
            var discountRate = 5.5;
            var financeManager = new FinanceManager();

            //Act
            var netPresentValue = financeManager.CalculateNetPresentValue(initialInvestment, discountRate, cashFlows);

            //Asset
            Assert.AreEqual(264.48, netPresentValue);

        }

        [TestMethod]
        public void CalculateNpvReturnsCorrectValue2()
        {
            //Arrange
            var initialInvestment = 500;
            var cashFlows = new List<double>
            {
                1200, 2300
            };
            var discountRate = 1.75;
            var financeManager = new FinanceManager();

            //Act
            var netPresentValue = financeManager.CalculateNetPresentValue(initialInvestment, discountRate, cashFlows);

            //Asset
            Assert.AreEqual(2900.93, netPresentValue);

        }
    }
}
