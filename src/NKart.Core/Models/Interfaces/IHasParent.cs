using NKart.Core.Models.EntityBase;

namespace NKart.Core.Models
{
    using System;
    using System.Runtime.Serialization;

    using NKart.Core.Models.EntityBase;

    /// <summary>
    /// Defines an entity that has a parent key.
    /// </summary>
    public interface IHasParent : IHasKeyId
    {
        /// <summary>
        /// Gets the parent key.
        /// </summary>
        [DataMember]
        Guid? ParentKey { get; }
    }
}