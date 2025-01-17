using NKart.Core.Models;

namespace NKart.Core.Configuration.Sections
{
    using System.Collections.Generic;

    using NKart.Core.Models;

    /// <summary>
    /// Represents a configuration section for configuring Countries and Regions bu Merchello.
    /// </summary>
    public interface IMerchelloCountriesSection
    {
        /// <summary>
        /// Gets the countries.
        /// </summary>
        IEnumerable<ICountry> Countries { get; }
    }
}