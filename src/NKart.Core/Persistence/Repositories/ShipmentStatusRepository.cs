﻿namespace NKart.Core.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Models;
    using Models.EntityBase;
    using Models.Rdbms;    
    using Querying;    
    using Umbraco.Core;
    using Umbraco.Core.Cache;
    using Umbraco.Core.Logging;
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.Querying;
    using Umbraco.Core.Persistence.SqlSyntax;

    using UnitOfWork;

    /// <summary>
    /// Represents the ShipmentStatusRepository.
    /// </summary>
    internal class ShipmentStatusRepository : MerchelloPetaPocoRepositoryBase<IShipmentStatus>, IShipmentStatusRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentStatusRepository"/> class.
        /// </summary>
        /// <param name="work">
        /// The <see cref="IDatabaseUnitOfWork"/>.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="sqlSyntax">
        /// The SQL Syntax.
        /// </param>
        public ShipmentStatusRepository(IDatabaseUnitOfWork work, ILogger logger, ISqlSyntaxProvider sqlSyntax) 
            : base(work, logger, sqlSyntax)
        {
        }

        /// <summary>
        /// Gets a <see cref="IShipmentStatus"/> by it's key
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="IShipmentStatus"/>.
        /// </returns>
        protected override IShipmentStatus PerformGet(Guid key)
        {
            var sql = GetBaseQuery(false)
               .Where(GetBaseWhereClause(), new { Key = key });

            var dto = Database.Fetch<ShipmentStatusDto>(sql).FirstOrDefault();

            if (dto == null)
                return null;

            var factory = new ShipmentStatusFactory();

            var status = factory.BuildEntity(dto);

            return status;
        }

        /// <summary>
        /// Gets a collection of all <see cref="IShipmentStatus"/>.
        /// </summary>
        /// <param name="keys">
        /// The keys.
        /// </param>
        /// <returns>
        /// The collection of <see cref="IShipmentStatus"/>.
        /// </returns>
        protected override IEnumerable<IShipmentStatus> PerformGetAll(params Guid[] keys)
        {
            var dtos = new List<ShipmentStatusDto>();

            if (keys.Any())
            {
                // This is to get around the WhereIn max limit of 2100 parameters and to help with performance of each WhereIn query
                var keyLists = keys.Split(400).ToList();

                // Loop the split keys and get them
                foreach (var keyList in keyLists)
                {
                    dtos.AddRange(Database.Fetch<ShipmentStatusDto>(GetBaseQuery(false).WhereIn<ShipmentStatusDto>(x => x.Key, keyList, SqlSyntax)));
                }
            }
            else
            {
                dtos = Database.Fetch<ShipmentStatusDto>(GetBaseQuery(false));
            }

            var factory = new ShipmentStatusFactory();
            foreach (var dto in dtos)
            {
                yield return factory.BuildEntity(dto);
            }

        }

        /// <summary>
        /// Gets a collection of <see cref="IShipmentStatus"/> by query
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The collection of <see cref="IShipmentStatus"/>
        /// </returns>
        protected override IEnumerable<IShipmentStatus> PerformGetByQuery(IQuery<IShipmentStatus> query)
        {
            var sqlClause = GetBaseQuery(false);
            var translator = new SqlTranslator<IShipmentStatus>(sqlClause, query);
            var sql = translator.Translate();

            var dtos = Database.Fetch<ShipmentStatusDto>(sql);

            return dtos.DistinctBy(x => x.Key).Select(dto => Get(dto.Key));
        }

        /// <summary>
        /// Gets the base query
        /// </summary>
        /// <param name="isCount">
        /// The is count.
        /// </param>
        /// <returns>
        /// The <see cref="Sql"/>.
        /// </returns>
        protected override Sql GetBaseQuery(bool isCount)
        {
            var sql = new Sql();
            sql.Select(isCount ? "COUNT(*)" : "*")
               .From<ShipmentStatusDto>(SqlSyntax);

            return sql;
        }

        /// <summary>
        /// The get base where clause.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected override string GetBaseWhereClause()
        {
            return "merchShipmentStatus.pk = @Key";
        }

        /// <summary>
        /// Gets a collection of delete clauses.
        /// </summary>
        /// <returns>
        /// The collection of delete clauses.
        /// </returns>
        protected override IEnumerable<string> GetDeleteClauses()
        {
            var list = new List<string>
                {                    
                    "DELETE FROM merchShipmentStatus WHERE pk = @Key"
                };

            return list;
        }

        /// <summary>
        /// Persists a new shipment status.
        /// </summary>
        /// <param name="entity">
        /// The shipment status.
        /// </param>
        protected override void PersistNewItem(IShipmentStatus entity)
        {
            ((Entity)entity).AddingEntity();

            var factory = new ShipmentStatusFactory();
            var dto = factory.BuildDto(entity);

            Database.Insert(dto);
            entity.Key = dto.Key;
            entity.ResetDirtyProperties();
        }

        /// <summary>
        /// Persists an updated shipment status.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected override void PersistUpdatedItem(IShipmentStatus entity)
        {
            ((Entity)entity).UpdatingEntity();

            var factory = new ShipmentStatusFactory();
            var dto = factory.BuildDto(entity);

            Database.Update(dto);

            entity.ResetDirtyProperties();
        }
    }
}