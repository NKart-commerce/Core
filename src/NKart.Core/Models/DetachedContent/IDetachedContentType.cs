using NKart.Core.Models.EntityBase;
using NKart.Core.Models.Interfaces;

namespace NKart.Core.Models.DetachedContent
{
    using System;

    using NKart.Core.Models.EntityBase;
    using NKart.Core.Models.Interfaces;

    /// <summary>
    /// Represents detached content.
    /// </summary>
    public interface IDetachedContentType : IHasEntityTypeField, IEntity
    {        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the content type key.
        /// </summary>
        Guid? ContentTypeKey { get; set; }

        /// <summary>
        /// Gets the entity type.
        /// </summary>
        EntityType EntityType { get; }
    }
}