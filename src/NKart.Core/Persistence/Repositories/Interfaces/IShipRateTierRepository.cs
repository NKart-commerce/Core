using System;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the ship rate tier repository
    /// </summary>
    internal interface IShipRateTierRepository : IRepositoryQueryable<Guid, IShipRateTier>
    {
         
    }
}