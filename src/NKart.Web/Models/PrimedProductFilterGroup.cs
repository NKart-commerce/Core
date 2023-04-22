namespace NKart.Web.Models
{
    using System;
    using System.Collections.Generic;

    using NKart.Core.Models;

    /// <inheritdoc/>
    internal class PrimedProductFilterGroup : IPrimedProductFilterGroup
    {
        /// <inheritdoc/>
        public Guid Key { get; internal set; }

        /// <inheritdoc/>
        public Guid? ParentKey
        {
            get
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public string Name { get; internal set; }

        /// <inheritdoc/>
        public int SortOrder { get; internal set; }

        /// <inheritdoc/>
        public IProviderMeta ProviderMeta { get; internal set; }

        /// <inheritdoc/>
        public IEnumerable<IPrimedProductFilter> Filters { get; set; }

        /// <inheritdoc/>
        public int Count { get; set; }

        /// <inheritdoc/>
        public ExtendedDataCollection ExtendedData { get; internal set; }
    }
}