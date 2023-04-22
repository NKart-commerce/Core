namespace NKart.Web.Models.MapperResolvers
{
    using AutoMapper;
    using NKart.Core;
    using NKart.Core.Models;
    using NKart.Core.Models.TypeFields;

    /// <summary>
    /// The note entity type resolver.
    /// </summary>
    public class NoteEntityTypeResolver : ValueResolver<INote, EntityType>
    {
        /// <summary>
        /// The resolve core.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="EntityType"/>.
        /// </returns>
        protected override EntityType ResolveCore(INote source)
        {
            return EnumTypeFieldConverter.EntityType.GetTypeField(source.EntityTfKey);
        }
    }
}