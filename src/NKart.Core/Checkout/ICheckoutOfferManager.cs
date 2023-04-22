using NKart.Core.Marketing.Offer;
using NKart.Core.Models;

namespace NKart.Core.Checkout
{
    using System.Collections.Generic;

    using NKart.Core.Marketing.Offer;
    using NKart.Core.Models;

    /// <summary>
    /// A manager for dealing with marketing offers during the checkout workflow.
    /// </summary>
    public interface ICheckoutOfferManager : ICheckoutContextManagerBase
    {
        /// <summary>
        /// Gets the offer codes.
        /// </summary>
        IEnumerable<string> OfferCodes { get; }

        /// <summary>
        /// Removes an offer code from the OfferCodes collection.
        /// </summary>
        /// <param name="offerCode">
        /// The offer code.
        /// </param>
        void RemoveOfferCode(string offerCode);

        /// <summary>
        /// Clears the offer codes collection.
        /// </summary>
        void ClearOfferCodes();

        /// <summary>
        /// Attempts to redeem an offer to the sale.
        /// </summary>
        /// <param name="offerCode">
        /// The offer code.
        /// </param>
        /// <returns>
        /// The <see cref="IOfferRedemptionResult{TAward}"/>.
        /// </returns>
        IOfferRedemptionResult<ILineItem> RedeemCouponOffer(string offerCode);
    }
}