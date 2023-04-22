using NKart.Core.Models.EntityBase;

namespace NKart.Core.Models
{
    using System;
    using System.Runtime.Serialization;

    using NKart.Core.Models.EntityBase;

    /// <summary>
    /// Represents a country that can be used in shipping rules.
    /// </summary>
    public interface IShipCountry : ICountry, IEntity
    {
        /// <summary>
        /// Gets the warehouse catalog key
        /// </summary>
        [DataMember]
        Guid CatalogKey { get; }

        /// <summary>
        /// Gets a value indicating whether or not this <see cref="IShipCountry"/> defines a province collection.
        /// </summary>
        bool HasProvinces { get; }
    }
}