using System;

namespace SuppliesPriceLister.Utility
{
    public static class CurrencyConverterHelper
    {
        public static decimal ConvertUSDToAUD(this decimal uSD, decimal rate)
        {
            return Math.Round(uSD * rate, 2, MidpointRounding.AwayFromZero);
        }
        public static decimal ConvertUSDCentsToAUD(this decimal uSD, decimal rate)
        {
            return Math.Round((uSD / 100) * rate, 2, MidpointRounding.AwayFromZero);
        }
    }
}
