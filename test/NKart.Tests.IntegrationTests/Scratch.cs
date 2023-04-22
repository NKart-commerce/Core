namespace NKart.Tests.IntegrationTests
{
    using NKart.Core;
    using NKart.Tests.Base.TestHelpers;

    using NUnit.Framework;

    [TestFixture]
    public class Scratch : MerchelloContextOnlyBase
    {
        [Test]
        public void Can_Get_MerchelloContext()
        {
            var context = MerchelloContext.Current;
            Assert.NotNull(context);
        }
    }
}