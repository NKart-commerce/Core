﻿namespace NKart.Core.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines a Merchello customer
    /// </summary>
    public interface ICustomer : ICustomerBase, IHasNotes
    {
        /// <summary>
        /// Gets the full name of the customer
        /// </summary>
        [IgnoreDataMember]
        string FullName { get; }

        /// <summary>
        /// Gets or sets first name of the customer
        /// </summary>
        [DataMember]
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the customer
        /// </summary>
        [DataMember]
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets email address of the customer
        /// </summary>
        [DataMember]
        string Email { get; set; }

        /// <summary>
        /// Gets the login name.
        /// </summary>
        [DataMember]
        string LoginName { get; }

        /// <summary>
        /// Gets or sets a value indicating whether tax exempt.
        /// </summary>
        [DataMember]
        bool TaxExempt { get; set; }

        /// <summary>
        /// Gets the addresses.
        /// </summary>
        [DataMember]
        IEnumerable<ICustomerAddress> Addresses { get; } 
    }
}
