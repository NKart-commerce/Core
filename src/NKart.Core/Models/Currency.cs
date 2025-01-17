﻿namespace NKart.Core.Models
{
    using System;
    using System.Runtime.Serialization;

    using Umbraco.Core;

    /// <summary>
    /// The currency.
    /// </summary>
    [Serializable]
    [DataContract(IsReference = true)]
    internal class Currency : ICurrency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="currencyCode">
        /// The currency code.
        /// </param>
        /// <param name="symbol">
        /// The symbol.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        public Currency(string currencyCode, string symbol, string name)
        {
            Ensure.ParameterNotNullOrEmpty(currencyCode, "currencyCode");
            Ensure.ParameterNotNullOrEmpty(symbol, "symbol");
            Ensure.ParameterNotNullOrEmpty(name, "name");

            CurrencyCode = currencyCode;
            Symbol = symbol;
            Name = name;
        }

        /// <summary>
        /// Gets the ISO Currency Code
        /// </summary>
        [DataMember]
        public string CurrencyCode { get; private set; }

        /// <summary>
        /// Gets the Currency Symbol
        /// </summary>
        [DataMember]
        public string Symbol { get; private set; }

        /// <summary>
        /// Gets the currency name
        /// </summary>
        [DataMember]
        public string Name { get; private set; }
    }
}