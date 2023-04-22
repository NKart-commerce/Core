using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using NKart.Core.Models;
using NKart.Core.Models.Rdbms;
using NKart.Tests.Base.SqlSyntax;
using NUnit.Framework;
using Umbraco.Core.Persistence;

namespace NKart.Tests.UnitTests.Querying
{
    [TestFixture]
    [Category("SqlSyntax")]
    public class PaymentSqlClausesTests : BaseUsingSqlServerSyntax<IPayment>
    {
        /// <summary>
        /// Test to verify that the typed <see cref="PaymentDto"/> query matches generic "select * ..." query 
        /// </summary>
        [Test]
        public void Can_Verify_Payment_Base_Sql_Clause()
        {
            //// Arrange
            var key = Guid.NewGuid();

            var expected = new Sql();
            expected.Select("*")
                .From("[merchPayment]")
                .InnerJoin("[merchCustomer]").On("[merchPayment].[customerKey] = [merchCustomer].[pk]")                
                .Where("[merchPayment].[pk] = @0", new { key });

            //// Act
            var sql = new Sql();
            sql.Select("*")
                .From<PaymentDto>()
                .InnerJoin<CustomerDto>()
                .On<PaymentDto, CustomerDto>(left => left.CustomerKey, right => right.Key)                                
                .Where<PaymentDto>(x => x.Key == key);

            //// Assert
            Assert.That(sql.SQL, Is.EqualTo(expected.SQL));
        }

    }
}
