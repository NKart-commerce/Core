﻿using NKart.Core.Configuration;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Migrations.Upgrades.TargetVersionOneElevenZero
{
    using System;
    using System.Collections.Generic;

    using NKart.Core.Configuration;
    using NKart.Core.Models.Rdbms;

    using Umbraco.Core;
    using Umbraco.Core.Logging;
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.Migrations;

    /// <summary>
    /// The create customer 2 entity collection table.
    /// </summary>
    [Migration("1.10.0", "1.11.0", 4, MerchelloConfiguration.MerchelloMigrationName)]
    public class CreateCustomer2EntityCollectionTable : IMerchelloMigration
    {
        /// <summary>
        /// The _schema helper.
        /// </summary>
        private readonly DatabaseSchemaHelper _schemaHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomer2EntityCollectionTable"/> class.
        /// </summary>
        public CreateCustomer2EntityCollectionTable()
        {
            var dbContext = ApplicationContext.Current.DatabaseContext;
            _schemaHelper = new DatabaseSchemaHelper(dbContext.Database, LoggerResolver.Current.Logger, dbContext.SqlSyntax);
        }


        /// <summary>
        /// Adds the table to the database
        /// </summary>
        public void Up()
        {                
            if (!_schemaHelper.TableExist("merchCustomer2EntityCollection"))
            {
                _schemaHelper.CreateTable(false, typeof(Customer2EntityCollectionDto));
            }
        }

        /// <summary>
        /// The down.
        /// </summary>
        /// <exception cref="DataLossException">
        /// Throws a data loss exception on a downgrade attempt
        /// </exception>
        public void Down()
        {
            throw new DataLossException("Cannot downgrade from a version 1.11.0 database to a prior version, the database schema has already been modified");
        }
    }
}