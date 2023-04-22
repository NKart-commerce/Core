using System;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the payment repository
    /// </summary>
    internal interface IPaymentRepository : IRepositoryQueryable<Guid, IPayment>
    {
    }
}
