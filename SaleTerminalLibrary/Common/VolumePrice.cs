using System.Dynamic;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    /// <summary>
    /// Class that represent products that can to be order by Volume price
    /// </summary>
    public class VolumePrice : Price, IVolumePrice
    {
        /// <summary>
        /// Property that tell us how many item should be buyed for use volume or pack price
        /// </summary>
        public uint MinimalCount { get; set; }
    }
}