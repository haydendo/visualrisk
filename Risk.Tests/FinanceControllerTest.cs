using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk.Controllers;
using Risk.Core.Services;
using Risk.Models;
using System.Collections.Generic;
using System.Linq;

namespace Risk.Tests
{
    [TestClass]
    public class FinanceControllerTest
    {

        [TestMethod]
        public void FinanceControllerReturnsCorrectDiscountRates()
        {
            // Arrange
            var npvInputModel = new NpvInputModel
            {
                CashFlows = new List<double> { 100, 200 },
                LowerBoundDiscountRate = 1,
                UpperBoundDiscountRate = 5,
                DiscountRateIncrement = 0.5
            };

            var financeManager = new FinanceManager();
            var financeController = new FinanceController(financeManager);

            // Act
            var output = financeController.Post(npvInputModel);

            // Assert
            Assert.IsNotNull(output);
            Assert.AreEqual(9, output.Count());
        }

    }

}
