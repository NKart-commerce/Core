using System;
using NKart.Core.Models.EntityBase;

namespace NKart.Core.Models.Interfaces
{
    using System.Runtime.Serialization;

    using NKart.Core.Models.EntityBase;

    /// <summary>
    /// Defines DigitalMedia.
    /// </summary>
    public interface IDigitalMedia : IEntity, IHasExtendedData
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember]
        Guid ProductVariantKey { get; set; }

        /// <summary>
        /// Gets or sets the first accessed date
        /// </summary>
        [DataMember]
        DateTime? FirstAccessed { get; set; }
    }
}