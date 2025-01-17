﻿using NKart.Core.Configuration;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Migrations.Upgrades.TargetVersionOneTwelveZero
{
    using System;

    using NKart.Core.Configuration;
    using NKart.Core.Gateways.Taxation;
    using NKart.Core.Models.Rdbms;
    using NKart.Core.Persistence.Migrations.Upgrades.TargetVersionOneTenZero;

    using Umbraco.Core;
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.Migrations;

    /// <summary>
    /// Insert new merchello setting default extended content culture.
    /// </summary>
    [Migration("1.11.0", "1.12.0", 2, MerchelloConfiguration.MerchelloMigrationName)]
    public class InsertNewMerchelloSettingDefaultExtendedContentCulture : IMerchelloMigration
    {
         /// <summary>
        /// The <see cref="Database"/>.
        /// </summary>
        private readonly Database _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertNewMerchelloSettingDefaultExtendedContentCulture"/> class.
        /// </summary>
        public InsertNewMerchelloSettingDefaultExtendedContentCulture()
            : this(ApplicationContext.Current.DatabaseContext.Database)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertNewMerchelloSettingDefaultExtendedContentCulture"/> class.
        /// </summary>
        /// <param name="database">
        /// The database.
        /// </param>
        public InsertNewMerchelloSettingDefaultExtendedContentCulture(Database database)
        {
            this._database = database;
        }

        /// <summary>
        /// Adds the settings key
        /// </summary>
        public void Up()
        {
            this._database.Insert("merchStoreSetting", "Key", new StoreSettingDto() { Key = Core.Constants.StoreSetting.DefaultExtendedContentCulture, Name = "defaultExtendedContentCulture", Value = "en-US", TypeName = "System.String", CreateDate = DateTime.Now, UpdateDate = DateTime.Now });
        }

        /// <summary>
        /// Removes the key
        /// </summary>
        public void Down()
        {
            this._database.Delete("merchStoreSetting", "pk", null, Core.Constants.StoreSetting.DefaultExtendedContentCulture);
        }
    }
}