using System;
using System.Collections;
using System.Collections.Generic;
using NKart.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the address repository
    /// </summary>
    internal interface IWarehouseRepository : IRepositoryQueryable<Guid, IWarehouse>
    {
       
    }
}
