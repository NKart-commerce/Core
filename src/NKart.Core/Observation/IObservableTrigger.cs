using System;

namespace NKart.Core.Observation
{
    /// <summary>
    /// Marker interface for observable triggers
    /// </summary>
    public interface IObservableTrigger<out T> : IObservable<T>, ITrigger
    {
    }
}