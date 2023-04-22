using NKart.Core.Marketing.Constraints;
using NKart.Core.Marketing.Rewards;
using NKart.Core.Models;

namespace NKart.Core.Chains.OfferConstraints
{
    using System;
    using System.Collections.Generic;

    using NKart.Core.Chains.InvoiceCreation;
    using NKart.Core.Marketing.Constraints;
    using NKart.Core.Marketing.Offer;
    using NKart.Core.Marketing.Rewards;
    using NKart.Core.Models;

    using Umbraco.Core;

    /// <summary>
    /// The OfferAttemptChain interface.
    /// </summary>
    public interface IOfferProcessor
    {
        /// <summary>
        /// Gets a value indicating whether offer processor is initialized.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Initializes the processor
        /// </summary>
        /// <param name="constraints">
        /// The constraints.
        /// </param>
        /// <param name="reward">
        /// The reward.
        /// </param>
        void Initialize(IEnumerable<OfferConstraintComponentBase> constraints, OfferRewardComponentBase reward);

        /// <summary>
        /// Executes the task chain to apply the constraints
        /// </summary>
        /// <param name="validatedAgainst">
        /// The validated against.
        /// </param>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="Attempt"/>.
        /// </returns>
        Attempt<object> TryApplyConstraints(object validatedAgainst, ICustomerBase customer);

        /// <summary>
        /// Try to apply the award
        /// </summary>
        /// <param name="validatedAgainst">
        /// The validated against.
        /// </param>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="Attempt"/>.
        /// </returns>
        Attempt<object> TryAward(object validatedAgainst, ICustomerBase customer);
    }
}