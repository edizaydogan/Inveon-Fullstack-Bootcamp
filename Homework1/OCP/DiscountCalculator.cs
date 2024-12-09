using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.OCP
{
    public class DiscountCalculator
    {
        // Bad Example of OCP
        /*
        public decimal CalculateDiscount(string discountType, decimal amount)
        {
            if (discountType == "Seasonal")
            {
                return amount * 0.1m; // %10 Seasonal Discount
            }
            else if (discountType == "Clearance")
            {
                return amount * 0.2m; // %20 Clearance Discount
            }
            else
            {
                return 0;
            }
        }*/

        private readonly IDiscountStrategy _discountStrategy;

        public DiscountCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public decimal CalculateDiscount(decimal amount)
        {
            return _discountStrategy.ApplyDiscount(amount);
        }
    }

    // Good example of OCP 
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal amount);
    }

    // Seasonal Discount
    public class SeasonalDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal amount)
        {
            return amount * 0.1m; // %10 Seasonal Discount
        }
    }

    // Clearance Discount
    public class ClearanceDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal amount)
        {
            return amount * 0.2m; // %20 Clearance Discount
        }
    }

}