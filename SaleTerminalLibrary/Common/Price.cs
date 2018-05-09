using System;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    public class Price
    {
        private decimal value;

        public virtual decimal Value
        {
            get => value;
            set
            {
                if(value <= 0)
                { 
                    throw new ArgumentOutOfRangeException($"Price can't be less 0, but you try to set {value}");
                }
                this.value = value;
            }
        }
    }
}
