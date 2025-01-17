﻿using NKart.Core.Models;
using NKart.Core.Models.EntityBase;
using NKart.Core.Models.Rdbms;
using NKart.Core.Persistence.Factories;
using NKart.Core.Persistence.Querying;
using NKart.Core.Persistence.UnitOfWork;

namespace NKart.Core.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NKart.Core.Models;
    using NKart.Core.Models.EntityBase;
    using NKart.Core.Models.Rdbms;
    using NKart.Core.Persistence.Factories;
    using NKart.Core.Persistence.Querying;
    using NKart.Core.Persistence.UnitOfWork;

    using Umbraco.Core;
    using Umbraco.Core.Cache;
    using Umbraco.Core.Logging;
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.Querying;
    using Umbraco.Core.Persistence.SqlSyntax;

    /// <summary>
    /// Represents the ShipRateTierRepository
    /// </summary>
    internal class ShipRateTierRepository : MerchelloPetaPocoRepositoryBase<IShipRateTier>, IShipRateTierRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipRateTierRepository"/> class.
        /// </summary>
        /// <param name="work">
        /// The work.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="sqlSyntax">
        /// The SQL syntax.
        /// </param>
        public ShipRateTierRepository(
            IDatabaseUnitOfWork work,
            ILogger logger,
            ISqlSyntaxProvider sqlSyntax)
            : base(work, logger, sqlSyntax)
        {            
        }

        /// <summary>
        /// Gets a <see cref="IShipRateTier"/> by it's key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="IShipRateTier"/>.
        /// </returns>
        protected override IShipRateTier PerformGet(Guid key)
        {
            var sql = GetBaseQuery(false)
              .Where(GetBaseWhereClause(), new { Key = key });

            var dto = Database.Fetch<ShipRateTierDto>(sql).FirstOrDefault();

            if (dto == null)
                return null;

            var factory = new ShipRateTierFactory();
            return factory.BuildEntity(dto);
        }

        /// <summary>
        /// Gets a collection of all <see cref="IShipRateTier"/>.
        /// </summary>
        /// <param name="keys">
        /// The keys.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{IShipRateTier}"/>.
        /// </returns>
        protected override IEnumerable<IShipRateTier> PerformGetAll(params Guid[] keys)
        {
            var dtos = new List<ShipRateTierDto>();

            if (keys.Any())
            {
                // This is to get around the WhereIn max limit of 2100 parameters and to help with performance of each WhereIn query
                var keyLists = keys.Split(400).ToList();

                // Loop the split keys and get them
                foreach (var keyList in keyLists)
                {
                    dtos.AddRange(Database.Fetch<ShipRateTierDto>(GetBaseQuery(false).WhereIn<ShipRateTierDto>(x => x.Key, keyList, SqlSyntax)));
                }
            }
            else
            {
                dtos = Database.Fetch<ShipRateTierDto>(GetBaseQuery(false));
            }

            var factory = new ShipRateTierFactory();
            foreach (var dto in dtos)
            {
                yield return factory.BuildEntity(dto);
            }

        }

        /// <summary>
        /// Get a collection of <see cref="IShipRateTier"/> by query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{IShipRateTier}"/>.
        /// </returns>
        protected override IEnumerable<IShipRateTier> PerformGetByQuery(IQuery<IShipRateTier> query)
        {
            var sqlClause = GetBaseQuery(false);
            var translator = new SqlTranslator<IShipRateTier>(sqlClause, query);
            var sql = translator.Translate();

            var dtos = Database.Fetch<ShipRateTierDto>(sql);

            return dtos.DistinctBy(x => x.Key).Select(dto => Get(dto.Key));
        }

        /// <summary>
        /// Gets the base query.
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
                .From<ShipRateTierDto>(SqlSyntax);

            return sql;
        }

        /// <summary>
        /// Gets the base where clause.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected override string GetBaseWhereClause()
        {
            return "merchShipRateTier.pk = @Key";
        }

        /// <summary>
        /// Gets a list of delete clauses.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{String}"/>.
        /// </returns>
        protected override IEnumerable<string> GetDeleteClauses()
        {
            var list = new List<string>
            {
                "DELETE FROM merchShipRateTier WHERE pk = @Key"
            };

            return list;
        }

        /// <summary>
        /// Saves a new item.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected override void PersistNewItem(IShipRateTier entity)
        {
            ((Entity)entity).AddingEntity();

            var factory = new ShipRateTierFactory();
            var dto = factory.BuildDto(entity);

            Database.Insert(dto);

            entity.Key = dto.Key;

            entity.ResetDirtyProperties();
        }

        /// <summary>
        /// Updates an existing item.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected override void PersistUpdatedItem(IShipRateTier entity)
        {
            ((Entity)entity).AddingEntity();

            var factory = new ShipRateTierFactory();
            var dto = factory.BuildDto(entity);

            Database.Update(dto);

            entity.ResetDirtyProperties();
        }
    }
}