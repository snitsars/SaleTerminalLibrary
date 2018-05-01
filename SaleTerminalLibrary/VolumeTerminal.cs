using Epam.Demo.SaleTerminalLibrary.Algorithms;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;
using Unity;
using Unity.Injection;

namespace Epam.Demo.SaleTerminalLibrary
{
    public class VolumeTerminal
    {
        public static void RegisterElements(IUnityContainer container)
        {
            IPricing pricesInformation = new Pricing();
            pricesInformation.SetPrice("A", 1.25m);
            pricesInformation.SetVolumePrice("A", 1.00m, 3);
            pricesInformation.SetPrice("B", 4.25m);
            pricesInformation.SetPrice("C", 1.00m);
            pricesInformation.SetVolumePrice("C", 0.833m, 6);
            pricesInformation.SetPrice("D", 0.75m);

            container.RegisterInstance(pricesInformation);

            container.RegisterType<ICart, Cart>();
            container.RegisterType<IPricingAlgorithm, PricingVolumeAlgorithm>();


            var cartType = typeof(ICart);
            var pricingType = typeof(IPricing);
            var algorithmType = typeof(IPricingAlgorithm);

            container.RegisterType<IPointOfSaleTerminal, PointOfSaleTerminal>(new InjectionConstructor(cartType, pricingType, algorithmType));
        }
    }
}
