using Epam.Demo.SaleTerminalLibrary;
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

            var cartType = typeof(ICart);
            var pricingType = typeof(IPricing);

            container.RegisterType<IPointOfSaleTerminal, PointOfSaleTerminal>(
                new InjectionConstructor(cartType, pricingType));
        }
    }
}