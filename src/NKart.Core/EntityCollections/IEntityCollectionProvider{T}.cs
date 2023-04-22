using NKart.Core.Models.EntityBase;

namespace NKart.Core.EntityCollections
{
    using System.Collections.Generic;
    using System.Web.UI;

    using NKart.Core.Models.EntityBase;
    using NKart.Core.Persistence.Querying;

    using Umbraco.Core.Persistence;

    /// <summary>
    /// The EntityCollectionProvider interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type of entity
    /// </typeparam>
    public interface IEntityCollectionProvider<in T>
        where T : class, IEntity
    {
        /// <summary>
        /// Returns true if the entity exists in the collection.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Exists(T entity);
    }
}