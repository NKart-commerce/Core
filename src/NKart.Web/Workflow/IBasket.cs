using NKart.Web.Workflow.CustomerItemCache;

namespace NKart.Web.Workflow
{
    using NKart.Web.Workflow.CustomerItemCache;

    /// <summary>
    /// The Basket interface.
    /// </summary>
    public interface IBasket : ICustomerItemCacheBase
    {        
        /// <summary>
        /// Gets the sum of all basket item "amount" multiplied by quantity (price)
        /// </summary>
        decimal TotalBasketPrice { get; }       
    }
}