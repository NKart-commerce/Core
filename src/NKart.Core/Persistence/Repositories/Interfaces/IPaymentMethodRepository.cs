using System;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the PaymentMethodRepository
    /// </summary>
    internal interface IPaymentMethodRepository : IRepositoryQueryable<Guid, IPaymentMethod>
    { }
}