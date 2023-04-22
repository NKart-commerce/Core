using NKart.Core.Checkout;
using NKart.Core.Models;

namespace NKart.Core.Chains.InvoiceCreation.CheckoutManager
{
    using NKart.Core.Checkout;
    using NKart.Core.Models;

    using Umbraco.Core;

    /// <summary>
    /// The invoice creation attempt chain task base.
    /// </summary>
    public abstract class CheckoutManagerInvoiceCreationAttemptChainTaskBase : AttemptChainTaskBase<IInvoice>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutManagerInvoiceCreationAttemptChainTaskBase"/> class.
        /// </summary>
        /// <param name="checkoutManager">
        /// The checkout manager.
        /// </param>
        protected CheckoutManagerInvoiceCreationAttemptChainTaskBase(ICheckoutManagerBase checkoutManager)
        {
            Ensure.ParameterNotNull(checkoutManager, "checkoutManger");

            this.CheckoutManager = checkoutManager;
        }

        /// <summary>
        /// Gets the <see cref="ICheckoutManagerBase"/>.
        /// </summary>
        protected ICheckoutManagerBase CheckoutManager { get; private set; }
    }
}