using System;
using System.Collections.Generic;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the TaxMethodRepository
    /// </summary>
    public interface ITaxMethodRepository : IRepositoryQueryable<Guid, ITaxMethod>
    {
    }
}