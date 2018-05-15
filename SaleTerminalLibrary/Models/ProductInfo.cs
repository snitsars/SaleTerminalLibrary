using Epam.Demo.SaleTerminalLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Models
{
    public class ProductInfo
    {
        public Price SinglePrice { get; set; }
        public Price VolumePrice { get; set; }
        public uint Volume { get; set; }
        public Price PackPrice { get; set; }

        public ITotalCounting PriceCounting { get; set; }
    }
}
