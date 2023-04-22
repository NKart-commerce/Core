using System;
using NKart.Core.Models;
using NKart.Core.Models.Rdbms;
using NKart.Tests.Base.SqlSyntax;
using NUnit.Framework;
using Umbraco.Core.Persistence;

namespace NKart.Tests.UnitTests.Querying
{
    [TestFixture]
    [Category("SqlSyntax")]
    public class ShipCountrySqlClausesTest : BaseUsingSqlServerSyntax<IShipCountry>
    {
        /// <summary>
        /// Test to verify that the typed <see cref="ShipCountryDto"/> query matches generic "select * ..." query 
        /// </summary>
        [Test]
        public void Can_Verify_ShipCountry_Base_Sql_Clause()
        {
            //// Arrange
            var key = Guid.NewGuid();

            var expected = new Sql();
            expected.Select("*")
                .From("[merchShipCountry]")
                .Where("[merchShipCountry].[pk] = @0", new { key });

            //// Act
            var sql = new Sql();
            sql.Select("*")
                .From<ShipCountryDto>()
                .Where<ShipCountryDto>(x => x.Key == key);

            //// Assert
            Assert.That(sql.SQL, Is.EqualTo(expected.SQL));
        }
    }
}