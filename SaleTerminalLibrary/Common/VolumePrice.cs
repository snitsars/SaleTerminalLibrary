using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    /// <summary>
    /// Class represent implementation of product price for volume products
    /// </summary>
    public sealed class VolumePrice : Price
    {
        /// <summary>
        /// Property that tell us how many item should be buyed for use volume or pack price
        /// </summary>
        public uint MinimalVolume { get; set; }
    }
}