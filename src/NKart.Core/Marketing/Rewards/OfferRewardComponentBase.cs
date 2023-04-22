using NKart.Core.Marketing.Offer;

namespace NKart.Core.Marketing.Rewards
{
    using System;

    using Lucene.Net.Search.Function;

    using NKart.Core.Marketing.Offer;
    using NKart.Core.Models;

    using Umbraco.Core;

    /// <summary>
    /// The offer reward component base.
    /// </summary>
    public abstract class OfferRewardComponentBase : OfferComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfferRewardComponentBase"/> class.
        /// </summary>
        /// <param name="definition">
        /// The definition.
        /// </param>
        protected OfferRewardComponentBase(OfferComponentDefinition definition)
            : base(definition)
        {
        }

        /// <summary>
        /// Gets the component type.
        /// </summary>
        public override OfferComponentType ComponentType
        {
            get
            {
                return OfferComponentType.Reward;
            }
        }

        /// <summary>
        /// Gets the reward type.
        /// </summary>
        internal abstract Type RewardType { get;  }
    }
}