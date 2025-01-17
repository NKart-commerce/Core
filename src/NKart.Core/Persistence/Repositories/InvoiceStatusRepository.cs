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
    /// The invoice status repository.
    /// </summary>
    internal class InvoiceStatusRepository : MerchelloPetaPocoRepositoryBase<IInvoiceStatus>, IInvoiceStatusRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceStatusRepository"/> class.
        /// </summary>
        /// <param name="work">
        /// The work.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="sqlSyntax">
        /// The SQL Syntax.
        /// </param>
        public InvoiceStatusRepository(IDatabaseUnitOfWork work, ILogger logger, ISqlSyntaxProvider sqlSyntax)
            : base(work, logger, sqlSyntax)
        {
        }

        /// <summary>
        /// Gets a <see cref="IInvoice"/> by it's unique key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="IInvoiceStatus"/>.
        /// </returns>
        protected override IInvoiceStatus PerformGet(Guid key)
        {
            var sql = GetBaseQuery(false)
                .Where(GetBaseWhereClause(), new { Key = key });

            var dto = Database.Fetch<InvoiceStatusDto>(sql).FirstOrDefault();

            if (dto == null)
                return null;

            var factory = new InvoiceStatusFactory();

            var invoiceStatus = factory.BuildEntity(dto);

            return invoiceStatus;
        }

        /// <summary>
        /// Gets a collection of all <see cref="IInvoiceStatus"/>.
        /// </summary>
        /// <param name="keys">
        /// The keys.
        /// </param>
        /// <returns>
        /// A collection of <see cref="IInvoiceStatus"/>.
        /// </returns>
        protected override IEnumerable<IInvoiceStatus> PerformGetAll(params Guid[] keys)
        {
            var dtos = new List<InvoiceStatusDto>();

            if (keys.Any())
            {
                // This is to get around the WhereIn max limit of 2100 parameters and to help with performance of each WhereIn query
                var keyLists = keys.Split(400).ToList();

                // Loop the split keys and get them
                foreach (var keyList in keyLists)
                {
                    dtos.AddRange(Database.Fetch<InvoiceStatusDto>(GetBaseQuery(false).WhereIn<InvoiceStatusDto>(x => x.Key, keyList, SqlSyntax)));
                }
            }
            else
            {
                dtos = Database.Fetch<InvoiceStatusDto>(GetBaseQuery(false));
            }

            var factory = new InvoiceStatusFactory();
            foreach (var dto in dtos)
            {
                yield return factory.BuildEntity(dto);
            }
        }

        /// <summary>
        /// Gets a collection of <see cref="IInvoiceStatus"/> by query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// A collection of <see cref="IInvoiceStatus"/>.
        /// </returns>
        protected override IEnumerable<IInvoiceStatus> PerformGetByQuery(IQuery<IInvoiceStatus> query)
        {
            var sqlClause = GetBaseQuery(false);
            var translator = new SqlTranslator<IInvoiceStatus>(sqlClause, query);
            var sql = translator.Translate();

            var dtos = Database.Fetch<InvoiceStatusDto>(sql);

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
               .From<InvoiceStatusDto>(SqlSyntax);

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
            return "merchInvoiceStatus.pk = @Key";
        }

        /// <summary>
        /// Gets the delete clauses.
        /// </summary>
        /// <returns>
        /// The collection of delete clauses.
        /// </returns>
        protected override IEnumerable<string> GetDeleteClauses()
        {
            var list = new List<string>
                {                    
                    "DELETE FROM merchInvoiceStatus WHERE pk = @Key"
                };

            return list;
        }

        /// <summary>
        /// Persists a new invoice.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected override void PersistNewItem(IInvoiceStatus entity)
        {
            ((Entity)entity).AddingEntity();

            var factory = new InvoiceStatusFactory();
            var dto = factory.BuildDto(entity);

            Database.Insert(dto);
            entity.Key = dto.Key;
            entity.ResetDirtyProperties();
        }

        /// <summary>
        /// Persists an updated invoice.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected override void PersistUpdatedItem(IInvoiceStatus entity)
        {
            ((Entity)entity).UpdatingEntity();

            var factory = new InvoiceStatusFactory();
            var dto = factory.BuildDto(entity);

            Database.Update(dto);

            entity.ResetDirtyProperties();
        }
    }
}