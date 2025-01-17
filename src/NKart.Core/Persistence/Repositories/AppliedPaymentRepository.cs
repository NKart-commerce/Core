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
    /// The applied payment repository.
    /// </summary>
    internal class AppliedPaymentRepository : MerchelloPetaPocoRepositoryBase<IAppliedPayment>, IAppliedPaymentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppliedPaymentRepository"/> class.
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
        public AppliedPaymentRepository(IDatabaseUnitOfWork work, ILogger logger, ISqlSyntaxProvider sqlSyntax) 
            : base(work, logger, sqlSyntax)
        {
        }

        /// <summary>
        /// Gets an <see cref="IAppliedPayment"/> by it's key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="IAppliedPayment"/>.
        /// </returns>
        protected override IAppliedPayment PerformGet(Guid key)
        {
            var sql = GetBaseQuery(false)
                .Where(GetBaseWhereClause(), new { Key = key });

            var dto = Database.Fetch<AppliedPaymentDto>(sql).FirstOrDefault();

            if (dto == null)
                return null;

            var factory = new AppliedPaymentFactory();

            var payment = factory.BuildEntity(dto);

            return payment;
        }

        /// <summary>
        /// Gets all <see cref="IAppliedPayment"/>.
        /// </summary>
        /// <param name="keys">
        /// The keys.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{IAppliedPayment}"/>.
        /// </returns>
        protected override IEnumerable<IAppliedPayment> PerformGetAll(params Guid[] keys)
        {
            var dtos = new List<AppliedPaymentDto>();

            if (keys.Any())
            {
                // This is to get around the WhereIn max limit of 2100 parameters and to help with performance of each WhereIn query
                var keyLists = keys.Split(400).ToList();

                // Loop the split keys and get them
                foreach (var keyList in keyLists)
                {
                    dtos.AddRange(Database.Fetch<AppliedPaymentDto>(GetBaseQuery(false).WhereIn<AppliedPaymentDto>(x => x.Key, keyList, SqlSyntax)));
                }
            }
            else
            {
                dtos = Database.Fetch<AppliedPaymentDto>(GetBaseQuery(false));
            }

            var factory = new AppliedPaymentFactory();
            foreach (var dto in dtos)
            {
                yield return factory.BuildEntity(dto);
            }
        }

        /// <summary>
        /// Gets a collection of <see cref="IAppliedPayment"/> by a query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{IAppliedPayment}"/>.
        /// </returns>
        protected override IEnumerable<IAppliedPayment> PerformGetByQuery(IQuery<IAppliedPayment> query)
        {
            var sqlClause = GetBaseQuery(false);
            var translator = new SqlTranslator<IAppliedPayment>(sqlClause, query);
            var sql = translator.Translate();

            var dtos = Database.Fetch<PaymentDto>(sql);

            return dtos.DistinctBy(x => x.Key).Select(dto => Get(dto.Key));
        }

        /// <summary>
        /// The base SQL query.
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
               .From<AppliedPaymentDto>(SqlSyntax);

            return sql;
        }

        /// <summary>
        /// The base where clause.
        /// </summary>
        /// <returns>
        /// The <see cref="String"/>.
        /// </returns>
        protected override string GetBaseWhereClause()
        {
            return "merchAppliedPayment.pk = @Key";
        }

        /// <summary>
        /// The list of delete clauses.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{String}"/>.
        /// </returns>
        protected override IEnumerable<string> GetDeleteClauses()
        {
            var list = new List<string>
                {
                    "DELETE FROM merchAppliedPayment WHERE merchAppliedPayment.pk = @Key"
                };

            return list;
        }

        /// <summary>
        /// Adds a new item to the database.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected override void PersistNewItem(IAppliedPayment entity)
        {
            ((Entity)entity).AddingEntity();

            var factory = new AppliedPaymentFactory();
            var dto = factory.BuildDto(entity);

            Database.Insert(dto);
            entity.Key = dto.Key;
            entity.ResetDirtyProperties();
        }

        /// <summary>
        /// Updates an item in the database.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected override void PersistUpdatedItem(IAppliedPayment entity)
        {
            ((Entity)entity).UpdatingEntity();

            var factory = new AppliedPaymentFactory();
            var dto = factory.BuildDto(entity);

            Database.Update(dto);

            entity.ResetDirtyProperties();
        }

        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected override void PersistDeletedItem(IAppliedPayment entity)
        {
            var deletes = GetDeleteClauses();
            foreach (var delete in deletes)
            {
                Database.Execute(delete, new { entity.Key });
            }
        }
    }
}