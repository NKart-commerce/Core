using AutoMapper;
using NKart.Core.Models;
using NKart.Web.Models.ContentEditing;
using NKart.Web.Models.MapperResolvers;
using NKart.Web.Models.MapperResolvers.DetachedContent;
using NKart.Web.Models.MapperResolvers.ProductOptions;

namespace NKart.Web
{
    /// <summary>
    ///     Binds Merchello AutoMapper mappings during the Umbraco startup.
    /// </summary>
    internal static partial class AutoMapperMappings
    {
        /// <summary>
        ///     Creates warehouse and product mappings.
        /// </summary>
        private static void CreateWarehouseAndProductMappings()
        {
            // warehouse
            Mapper.CreateMap<IWarehouse, WarehouseDisplay>();
            Mapper.CreateMap<IWarehouseCatalog, WarehouseCatalogDisplay>()
                .ForMember(dest => dest.IsDefault,
                    opt => opt.ResolveUsing<WarehouseCatalogIsDefaultResolver>()
                        .ConstructedBy(() => new WarehouseCatalogIsDefaultResolver()));

            // products
            Mapper.CreateMap<IProduct, ProductDisplay>();
            Mapper.CreateMap<IProductVariant, ProductVariantDisplay>();

            Mapper.CreateMap<ProductDisplay, ProductVariantDisplay>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(x => x.ProductVariantKey))
                .ForMember(dest => dest.ProductKey, opt => opt.MapFrom(x => x.Key));

            Mapper.CreateMap<IProductAttribute, ProductAttributeDisplay>()
                .ForMember(
                    dest => dest.DetachedDataValues,
                    opt =>
                        opt.ResolveUsing<ProductAttributeDetachedDataValuesResolver>()
                            .ConstructedBy(() => new ProductAttributeDetachedDataValuesResolver()));

            Mapper.CreateMap<IProductOption, ProductOptionDisplay>()
                .ForMember(
                    dest => dest.ShareCount,
                    opt =>
                        opt.ResolveUsing<ProductOptionSharedCountResolver>()
                            .ConstructedBy(() => new ProductOptionSharedCountResolver()));

            Mapper.CreateMap<ICatalogInventory, CatalogInventoryDisplay>();
        }
    }
}