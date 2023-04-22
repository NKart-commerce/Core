namespace NKart.Tests.IntegrationTests.BootManager
{
    using System;
    using System.Configuration;

    using NKart.Core.Persistence.Migrations.Analytics;
    using NKart.Core.Persistence.UnitOfWork;
    using NKart.Tests.Base.SqlSyntax;
    using NKart.Web;

    using NUnit.Framework;

    using Umbraco.Core.Logging;
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.SqlSyntax;

    [TestFixture]
    public class WebBootManagerTests
    {
        private ISqlSyntaxProvider _sqlSyntax;

        private ILogger _logger;

        private Database _database;

        //[TestFixtureSetUp]
        public void Init()
        {
            var syntax = (DbSyntax)Enum.Parse(typeof(DbSyntax), ConfigurationManager.AppSettings["syntax"]);
            // sets up the Umbraco SqlSyntaxProvider Singleton
            SqlSyntaxProviderTestHelper.EstablishSqlSyntax(syntax);

            _sqlSyntax = SqlSyntaxProviderTestHelper.SqlSyntaxProvider(syntax);

            //AutoMapperMappings.CreateMappings();
            _logger = Logger.CreateWithDefaultLog4NetConfiguration();

            _database = new PetaPocoUnitOfWorkProvider(_logger).GetUnitOfWork().Database;
        }

        //[Test]
        public void Can_EnsureDatabaseIsInstalled()
        {
            var manager = new WebMigrationManager(_database, _sqlSyntax, _logger);
            var installed = manager.EnsureDatabase();
            Assert.IsTrue(installed);
        }

        //[Test]
        public void Can_CreateAMigrationRecord()
        {
            var record = new MigrationRecord();

            Assert.NotNull(record);
        }
    }
}
