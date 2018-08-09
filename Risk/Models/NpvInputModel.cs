using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Risk.Models
{
    public class NpvInputModel
    {
        [Required]
        [Display(Name = "Initial investment:")]
        public double IntialInvestment { get; set; } = 100;

        [Display(Name = "Lower bound discount rate:")]
        public double LowerBoundDiscountRate { get; set; } = 5;

        [Display(Name = "Upper bound discount rate:")]
        public double UpperBoundDiscountRate { get; set; } = 10;

        [Display(Name = "Discount rate increment:")]
        public double DiscountRateIncrement { get; set; } = 0.5;

        public IEnumerable<double> CashFlows { get; set; }
        
    }
}