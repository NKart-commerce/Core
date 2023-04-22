using Moq;
using Umbraco.Core;

namespace NKart.Tests.Base.TestHelpers
{
    using NKart.Core;
    using NKart.Web;

    using NUnit.Framework;

    public abstract class MerchelloContextOnlyBase
    {
        [TestFixtureSetUp]
        public virtual void FixtureSetup()
        {
            // Sets Umbraco SqlSytax and ensure database is setup
            var dbPreTestDataWorker = new DbPreTestDataWorker();
            var applicationContext = new Mock<ApplicationContext>();

            // Merchello CoreBootStrap
            var bootManager = new WebBootManager(dbPreTestDataWorker.TestLogger, dbPreTestDataWorker.SqlSyntaxProvider);
            bootManager.Initialize(applicationContext.Object);


            if (MerchelloContext.Current == null) Assert.Ignore("MerchelloContext.Current is null");
        }
    }
}