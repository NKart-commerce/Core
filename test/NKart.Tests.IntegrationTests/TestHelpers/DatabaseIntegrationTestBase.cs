using System;
using Examine;
using NKart.Core;
using NKart.Core.Cache;
using NKart.Core.Gateways;
using NKart.Core.Observation;
using NKart.Core.Persistence.UnitOfWork;
using NKart.Core.Services;
using NKart.Tests.Base.TestHelpers;
using NKart.Web;
using NUnit.Framework;
using Umbraco.Core;

namespace NKart.Tests.IntegrationTests.TestHelpers
{
    using System.Configuration;

    using NKart.Core.Events;
    using NKart.Core.Persistence;
    using NKart.Tests.Base.SqlSyntax;

    using Moq;

    using umbraco.BusinessLogic;

    using Umbraco.Core.Logging;
    using Umbraco.Web;

    public abstract class DatabaseIntegrationTestBase
    {
        //protected IMerchelloContext MerchelloContext { get; private set; }
        private DbPreTestDataWorker _dbPreTestDataWorker;

        [TestFixtureSetUp]
        public virtual void FixtureSetup()
        {
            var syntax = (DbSyntax)Enum.Parse(typeof(DbSyntax), ConfigurationManager.AppSettings["syntax"]);

            // sets up the Umbraco SqlSyntaxProvider Singleton OBSOLETE
            SqlSyntaxProviderTestHelper.EstablishSqlSyntax(syntax);

            var sqlSyntax = SqlSyntaxProviderTestHelper.SqlSyntaxProvider(syntax);

            //AutoMapperMappings.CreateMappings();
            var logger = Logger.CreateWithDefaultLog4NetConfiguration();

            var cache = new CacheHelper(
                new ObjectCacheRuntimeCacheProvider(),
                new StaticCacheProvider(),
                new NullCacheProvider());

            var serviceContext = new ServiceContext(new RepositoryFactory(cache, logger, sqlSyntax), new PetaPocoUnitOfWorkProvider(logger), logger, new TransientMessageFactory());

            _dbPreTestDataWorker = new DbPreTestDataWorker(serviceContext);

            // Umbraco Application
            var applicationMock = new Mock<UmbracoApplication>();
            var applicationContextMock = new Mock<ApplicationContext>();

            // Merchello CoreBootStrap
            var bootManager = new Web.WebBootManager(logger, _dbPreTestDataWorker.SqlSyntaxProvider);
            bootManager.Initialize(applicationContextMock.Object);


            if (MerchelloContext.Current == null) Assert.Ignore("MerchelloContext.Current is null");


            //if (!GatewayProviderResolver.HasCurrent)
            //    GatewayProviderResolver.Current = new GatewayProviderResolver(
            //    PluginManager.Current.ResolveGatewayProviders(),
            //    serviceContext.GatewayProviderService,
            //    new NullCacheProvider());                



            //MerchelloContext = new MerchelloContext(serviceContext,
            //    new GatewayContext(serviceContext, GatewayProviderResolver.Current),
            //    new CacheHelper(new NullCacheProvider(),
            //                        new NullCacheProvider(),
            //                        new NullCacheProvider()));

            //if (!TriggerResolver.HasCurrent)
            //    TriggerResolver.Current = new TriggerResolver(PluginManager.Current.ResolveObservableTriggers());

            //if (!MonitorResolver.HasCurrent)
            //    MonitorResolver.Current = new MonitorResolver(MerchelloContext.Gateways.Notification, PluginManager.Current.ResolveObserverMonitors());

            
            ExamineManager.Instance.IndexProviderCollection["MerchelloProductIndexer"].RebuildIndex();  
            ExamineManager.Instance.IndexProviderCollection["MerchelloCustomerIndexer"].RebuildIndex();
            
        }

        protected DbPreTestDataWorker PreTestDataWorker {
            get { return _dbPreTestDataWorker; }
        }

    }
}
