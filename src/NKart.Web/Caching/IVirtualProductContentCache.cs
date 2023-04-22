using NKart.Web.Models.VirtualContent;

namespace NKart.Web.Caching
{
    using System;

    using NKart.Core.Models;
    using NKart.Web.Models.VirtualContent;

    internal interface IVirtualProductContentCache : IVirtualContentCache<IProductContent, IProduct>
    {
        IProductContent GetBySlug(string slug, Func<string, IProductContent> get);

        IProductContent GetBySku(string sku, Func<string, IProductContent> get);
    }
}