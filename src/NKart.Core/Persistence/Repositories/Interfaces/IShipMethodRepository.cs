using System;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the ship method repository
    /// </summary>
    internal interface IShipMethodRepository : IRepositoryQueryable<Guid, IShipMethod>
    {
        
    }
}