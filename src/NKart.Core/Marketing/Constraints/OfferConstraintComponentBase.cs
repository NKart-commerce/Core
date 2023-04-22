﻿using NKart.Core.Marketing.Offer;

namespace NKart.Core.Marketing.Constraints
{
    using System;

    using Lucene.Net.Search.Function;

    using NKart.Core.Chains.OfferConstraints;
    using NKart.Core.Marketing.Offer;
    using NKart.Core.Models;

    using Umbraco.Core;

    /// <summary>
    /// The offer constraint component base.
    /// </summary>
    public abstract class OfferConstraintComponentBase : OfferComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfferConstraintComponentBase"/> class.
        /// </summary>
        /// <param name="definition">
        /// The definition.
        /// </param>
        protected OfferConstraintComponentBase(OfferComponentDefinition definition)
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
                return OfferComponentType.Constraint;
            }
        }

    }
}