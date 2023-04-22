using System;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for teh ship country repository
    /// </summary>
    internal interface IShipCountryRepository : IRepositoryQueryable<Guid, IShipCountry>
    {
        bool Exists(Guid catalogKey, string countryCode);
    }
}