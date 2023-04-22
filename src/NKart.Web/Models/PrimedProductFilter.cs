namespace NKart.Web.Models
{
    using System;

    using NKart.Core.Models;

    /// <inheritdoc/>
    internal class PrimedProductFilter : IPrimedProductFilter
    {
        /// <inheritdoc/>
        public Guid Key { get; internal set; }

        /// <inheritdoc/>
        public Guid? ParentKey { get; internal set; }

        /// <inheritdoc/>
        public string Name { get; internal set; }

        /// <inheritdoc/>
        public int SortOrder { get; internal set; }

        /// <inheritdoc/>
        public IProviderMeta ProviderMeta { get; internal set; }

        /// <inheritdoc/>
        public int Count { get; set; }

        /// <inheritdoc/>
        public ExtendedDataCollection ExtendedData { get; internal set; }
    }
}