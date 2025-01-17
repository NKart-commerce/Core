﻿namespace NKart.Core.Models.Rdbms
{
    using System;

    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.DatabaseAnnotations;

    /// <summary>
    /// The note dto.
    /// </summary>
    [TableName("merchNote")]
    [PrimaryKey("pk", autoIncrement = false)]
    [ExplicitColumns]
    internal class NoteDto : IPageableDto
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        [Column("pk")]
        [PrimaryKeyColumn(AutoIncrement = false)]
        [Constraint(Default = "newid()")]
        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the entity key.
        /// </summary>
        [Column("entityKey")]
        public Guid EntityKey { get; set; }

        /// <summary>
        /// Gets or sets the reference type.
        /// </summary>
        [Column("entityTfKey")]
        public Guid EntityTfKey { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        [Column("author")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Column("message")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [SpecialDbType(SpecialDbTypes.NTEXT)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the note should be for internal use only.
        /// </summary>
        [Column("internalOnly")]
        public bool InternalOnly { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        [Column("updateDate")]
        [Constraint(Default = "getdate()")]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        [Column("createDate")]
        [Constraint(Default = "getdate()")]
        public DateTime CreateDate { get; set; }
    }
}