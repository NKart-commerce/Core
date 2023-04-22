using NKart.Core.Models.Interfaces;

namespace NKart.Core.Models
{
    using System.Collections.Generic;

    using NKart.Core.Models.Interfaces;

    /// <summary>
    /// Defines ModifiableData.
    /// </summary>
    public interface IDataModifierData
    {
        /// <summary>
        /// Gets or sets the modified data logs.
        /// </summary>
        IEnumerable<IDataModifierLog> ModifiedDataLogs { get; set; }
    }
}