using NKart.Web.Store.Models;

namespace NKart.Web.Store.Controllers
{
    using NKart.Web.Controllers;
    using NKart.Web.Store.Models;

    using Umbraco.Web.Mvc;

    /// <summary>
    /// The controller responsible for rendering and processing discounts in the default checkout process.
    /// </summary>
    [PluginController("Merchello")]
    public class CheckoutDiscountController : CheckoutDiscountControllerBase<StoreDiscountModel<StoreLineItemModel>, StoreLineItemModel>
    {
    }
}