namespace NKart.Web.Models.MapperResolvers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using NKart.Core;
    using NKart.Core.Models;
    using NKart.Core.Models.TypeFields;
    using NKart.Web.Models.ContentEditing;

    /// <summary>
    /// The line item type field resolver.
    /// </summary>
    internal class LineItemTypeFieldResolver : ValueResolver<ILineItem, TypeField>
    {
        /// <summary>
        /// Resolves the line item type field.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="TypeField"/>.
        /// </returns>
        protected override TypeField ResolveCore(ILineItem source)
        {
            return (TypeField)source.GetTypeField();
        }
    }
}