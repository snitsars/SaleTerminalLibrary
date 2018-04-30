using System.Collections.Generic;
using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary
{
    public class PricingAlgorithm
    {
        double Calculate(string productCode, int productCount, Pricing pricing)
        {
            var volumePriceInfo = pricing.GetVolumePrice(productCode);
            /*if (volumePriceInfo != null)
            {
                
            }
            pricing.GetPrice()*/
            return 0;
        }
    }
}