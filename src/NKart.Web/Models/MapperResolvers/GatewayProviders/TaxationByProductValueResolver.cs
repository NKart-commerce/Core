namespace NKart.Web.Models.MapperResolvers.GatewayProviders
{
    using System.Collections.Generic;

    using AutoMapper;

    using NKart.Core.Gateways;
    using NKart.Core.Gateways.Taxation;
    using NKart.Core.Models;
    using NKart.Web.Models.ContentEditing;

    public class TaxationByProductValueResolver : ValueResolver<GatewayProviderBase, bool>
    {
        protected override bool ResolveCore(GatewayProviderBase source)
        {
            return source is ITaxationByProductProvider;
        }
    }
}