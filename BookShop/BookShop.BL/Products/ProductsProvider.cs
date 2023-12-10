using BookShop.BL.Products.Entities;
using BookShop.DataAccess.Entities;
using BookShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BookShop.BL.Products
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly IMapper _mapper;

        public ProductsProvider(IRepository<ProductEntity> productsRepository, IMapper mapper)
        {
            _productRepository = productsRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductModel> GetProducts(ProductModelFilter modelFilter = null)
        {
            var minimumPrice = modelFilter.MinimumPrice;
            var maximumPrice = modelFilter.MaximumPrice;
            var status = modelFilter.Status;
            var publishingHouseId = modelFilter.PublishingHouseId;
            var languageId = modelFilter.LanguageId;
            var productType = modelFilter.ProductType;

            var products = _productRepository.GetAll(x =>
            (minimumPrice == null || minimumPrice < x.Price) &&
            (maximumPrice == null || maximumPrice > x.Price) &&
            (status == null || status == x.Status) &&
            (publishingHouseId == null || publishingHouseId == x.PublishingHouseId) &&
            (languageId == null || languageId == x.LanguageId) &&
            (productType == null || productType == x.ProductType));


            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public ProductModel GetProductInfo(Guid id)
        {
            var product = _productRepository.GetById(id);
            if (product is null)
                throw new ArgumentException("Product not found.");

            return _mapper.Map<ProductModel>(product);
        }
    }
}
