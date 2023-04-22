using NKart.Core.Models.DetachedContent;

namespace NKart.Core.Persistence.Repositories
{
    using System;

    using NKart.Core.Models.DetachedContent;
    using NKart.Core.Models.Interfaces;

    using Umbraco.Core.Persistence.Repositories;

    /// <summary>
    /// Marker interface for the DetachedContentTypeRepository.
    /// </summary>
    public interface IDetachedContentTypeRepository : IRepositoryQueryable<Guid, IDetachedContentType>
    {         
    }
}