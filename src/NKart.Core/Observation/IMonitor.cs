using System;

namespace NKart.Core.Observation
{
    /// <summary>
    /// Marker interface for Monitor observers
    /// </summary>
    public interface IMonitor
    {

        IDisposable Subscribe(ITriggerResolver resolver);

        /// <summary>
        /// The type being observed {T}
        /// </summary>
        Type ObservesType { get; }
    }
}