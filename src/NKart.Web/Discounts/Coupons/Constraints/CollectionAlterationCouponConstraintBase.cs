namespace NKart.Web.Discounts.Coupons.Constraints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NKart.Core;
    using NKart.Core.Marketing.Constraints;
    using NKart.Core.Marketing.Offer;
    using NKart.Core.Models;

    /// <summary>
    /// A base class for coupon constraints that alter the validation collection
    /// </summary>
    public abstract class CollectionAlterationCouponConstraintBase : CouponConstraintBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionAlterationCouponConstraintBase"/> class.
        /// </summary>
        /// <param name="definition">
        /// The definition.
        /// </param>
        protected CollectionAlterationCouponConstraintBase(OfferComponentDefinition definition)
            : base(definition)
        {
        }

        /// <summary>
        /// Creates a new <see cref="ILineItemContainer"/> with filtered items.
        /// </summary>
        /// <param name="filteredItems">
        /// The line items.
        /// </param>
        /// <returns>
        /// The <see cref="ILineItemContainer"/>.
        /// </returns>
        protected ILineItemContainer CreateNewLineContainer(IEnumerable<ILineItem> filteredItems)
        {
            var lineItems = filteredItems as ILineItem[] ?? filteredItems.ToArray();

            var result = new ItemCache(Guid.NewGuid(), ItemCacheType.Backoffice);
            if (!lineItems.Any()) return result;

            var itemCacheLineItems = lineItems.Select(x => x.AsLineItemOf<ItemCacheLineItem>());
            
            result.Items.Add(itemCacheLineItems);
            return result;
        }
    }
}