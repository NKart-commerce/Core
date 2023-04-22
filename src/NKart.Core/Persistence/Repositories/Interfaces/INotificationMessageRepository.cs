using System;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the NotificationMessageRepository
    /// </summary>
    internal interface INotificationMessageRepository : IRepositoryQueryable<Guid, INotificationMessage>
    { }
}