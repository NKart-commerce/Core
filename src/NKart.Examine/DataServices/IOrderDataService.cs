using System.Collections.Generic;
using NKart.Core.Models;

namespace NKart.Examine.DataServices
{
    /// <summary>
    /// Defines the OrderDataService
    /// </summary>
    public interface IOrderDataService : IIndexDataService
    {
        IEnumerable<IOrder> GetAll(); 
    }
}