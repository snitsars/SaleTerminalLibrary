using System;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    public class VolumePrice : Price, IVolumePrice
    {
        public uint MinimalCount { get; set; }
    }
}