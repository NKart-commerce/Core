using System;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the AppliedPaymentRepository
    /// </summary>
    internal interface IAppliedPaymentRepository : IRepositoryQueryable<Guid, IAppliedPayment>
    { }
}