﻿using NKart.Web.Models.ContentEditing;

namespace NKart.Web.Models.VirtualContent
{
    using System;
    using System.Collections.Generic;

    using NKart.Web.Models.ContentEditing;

    using Umbraco.Core.Models;

    /// <summary>
    /// Defines a virtual product content.
    /// </summary>
    public interface IProductContent : IProductContentBase, IPublishedContent, ICmsContent
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        Guid Key { get; }

        /// <summary>
        /// Gets the product variant key of the master variant.
        /// </summary>
        Guid ProductVariantKey { get; }

        /// <summary>
        /// Gets the product options.
        /// </summary>
        [Obsolete("Use Options property")]
        IEnumerable<ProductOptionDisplay> ProductOptions { get; }

        /// <summary>
        /// Gets the product options.
        /// </summary>
        IEnumerable<IProductOptionWrapper> Options { get; }

        /// <summary>
        /// Gets the product variants.
        /// </summary>
        IEnumerable<IProductVariantContent> ProductVariants { get; }

        /// <summary>
        /// The specify culture.
        /// </summary>
        /// <param name="cultureName">
        /// The culture name.
        /// </param>
        void SpecifyCulture(string cultureName);
    }
}