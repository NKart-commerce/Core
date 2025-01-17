﻿using NKart.Core.Models;
using NKart.Core.Models.DetachedContent;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Factories
{
    using System;
    using System.Linq;

    using NKart.Core.Models;
    using NKart.Core.Models.DetachedContent;
    using NKart.Core.Models.Rdbms;

    /// <summary>
    /// The product factory.
    /// </summary>
    internal class ProductFactory : IEntityFactory<IProduct, ProductDto>
    {
        /// <summary>
        /// The product variant factory.
        /// </summary>
        private readonly ProductVariantFactory _productVariantFactory;

        /// <summary>
        /// The product option collection.
        /// </summary>
        private readonly Func<Guid, ProductOptionCollection> _getProductOptionCollection;

        /// <summary>
        /// The product variant collection.
        /// </summary>
        private readonly Func<Guid, ProductVariantCollection> _getProductVariantCollection;


        /// <summary>
        /// Initializes a new instance of the <see cref="ProductFactory"/> class.
        /// </summary>
        public ProductFactory()
            : this(
                new ProductAttributeCollection(),
                new CatalogInventoryCollection(),
                poc => new ProductOptionCollection(),
                pvc => new ProductVariantCollection(),
                new DetachedContentCollection<IProductVariantDetachedContent>())
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductFactory"/> class.
        /// </summary>
        /// <param name="getProductAttributes">
        /// The product attributes.
        /// </param>
        /// <param name="getCatalogInventories">
        /// The catalog inventories.
        /// </param>
        /// <param name="getProductOptions">
        /// The product options.
        /// </param>
        /// <param name="getProductVariantCollection">
        /// The product variant collection.
        /// </param>
        /// <param name="getDetachedContentCollection">
        /// Gets the detached content collection
        /// </param>
        public ProductFactory(
            ProductAttributeCollection getProductAttributes,
            CatalogInventoryCollection getCatalogInventories,
            Func<Guid, ProductOptionCollection> getProductOptions,
            Func<Guid, ProductVariantCollection> getProductVariantCollection,
            DetachedContentCollection<IProductVariantDetachedContent> getDetachedContentCollection)
        {
            _productVariantFactory = new ProductVariantFactory(getProductAttributes, getCatalogInventories, getDetachedContentCollection);
            this._getProductOptionCollection = getProductOptions;
            this._getProductVariantCollection = getProductVariantCollection;
        }

        /// <summary>
        /// The build entity.
        /// </summary>
        /// <param name="dto">
        /// The dto.
        /// </param>
        /// <returns>
        /// The <see cref="IProduct"/>.
        /// </returns>
        public IProduct BuildEntity(ProductDto dto)
        {
            var variant = _productVariantFactory.BuildEntity(dto.ProductVariantDto);
            var product = new Product(variant)
            {
                Key = dto.Key,
                ProductOptions = this._getProductOptionCollection.Invoke(dto.Key),
                ProductVariants = this._getProductVariantCollection.Invoke(dto.Key),
                UpdateDate = dto.UpdateDate,
                CreateDate = dto.CreateDate
            };

            product.ResetDirtyProperties();

            return product;
        }

        /// <summary>
        /// The build dto.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="ProductDto"/>.
        /// </returns>
        public ProductDto BuildDto(IProduct entity)
        {
            var dto = new ProductDto()
            {
                Key = entity.Key,
                UpdateDate = entity.UpdateDate,
                CreateDate = entity.CreateDate,
                ProductVariantDto = _productVariantFactory.BuildDto(((Product)entity).MasterVariant)
            };

            return dto;
        }
    }
}
