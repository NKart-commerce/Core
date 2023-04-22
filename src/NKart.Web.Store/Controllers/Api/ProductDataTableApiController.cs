using NKart.Web.Store.Models;

namespace NKart.Web.Store.Controllers.Api
{
    using NKart.Web.Controllers.Api;
    using NKart.Web.Models.Ui;
    using NKart.Web.Store.Models;

    using Umbraco.Web.Mvc;

    /// <summary>
    /// An API controller responsible for handling <see cref="ProductDataTableApiControllerBase{TTable,TRow}"/> API data.
    /// </summary>
    /// <remarks>
    /// We only need to designate the types with this controller and there are no factory overrides.
    /// However, there is a constructor in <see cref="IProductDataTable{TProductDataTableRow}"/> that you can specify
    /// and override the factory.
    /// </remarks>
    [PluginController("Merchello")]
    public class ProductDataTableApiController : ProductDataTableApiControllerBase<ProductDataTable, ProductDataTableRow>
    {
    }
}