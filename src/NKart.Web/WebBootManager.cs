using NKart.Web.Pluggable;
using NKart.Web.Reporting;
using NKart.Web.Search;
using NKart.Web.Ui;

namespace NKart.Web
{
    using System;

    using NKart.Core;
    using NKart.Core.Logging;
    using NKart.Core.Marketing.Offer;
    using NKart.Web.Pluggable;
    using NKart.Web.Reporting;
    using NKart.Web.Search;
    using NKart.Web.Ui;

    using Umbraco.Core;
    using Umbraco.Core.Logging;
    using Umbraco.Core.Persistence.SqlSyntax;

    using CoreBootManager = NKart.Core.CoreBootManager;
    using IBootManager = NKart.Core.IBootManager;

    /// <summary>
    /// The web boot manager.
    /// </summary>
    internal class WebBootManager : CoreBootManager
    {
        /// <summary>
        /// Designates if this boot manager is being used by a Test
        /// </summary>
        private readonly bool _isForTesting;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBootManager"/> class. 
        /// A boot strap class for the Merchello plugin which initializes all objects including the Web portion of the plugin
        /// </summary>
        public WebBootManager(ApplicationContext applicationContext)
            : base(LoggerResolver.Current.Logger, applicationContext.DatabaseContext.SqlSyntax)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBootManager"/> class. 
        /// Constructor for unit tests, ensures some resolvers are not initialized
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="sqlSyntax">
        /// The <see cref="ISqlSyntaxProvider"/>
        /// </param>
        /// <param name="isForTesting">
        /// The is For Testing.
        /// </param>
        internal WebBootManager(ILogger logger, ISqlSyntaxProvider sqlSyntax, bool isForTesting = false)
            : base(logger, sqlSyntax)
        {
            _isForTesting = isForTesting;
        }


        /// <summary>
        /// Initialize objects before anything during the boot cycle happens
        /// </summary>
        /// <returns>The <see cref="IBootManager"/></returns>
        public override IBootManager Initialize(ApplicationContext context)
        {
            EnsureDatabase();

            base.Initialize(context);

            // initialize the AutoMapperMappings
            AutoMapperMappings.CreateMappings();



            return this;
        }

        /// <summary>
        /// The ensure database.
        /// </summary>
        protected void EnsureDatabase()
        {
            Logger.Info<WebBootManager>("Verifying Merchello Database is present.");
            var database = GetDatabase();
            var manager = new WebMigrationManager(database, SqlSyntax, Logger);
            if (!manager.EnsureDatabase())
            {
                Logger.Info<WebBootManager>("Merchello database tables installed");
            }
        }

        /// <summary>
        /// Initializer resolvers.
        /// </summary>
        protected override void InitializeResolvers()
        {
            base.InitializeResolvers();

            if (!PaymentMethodUiControllerResolver.HasCurrent)
            PaymentMethodUiControllerResolver.Current = new PaymentMethodUiControllerResolver(PluginManager.Current.ResolvePaymentMethodUiControllers());

            if (!ReportApiControllerResolver.HasCurrent)
            ReportApiControllerResolver.Current = new ReportApiControllerResolver(PluginManager.Current.ResolveReportApiControllers());

            if (!OfferProviderResolver.HasCurrent)
                OfferProviderResolver.Current = new OfferProviderResolver(PluginManager.Current.ResolveOfferProviders(), MerchelloContext.Current.Services.OfferSettingsService);

            if(!OfferComponentResolver.HasCurrent)
                OfferComponentResolver.Current = new OfferComponentResolver(PluginManager.Current.ResolveOfferComponents(), OfferProviderResolver.Current);

            if (!ProxyQueryManager.HasCurrent)
                ProxyQueryManager.Current = new ProxyQueryManager(MerchelloContext.Current.Cache.RequestCache);
        }

        /// <summary>
        /// Overrides the base GetMultiLogger.
        /// </summary>
        /// <returns>
        /// The <see cref="IMultiLogger"/>.
        /// </returns>
        protected override IMultiLogger GetMultiLogger()
        {
            try
            {
                var remoteLogger = PluggableObjectHelper.GetInstance<RemoteLoggerBase>("RemoteLogger");
                return new MultiLogger(Logger, remoteLogger);
            }
            catch (Exception ex)
            {
                Logger.WarnWithException<WebBootManager>("Failed to instantiate remote logger. Returning default logger", ex, () => new object[] { });
                return new MultiLogger();
            }
        }
    }
}
