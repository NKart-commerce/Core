using System;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the NotificationMethodRespository
    /// </summary>
    public interface INotificationMethodRepository : IRepositoryQueryable<Guid, INotificationMethod>
    { }
}