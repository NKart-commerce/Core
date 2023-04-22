using NKart.Core.Models;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Repositories
{
    using NKart.Core.Models;
    using NKart.Core.Models.Interfaces;
    using NKart.Core.Models.Rdbms;

    /// <summary>
    /// Marker interface for the AuditLogRepository
    /// </summary>
    internal interface INoteRepository : IPagedRepository<INote, NoteDto>
    {
    }
}