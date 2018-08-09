using Risk.Core.Services;
using Risk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Risk.Controllers
{
    public class FinanceController : ApiController
    {
        readonly IFinanceManager _financeManager;
        public FinanceController(IFinanceManager financeManager)
        {
            _financeManager = financeManager;
        }

        public IEnumerable<NpvOutputModel> Post(NpvInputModel npvInputModel)
        {
            var outputs = new List<NpvOutputModel>();

            for (var discountRate = npvInputModel.LowerBoundDiscountRate;
               discountRate <= npvInputModel.UpperBoundDiscountRate;
                discountRate += npvInputModel.DiscountRateIncrement)
            {
                discountRate = Math.Round(discountRate, 2);
                var npvOutput = new NpvOutputModel
                {
                    DiscountRateLabel = $"{discountRate}%",
                    NetPresentValue = _financeManager.CalculateNetPresentValue(npvInputModel.IntialInvestment, discountRate, npvInputModel.CashFlows.ToList())
                };

                outputs.Add(npvOutput);
            }

            return outputs;
        }
        
    }
}
