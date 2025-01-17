﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NKart.Core.Models.EntityBase;
using NKart.Core.Models.TypeFields;

namespace NKart.Core.Models
{
    /// <summary>
    /// Defines a customer item cache
    /// </summary>
    public interface IItemCache : ILineItemContainer
    {
        /// <summary>
        /// The key of the entity associated with the item cache
        /// </summary>
        [DataMember]
        Guid EntityKey { get; set; }

        /// <summary>
        /// The registry type field <see cref="ITypeField"/> guid typeKey
        /// </summary>
        [DataMember]
        Guid ItemCacheTfKey { get; set; }

        /// <summary>
        /// The <see cref="ItemCacheType"/> of the customer registry
        /// </summary>
        [DataMember]
        ItemCacheType ItemCacheType { get; set; }

    }
}
