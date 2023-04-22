using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKart.Core;
using NKart.Core.Models;
using NKart.Core.Services;
using NKart.Tests.Base.DataMakers;
using NKart.Tests.Base.TestHelpers;
using NKart.Tests.IntegrationTests.TestHelpers;
using NKart.Web.Models.ContentEditing;
using NUnit.Framework;

namespace NKart.Tests.IntegrationTests.Api
{
    [TestFixture]
    public class ProductApiController : MerchelloAllInTestBase
    {

        private IProductService _productService;
        private IProductVariantService _productVariantService;

        [TestFixtureSetUp]
        public override void FixtureSetup()
        {
            base.FixtureSetup();

            _productService = MerchelloContext.Current.Services.ProductService;
            _productVariantService = MerchelloContext.Current.Services.ProductVariantService;

            DbPreTestDataWorker.DeleteAllProducts();
        }

        [Test, Category("LongRunning")]
        public void Can_Add_A_Product_From_New_Product_Display()
        {
            //// Arrange
            var display = MockProductDataMaker.MockProductDisplayForInserting();

            //// Act
            var product = AddProduct(display);

            //// Assert
            Assert.NotNull(product);
            Assert.IsTrue(product.HasIdentity);
        }


        private IProduct AddProduct(ProductDisplay product)
        {
            var p = _productService.CreateProduct(product.Name, product.Sku, product.Price);
            p = product.ToProduct(p);
            _productService.Save(p);
            return p;
        }

        
    }
}
