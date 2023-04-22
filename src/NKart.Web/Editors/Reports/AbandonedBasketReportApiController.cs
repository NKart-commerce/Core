﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NKart.Core;
using NKart.Core.Configuration;
using NKart.Core.Services;
using NKart.Web.Models.ContentEditing;
using NKart.Web.Models.Querying;
using NKart.Web.Models.Reports;
using NKart.Web.Reporting;
using NKart.Web.Trees;
using Umbraco.Web.Mvc;

namespace NKart.Web.Editors.Reports
{
    /// <summary>
    ///     The controller responsible for rendering the abandoned basket report.
    /// </summary>
    /// <summary>
    ///     API Controller responsible for the Sales Search Report
    /// </summary>
    [BackOfficeTree("abandonedBasket", "reports", "Abandoned Baskets", "icon-shopping-basket-alt-2", "/app_plugins/merchello/backoffice/merchello/abandonedBasket.html", 1)]
    [PluginController("Merchello")]
    public class AbandonedBasketReportApiController : ReportController
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AbandonedBasketReportApiController" /> class.
        /// </summary>
        public AbandonedBasketReportApiController()
            : this(Core.MerchelloContext.Current)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AbandonedBasketReportApiController" /> class.
        /// </summary>
        /// <param name="merchelloContext">
        ///     The merchello context.
        /// </param>
        public AbandonedBasketReportApiController(IMerchelloContext merchelloContext)
            : base(merchelloContext)
        {
            _itemCacheService = merchelloContext.Services.ItemCacheService;

            _invoiceService = merchelloContext.Services.InvoiceService;

            _maxDays = MerchelloConfiguration.Current.AnonymousCustomersMaxDays;
            _startDate = DateTime.Today.AddDays(-_maxDays);
            _endDate = DateTime.Today;
        }

        /// <summary>
        ///     Gets the base url definition for Server Variables Parsing.e
        /// </summary>
        public override KeyValuePair<string, object> BaseUrl
        {
            get
            {
                return GetBaseUrl<AbandonedBasketReportApiController>("merchelloAbandonedBasketApiBaseUrl");
            }
        }

        /// <summary>
        ///     Gets the default report data for initial page load.
        /// </summary>
        /// <returns>
        ///     The <see cref="QueryResultDisplay" />.
        /// </returns>
        [HttpGet]
        public override QueryResultDisplay GetDefaultReportData()
        {
            var anonymousBasketCount =
                _itemCacheService.Count(_itemCacheType, CustomerType.Anonymous, _startDate, _endDate);
            var anonymousCheckoutCount = _invoiceService.CountInvoices(_startDate, _endDate, CustomerType.Anonymous);
            var customerBasketCount =
                _itemCacheService.Count(_itemCacheType, CustomerType.Customer, _startDate, _endDate);
            var customerCheckoutCount = _invoiceService.CountInvoices(_startDate, _endDate, CustomerType.Customer);


            var result = new QueryResultDisplay
            {
                TotalItems = 1,
                TotalPages = 1,
                CurrentPage = 1,
                ItemsPerPage = 1,
                Items = new[]
                {
                    new AbandonedBasketResult
                    {
                        ConfiguredDays = _maxDays,
                        StartDate = _startDate,
                        EndDate = _endDate,
                        AnonymousBasketCount = anonymousBasketCount,
                        AnonymousCheckoutCount = anonymousCheckoutCount,
                        AnonymousCheckoutPercent = GetCheckoutPercent(anonymousBasketCount, anonymousCheckoutCount),
                        CustomerBasketCount = customerBasketCount,
                        CustomerCheckoutCount = customerCheckoutCount,
                        CustomerCheckoutPercent = GetCheckoutPercent(customerBasketCount, customerCheckoutCount)
                    }
                }
            };

            return result;
        }

        /// <summary>
        ///     Gets the customers saved baskets.
        /// </summary>
        /// <param name="query">
        ///     The query.
        /// </param>
        /// <returns>
        ///     The <see cref="QueryResultDisplay" />.
        /// </returns>
        [HttpPost]
        public QueryResultDisplay GetCustomerSavedBaskets(QueryDisplay query)
        {
            var page = _itemCacheService.GetCustomerItemCachePage(
                _itemCacheType,
                _startDate,
                _endDate.AddDays(2),
                query.CurrentPage + 1,
                query.ItemsPerPage,
                query.SortBy,
                query.SortDirection);

            return new QueryResultDisplay
            {
                Items = page.Items.Select(x => x.ToCustomerItemCacheDisplay()),
                CurrentPage = page.CurrentPage - 1,
                ItemsPerPage = page.ItemsPerPage,
                TotalPages = page.TotalPages,
                TotalItems = page.TotalItems
            };
        }

        /// <summary>
        ///     Calculates the checkout percentage.
        /// </summary>
        /// <param name="basketCount">
        ///     The basket count.
        /// </param>
        /// <param name="checkoutCount">
        ///     The checkout count.
        /// </param>
        /// <returns>
        ///     The <see cref="decimal" />.
        /// </returns>
        private decimal GetCheckoutPercent(int basketCount, int checkoutCount)
        {
            if (basketCount + checkoutCount == 0)
            {
                return 0;
            }

            return checkoutCount / (decimal) (basketCount + checkoutCount) * 100;
        }

        #region Fields

        /// <summary>
        ///     The item cache type.
        /// </summary>
        private readonly ItemCacheType _itemCacheType = ItemCacheType.Basket;

        /// <summary>
        ///     The item cache service.
        /// </summary>
        private readonly IItemCacheService _itemCacheService;

        /// <summary>
        ///     The invoice service.
        /// </summary>
        private readonly IInvoiceService _invoiceService;

        /// <summary>
        ///     The start date.
        /// </summary>
        private readonly DateTime _startDate;

        /// <summary>
        ///     The end date.
        /// </summary>
        private readonly DateTime _endDate;

        /// <summary>
        ///     The max days.
        /// </summary>
        private readonly int _maxDays;

        #endregion
    }
}