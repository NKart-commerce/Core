using NKart.Core.Models;

namespace NKart.Core.Persistence.Repositories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using NKart.Core.Models;

    using Umbraco.Core.Persistence.Repositories;

    /// <summary>
    /// Marker interface for the address repository
    /// </summary>
    internal interface ICustomerAddressRepository : IRepositoryQueryable<Guid, ICustomerAddress>
    {
        /// <summary>
        /// Gets a collection of addresses by customer key.
        /// </summary>
        /// <param name="customerKey">
        /// The customer key.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<ICustomerAddress> GetByCustomerKey(Guid customerKey);

        /// <summary>
        /// Gets the count of addresses by customer key.
        /// </summary>
        /// <param name="customerKey">
        /// The customer key.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int GetCountByCustomerKey(Guid customerKey);
    }
}
