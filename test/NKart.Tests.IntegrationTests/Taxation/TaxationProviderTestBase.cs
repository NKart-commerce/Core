using NKart.Core.Services;
using NKart.Tests.IntegrationTests.TestHelpers;
using NUnit.Framework;

namespace NKart.Tests.IntegrationTests.Taxation
{
    public class TaxationProviderTestBase : DatabaseIntegrationTestBase
    {
        protected IGatewayProviderService GatewayProviderService;
        

        [TestFixtureSetUp]
        public override void FixtureSetup()
        {
            base.FixtureSetup();

            //var dtos = PreTestDataWorker.Database.Query<GatewayProviderSettingsDto>("SELECT * FROM merchGatewayProviderSettings");

            //if (!dtos.Any())
            //{
            //    Assert.Ignore("Default GatewayProviders are not installed.");
            //}

            GatewayProviderService = PreTestDataWorker.GatewayProviderService;

            
        }
    }
}