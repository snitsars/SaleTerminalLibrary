using Epam.Demo.SaleTerminalLibrary;
using Epam.Demo.SaleTerminalLibrary.Algorithms;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;
using Unity;
using Unity.Injection;

namespace Epam.Demo.SaleTerminalLibraryTests.Mocks
{
    public class PackTerminal
    {
        public static void RegisterElements(IUnityContainer container)
        {
            container.RegisterType<ICart, Cart>();
            container.RegisterType<IPricingAlgorithm, PricingPackAlgorithm>();


            var cartType = typeof(ICart);
            var pricingType = typeof(IPricing);
            var algorithmType = typeof(IPricingAlgorithm);

            container.RegisterType<IPointOfSaleTerminal, PointOfSaleTerminal>(new InjectionConstructor(cartType, pricingType, algorithmType));
        }
    }
}
