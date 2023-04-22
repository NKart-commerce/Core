using NKart.Web.Models.ContentEditing.Content;
using NKart.Web.Models.MapperResolvers;
using NKart.Web.Models.MapperResolvers.DetachedContent;

namespace NKart.Web
{
    using NKart.Core.Models.DetachedContent;
    using NKart.Web.Models.ContentEditing.Content;
    using NKart.Web.Models.MapperResolvers;
    using NKart.Web.Models.MapperResolvers.DetachedContent;

    using Umbraco.Core.Models;

    /// <summary>
    /// The auto mapper mappings.
    /// </summary>
    internal static partial class AutoMapperMappings
    {
        /// <summary>
        /// The create detached content mappings.
        /// </summary>
        private static void CreateDetachedContentMappings()
        {
            AutoMapper.Mapper.CreateMap<IDetachedContentType, DetachedContentTypeDisplay>()
                .ForMember(
                    dest => dest.EntityTypeField,
                    opt =>
                    opt.ResolveUsing<EntityTypeFieldResolver>().ConstructedBy(() => new EntityTypeFieldResolver()))
                .ForMember(
                    dest => dest.UmbContentType, 
                    opt 
                    => 
                    opt.ResolveUsing<UmbContentTypeResolver>().ConstructedBy(() => new UmbContentTypeResolver()));

            AutoMapper.Mapper.CreateMap<IContentType, UmbContentTypeDisplay>()
                .ForMember(
                    dest => dest.Tabs,
                    opt =>
                    opt.ResolveUsing<EmbeddedContentTabsResolver>()
                        .ConstructedBy(() => new EmbeddedContentTabsResolver()))
                 .ForMember(
                    dest => dest.AllowedTemplates,
                    opt =>
                    opt.ResolveUsing<AllowedTemplatesResolver>()
                    .ConstructedBy(() => new AllowedTemplatesResolver()));

            AutoMapper.Mapper.CreateMap<IProductVariantDetachedContent, ProductVariantDetachedContentDisplay>()
                .ForMember(
                    dest => dest.DetachedDataValues,
                    opt =>
                    opt.ResolveUsing<DetachedDataValuesResolver>().ConstructedBy(() => new DetachedDataValuesResolver()));

        }
    }
}