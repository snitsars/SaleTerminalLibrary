using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;
using Unity;
using Epam.Demo.SaleTerminalLibraryTests.Mocks;

namespace UsageExample
{
    class UsageExampleProgram
    {
        private static readonly IUnityContainer components = new UnityContainer();
        

        static void Main(string[] args)
        {
            VolumeTerminal.RegisterElements(components);
            IPricing pricing = new Pricing();
            pricing.SetSinglePrice("A", 1.25m);
            pricing.SetVolumePrice("A", 1.00m, 3);
            pricing.SetSinglePrice("B", 4.25m);
            pricing.SetSinglePrice("C", 1.00m);
            pricing.SetVolumePrice("C", 0.833m, 6);
            pricing.SetSinglePrice("D", 0.75m);
            pricing.SetSinglePrice("AA", 1.25m);
            pricing.SetVolumePrice("AA", 1.00m, 3);
            pricing.SetSinglePrice("BB", 4.25m);
            pricing.SetSinglePrice("CC", 1.00m);
            pricing.SetVolumePrice("CC", 0.833m, 6);
            pricing.SetSinglePrice("DD", 0.75m);

            components.RegisterInstance(pricing);

            var terminal = components.Resolve<IPointOfSaleTerminal>();
            Parallel.For(0, 99999999, (i, state) =>
            {

                terminal.Scan("AA");
                terminal.Scan("BB");
                terminal.Scan("CC");
                terminal.Scan("CC");
                terminal.Scan("CC");
                terminal.Scan("CC");
                terminal.Scan("CC");
                terminal.Scan("AA");
                terminal.Scan("BB");
                terminal.Scan("CC");
                terminal.Scan("AA");
                terminal.Scan("DD");

                terminal.Scan("A");
                terminal.Scan("B");
                terminal.Scan("C");
                terminal.Scan("C");
                terminal.Scan("C");
                terminal.Scan("C");
                terminal.Scan("C");
                terminal.Scan("A");
                terminal.Scan("B");
                terminal.Scan("C");
                terminal.Scan("A");
                terminal.Scan("D");
            });

            Console.WriteLine(terminal.CalculateTotal());
            Console.ReadKey();
        }
    }
}
