using BookShop.BL.Products.Entities;
using BookShop.DataAccess.Entities;
using BookShop.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Products
{
    public class ProductsManager : IProductsManager
    {
        private readonly IRepository<ProductEntity> _productsRepository;
        private readonly IMapper _mapper;
        public ProductsManager(IRepository<ProductEntity> productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public ProductModel CreateProduct(CreateProductModel model)
        {
            var entity = _mapper.Map<ProductEntity>(model);

            _productsRepository.Save(entity);

            return _mapper.Map<ProductModel>(entity);
        }
        public void DeleteProduct(Guid id)
        {
            var entity = _productsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Product not found");
            _productsRepository.Delete(entity);
        }
        public ProductModel UpdateProduct(Guid id, UpdateProductModel model)
        {
            var entity = _productsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Product not found");
            entity.Title = model.Title;
            entity.Price = model.Price;
            entity.Annotation = model.Annotation;
            entity.Status = (int)model.Status;
            _productsRepository.Save(entity);
            return _mapper.Map<ProductModel>(entity);
        }
    }
}
