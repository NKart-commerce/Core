using NKart.Core.Strategies;

namespace NKart.Core.Gateways.Taxation
{
    using NKart.Core.Strategies;

    using Umbraco.Core;

    /// <summary>
    /// Defines a taxation strategy
    /// </summary>
    public interface ITaxCalculationStrategy : IStrategy
    {
        /// <summary>
        /// Computes the invoice tax result
        /// </summary>
        /// <returns>The <see cref="ITaxCalculationResult"/></returns>
        Attempt<ITaxCalculationResult> CalculateTaxesForInvoice();
    }
}
