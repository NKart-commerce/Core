using System;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the Order Status Repository
    /// </summary>
    internal interface IOrderStatusRepository : IRepositoryQueryable<Guid, IOrderStatus>
    { }
}