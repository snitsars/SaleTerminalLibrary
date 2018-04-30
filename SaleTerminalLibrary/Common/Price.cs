using System;
using System.Collections.Generic;
using System.IO;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    public class Price : IPrice
    {
        private double priceValue;

        /// <summary>
        /// Property for set/get price value
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> In case when we try to set value less than 0</exception>
        public double Value
        {
            get => priceValue;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Price can't be less 0, but you try to set {value}"); 
                }
                priceValue = value;
            }
        }


        /// <summary>
        /// Helper method for chek if value of price is equal with value double type
        /// can be override in inherited class for compare only 2 sign after coma or use better etc. ...
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual int CompareTo(double other)
        {
            return Value.CompareTo(other);
        }

        public static bool operator !=(Price operand1, double operand2)
        {
            if (operand1 != null)
            {
                var compareResult = operand1.CompareTo(operand2);
                return compareResult == 1 || compareResult == -1;
            }
            return false;
        }

        public static bool operator ==(Price operand1, double operand2)
        {
            if (operand1 != null)
            {
                var compareResult = operand1.CompareTo(operand2);
                return compareResult == 0;
            }
            return false;
        }
    }
}
