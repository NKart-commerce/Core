﻿namespace NKart.Web.Workflow
{
    using System.Linq;

    using NKart.Core;
    using NKart.Core.Models;

    /// <summary>
    /// The basket conversion by combining anonymous basket.
    /// </summary>
    public class BasketConversionByCombiningAnonymousBasket : BasketConversionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasketConversionByCombiningAnonymousBasket"/> class.
        /// </summary>
        /// <param name="anonymousBasket">
        /// The anonymous basket.
        /// </param>
        /// <param name="customerBasket">
        /// The customer basket.
        /// </param>
        public BasketConversionByCombiningAnonymousBasket(IBasket anonymousBasket, IBasket customerBasket)
            : base(anonymousBasket, customerBasket)
        {
        }

        /// <summary>
        /// Executes the merging strategy.
        /// </summary>
        /// <returns>
        /// The <see cref="IBasket"/>.
        /// </returns>
        public override IBasket Merge()
        {
            OnConverting();

            CustomerBasket.Items.Add(AnonymousBasket.Items.Select(x => x.AsLineItemOf<ItemCacheLineItem>()));
            CustomerBasket.Save();

            OnConverted();

            return CustomerBasket;
        }
    }
}