namespace NKart.Web.Models.MapperResolvers
{
    using AutoMapper;

    using NKart.Core;
    using NKart.Core.Models.Interfaces;
    using NKart.Core.Models.TypeFields;

    /// <summary>
    /// The entity type field resolver.
    /// </summary>
    public class EntityTypeFieldResolver : ValueResolver<IHasEntityTypeField, TypeField>
    {
        /// <summary>
        /// Resolves the type field.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="TypeField"/>.
        /// </returns>
        protected override TypeField ResolveCore(IHasEntityTypeField source)
        {
            return (TypeField)source.GetTypeField();
        }
    }
}