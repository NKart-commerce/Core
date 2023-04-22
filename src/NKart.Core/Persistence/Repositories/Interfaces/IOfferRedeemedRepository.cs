using NKart.Core.Models.Interfaces;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Repositories
{
    using System;

    using NKart.Core.Models.Interfaces;
    using NKart.Core.Models.Rdbms;

    /// <summary>
    /// Marker interface for OfferRedeemedRepositories.
    /// </summary>
    internal interface IOfferRedeemedRepository : IPagedRepository<IOfferRedeemed, OfferRedeemedDto>
    {
    }
}