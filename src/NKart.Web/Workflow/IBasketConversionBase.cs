namespace NKart.Web.Workflow
{
    using NKart.Core.Strategies.Merging;

    /// <summary>
    /// Marker interface for the basket conversion strategy.
    /// </summary>
    public interface IBasketConversionBase : ILineItemContainerMergingStrategy<IBasket>
    {
    }
}