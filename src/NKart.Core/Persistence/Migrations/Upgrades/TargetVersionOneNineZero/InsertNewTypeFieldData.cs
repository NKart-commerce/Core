using NKart.Core.Configuration;
using NKart.Core.Models.Rdbms;
using NKart.Core.Models.TypeFields;

namespace NKart.Core.Persistence.Migrations.Upgrades.TargetVersionOneNineZero
{
    using System;

    using NKart.Core.Configuration;
    using NKart.Core.Models.Rdbms;
    using NKart.Core.Models.TypeFields;

    using Umbraco.Core;
    using Umbraco.Core.Persistence.Migrations;

    /// <summary>
    /// The insert new type field data.
    /// </summary>
    [Migration("1.8.2", "1.9.0", 1, MerchelloConfiguration.MerchelloMigrationName)]
    public class InsertNewTypeFieldData : IMerchelloMigration
    {
        /// <summary>
        /// The up.
        /// </summary>
        public void Up()
        {
            var database = ApplicationContext.Current.DatabaseContext.Database;
            var entity = new PaymentMethodTypeField();
            database.Insert("merchTypeField", "Key", new TypeFieldDto() { Key = entity.CustomerCredit.TypeKey, Alias = entity.CustomerCredit.Alias, Name = entity.CustomerCredit.Name, UpdateDate = DateTime.Now, CreateDate = DateTime.Now });
        }

        /// <summary>
        /// Throws a data loss exception
        /// </summary>
        public void Down()
        {
            throw new DataLossException("Cannot downgrade from a version 1.9.0 database to a prior version, the database schema has already been modified");
        }
    }
}