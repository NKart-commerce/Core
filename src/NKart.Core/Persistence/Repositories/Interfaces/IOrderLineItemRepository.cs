using NKart.Core.Models;

namespace NKart.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface with the Order Line Item Repository
    /// </summary>
    internal interface IOrderLineItemRepository : ILineItemRepositoryBase<IOrderLineItem>
    { }
}