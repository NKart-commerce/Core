using NKart.Core.Models.TypeFields;
using NKart.Tests.Base.TypeFields;
using NUnit.Framework;

namespace NKart.Tests.UnitTests.TypeFields
{
    [TestFixture]
    [Category("TypeField")]
    public class ProductTypeFieldTests
    {
        [Test]
        public void Empty_custom_configurations_returns_null_type()
        {
            var type = new ProductTypeField().Custom("empty");

            Assert.AreEqual(TypeFieldMock.NullTypeField.Alias, type.Alias);
            Assert.AreEqual(TypeFieldMock.NullTypeField.TypeKey, type.TypeKey);
        }
    }
}
