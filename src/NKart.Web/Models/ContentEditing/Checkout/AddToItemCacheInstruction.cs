namespace NKart.Web.Models.ContentEditing.Checkout
{
    using System.Collections.Generic;

    using NKart.Core;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// The add to item cache instruction.
    /// </summary>
    public class AddToItemCacheInstruction : ItemCacheInstructionBase
    {
        /// <summary>
        /// Gets or sets the product variant keys.
        /// </summary>
        public IEnumerable<AddToItemCacheItem> Items { get; set; }
    }
}
