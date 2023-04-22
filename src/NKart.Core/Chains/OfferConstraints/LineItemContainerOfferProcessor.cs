using NKart.Core.Marketing.Constraints;
using NKart.Core.Models;

namespace NKart.Core.Chains.OfferConstraints
{
    using NKart.Core.Marketing.Constraints;
    using NKart.Core.Models;

    /// <summary>
    /// The line item collection offer constraint chain.
    /// </summary>
    [OfferConstraintChainFor(typeof(ILineItemContainer), typeof(ILineItem))]
    internal class LineItemContainerOfferProcessor : OfferProcessorBase<ILineItemContainer, ILineItem>
    {      

        protected override OfferConstraintChainTask<ILineItemContainer> ConvertConstraintToTask(OfferConstraintComponentBase<ILineItemContainer> constraint, ICustomerBase customer)
        {
            return new LineItemContainerOfferConstraintTask(constraint, customer);
        }

    }
}