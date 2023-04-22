namespace NKart.Tests.IntegrationTests.PackageActions
{
    using System;
    using System.Configuration;

    using NKart.Core.Persistence.Migrations.Initial;
    using NKart.Tests.Base.SqlSyntax;
    using NKart.Tests.Base.TestHelpers;
    using NKart.Web.PackageActions;

    using NUnit.Framework;

    using Umbraco.Core.Persistence;

    [TestFixture]
    public class CreateDatabasePackageActionTest
    {
        private UmbracoDatabase _database;

        private DbPreTestDataWorker _worker;

        [TestFixtureSetUp]
        public void Init()
        {
            var syntax = (DbSyntax)Enum.Parse(typeof(DbSyntax), ConfigurationManager.AppSettings["syntax"]);
            _worker = new DbPreTestDataWorker {SqlSyntax = syntax };

            var schemaHelper = new DatabaseSchemaHelper(_worker.Database, _worker.TestLogger, _worker.SqlSyntaxProvider);
            var deletions = new DatabaseSchemaCreation(_worker.Database, _worker.TestLogger, schemaHelper, _worker.SqlSyntaxProvider);
            deletions.UninstallDatabaseSchema();
        }

        [Test]
        public void Can_ExecuteThePackageAction()
        {
            var packageAction = new CreateDatabase(_worker.Database, _worker.SqlSyntaxProvider, _worker.TestLogger);
            packageAction.Execute("merchello", null);
        }
    }
}