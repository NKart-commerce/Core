using NKart.Web.Models.ContentEditing;
using NKart.Web.Search;

namespace NKart.Web.Models.MapperResolvers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using NKart.Core;
    using NKart.Core.Models;
    using NKart.Web.Models.ContentEditing;
    using NKart.Web.Search;

    /// <summary>
    /// Maps a collection of <see cref="InvoiceDisplay"/> for a <see cref="ICustomer"/>.
    /// </summary>
    /// <remarks>
    /// Used in AutoMapper mappings - NOT IN USE
    /// </remarks>
    internal class CustomerInvoicesResolver : ValueResolver<ICustomer, IEnumerable<InvoiceDisplay>>
    {
        /// <summary>
        /// The <see cref="CachedInvoiceQuery"/>
        /// </summary>
        private static readonly CachedInvoiceQuery InvoiceQuery = new CachedInvoiceQuery();

        /// <summary>
        /// Override for AutoMapper ValueResolver "ResolveCore"
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{InvoiceQuery}"/>.
        /// </returns>
        protected override IEnumerable<InvoiceDisplay> ResolveCore(ICustomer source)
        {
            return InvoiceQuery.GetByCustomerKey(source.Key) ?? Enumerable.Empty<InvoiceDisplay>();
        }
    }
}