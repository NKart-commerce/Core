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
    /// The anonymous customer repository.
    /// </summary>
    internal class AnonymousCustomerRepository : MerchelloPetaPocoRepositoryBase<IAnonymousCustomer>, IAnonymousCustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousCustomerRepository"/> class.
        /// </summary>
        /// <param name="work">
        /// The database unit of work.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="sqlSyntax">
        /// The SQL Syntax.
        /// </param>
        public AnonymousCustomerRepository(IDatabaseUnitOfWork work, ILogger logger, ISqlSyntaxProvider sqlSyntax)
            : base(work, logger, sqlSyntax)
        {
        }

        /// <summary>
        /// The perform get.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="IAnonymousCustomer"/>.
        /// </returns>
        protected override IAnonymousCustomer PerformGet(Guid key)
        {
            var sql = GetBaseQuery(false)
                .Where(GetBaseWhereClause(), new { Key = key });

            var dto = Database.Fetch<AnonymousCustomerDto>(sql).FirstOrDefault();

            if (dto == null)
                return null;

            var factory = new AnonymousCustomerFactory();

            var anonymous = factory.BuildEntity(dto);

            return anonymous;
        }

        /// <summary>
        /// The perform get all.
        /// </summary>
        /// <param name="keys">
        /// The keys.
        /// </param>
        /// <returns>
        /// The collection of all anonymous customers.
        /// </returns>
        protected override IEnumerable<IAnonymousCustomer> PerformGetAll(params Guid[] keys)
        {
            var dtos = new List<AnonymousCustomerDto>();

            if (keys.Any())
            {
                // This is to get around the WhereIn max limit of 2100 parameters and to help with performance of each WhereIn query
                var keyLists = keys.Split(400).ToList();

                // Loop the split keys and get them
                foreach (var keyList in keyLists)
                {
                    dtos.AddRange(Database.Fetch<AnonymousCustomerDto>(GetBaseQuery(false).WhereIn<AnonymousCustomerDto>(x => x.Key, keyList, SqlSyntax)));
                }
            }
            else
            {
                dtos = Database.Fetch<AnonymousCustomerDto>(GetBaseQuery(false));
            }

            var factory = new AnonymousCustomerFactory();
            foreach (var dto in dtos)
            {
                yield return factory.BuildEntity(dto);
            }
        }

        /// <summary>
        /// The get base query.
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
               .From<AnonymousCustomerDto>(SqlSyntax);

            return sql;
        }

        /// <summary>
        /// The get base where clause.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> representing the base SQL where clause.
        /// </returns>
        protected override string GetBaseWhereClause()
        {
            return "merchAnonymousCustomer.pk = @Key";
        }

        /// <summary>
        /// The get delete clauses.
        /// </summary>
        /// <returns>
        /// The collection of SQL delete clauses.
        /// </returns>
        protected override IEnumerable<string> GetDeleteClauses()
        {
            var list = new List<string>
                {
                    "DELETE FROM merchItemCacheItem WHERE itemCacheKey IN (SELECT pk FROM merchItemCache WHERE entityKey = @Key)",
                    "DELETE FROM merchItemCache WHERE entityKey = @Key",
                    "DELETE FROM merchAnonymousCustomer WHERE pk = @Key",
                };

            return list;
        }

        /// <summary>
        /// The persist new item.
        /// </summary>
        /// <param name="entity">
        /// The entity to be created.
        /// </param>
        protected override void PersistNewItem(IAnonymousCustomer entity)
        {
            ((Entity)entity).AddingEntity();

            var factory = new AnonymousCustomerFactory();
            var dto = factory.BuildDto(entity);

            Database.Insert(dto);
            entity.Key = dto.Key;
            entity.ResetDirtyProperties();
        }

        /// <summary>
        /// The persist updated item.
        /// </summary>
        /// <param name="entity">
        /// The entity to be updated.
        /// </param>
        protected override void PersistUpdatedItem(IAnonymousCustomer entity)
        {
            ((Entity)entity).UpdatingEntity();

            var factory = new AnonymousCustomerFactory();
            var dto = factory.BuildDto(entity);

            Database.Update(dto);

            entity.ResetDirtyProperties();
        }

        /// <summary>
        /// The persist deleted item.
        /// </summary>
        /// <param name="entity">
        /// The entity to be deleted.
        /// </param>
        protected override void PersistDeletedItem(IAnonymousCustomer entity)
        {
            var deletes = GetDeleteClauses();
            foreach (var delete in deletes)
            {
                Database.Execute(delete, new { Key = entity.Key });
            }
        }

        /// <summary>
        /// The perform get by query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The collection of <see cref="IAnonymousCustomer"/> returned by the query.
        /// </returns>
        protected override IEnumerable<IAnonymousCustomer> PerformGetByQuery(IQuery<IAnonymousCustomer> query)
        {
            var sqlClause = GetBaseQuery(false);
            var translator = new SqlTranslator<IAnonymousCustomer>(sqlClause, query);
            var sql = translator.Translate();

            var dtos = Database.Fetch<AnonymousCustomerDto>(sql);

            return dtos.DistinctBy(x => x.Key).Select(dto => Get(dto.Key));
        }
    }
}
