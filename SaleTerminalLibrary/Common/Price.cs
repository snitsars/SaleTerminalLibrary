﻿using Epam.Demo.SaleTerminalLibrary.Interfaces;
using System;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    public class Price : IPrice
    {
        private decimal priceValue;
        private readonly IValidationRule valueChecker = new GraterOrEqualZerroRule();

        /// <summary>
        /// Property for set/get price value
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> In case when we try to set value less than 0</exception>
        public decimal Value
        {
            get => priceValue;
            set
            {
                if(!valueChecker.Validate(value))
                { 
                    throw new ArgumentOutOfRangeException($"Price can't be less 0, but you try to set {value}");
                }
                priceValue = value;
            }
        }
    }
}
