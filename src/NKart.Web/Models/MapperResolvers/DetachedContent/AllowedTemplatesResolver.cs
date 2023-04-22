using NKart.Web.Models.ContentEditing.Content;

namespace NKart.Web.Models.MapperResolvers.DetachedContent
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using NKart.Web.Models.ContentEditing.Content;

    using Umbraco.Core.Models;

    /// <summary>
    /// The allowed templates resolver.
    /// </summary>
    internal class AllowedTemplatesResolver : ValueResolver<IContentType, IEnumerable<UmbTemplateDisplay>>
    {
        /// <summary>
        /// The resolve core.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{UmbTemplateDisplay}"/>.
        /// </returns>
        protected override IEnumerable<UmbTemplateDisplay> ResolveCore(IContentType source)
        {
            return source.AllowedTemplates.Any()
                       ? source.AllowedTemplates.Select(
                           x => new UmbTemplateDisplay() { Id = x.Id, Name = x.Name, Alias = x.Alias })
                       : Enumerable.Empty<UmbTemplateDisplay>();
        }
    }
}
