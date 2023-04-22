using System;
using System.Configuration;
using NKart.Core;
using NKart.Core.Cache;
using NKart.Core.Gateways;
using NKart.Core.Gateways.Notification;
using NKart.Core.Gateways.Payment;
using NKart.Core.Gateways.Shipping;
using NKart.Core.Gateways.Taxation;
using NKart.Core.Observation;
using NKart.Core.Persistence.UnitOfWork;
using NKart.Core.Services;
using NKart.Examine.DataServices;
using NKart.Tests.Base.SqlSyntax;
using Moq;
using Umbraco.Core;


namespace NKart.Tests.IntegrationTests.TestHelpers
{
    using NKart.Core.Events;
    using NKart.Core.Persistence;

    using Umbraco.Core.Logging;

    internal class DataServiceMerchelloContext
    {
        public static IMerchelloContext GetMerchelloContext()
        {
            var syntax = (DbSyntax)Enum.Parse(typeof(DbSyntax), ConfigurationManager.AppSettings["syntax"]);
            // sets up the Umbraco SqlSyntaxProvider Singleton
            SqlSyntaxProviderTestHelper.EstablishSqlSyntax(syntax);

            var sqlSyntax = SqlSyntaxProviderTestHelper.SqlSyntaxProvider(syntax);

            //AutoMapperMappings.CreateMappings();
            var logger = Logger.CreateWithDefaultLog4NetConfiguration();
            var cache = new CacheHelper(
                new ObjectCacheRuntimeCacheProvider(),
                new StaticCacheProvider(),
                new NullCacheProvider());

            var serviceContext = new ServiceContext(new RepositoryFactory(cache, logger, sqlSyntax), new PetaPocoUnitOfWorkProvider(new Mock<ILogger>().Object), new Mock<ILogger>().Object, new TransientMessageFactory());
            return  new MerchelloContext(serviceContext,
                new GatewayContext(serviceContext, GatewayProviderResolver.Current),
                new CacheHelper(new NullCacheProvider(),
                                    new NullCacheProvider(),
                                    new NullCacheProvider()));        
        }
    }

    public class TestMerchelloDataService : MerchelloDataService
    {
        public TestMerchelloDataService()
            : base(DataServiceMerchelloContext.GetMerchelloContext())
        {
        }
    }
}
    