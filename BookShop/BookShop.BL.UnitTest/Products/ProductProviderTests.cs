using System.Linq.Expressions;
using BookShop.BL.UnitTest.Mapper;
using BookShop.DataAccess.Entities;
using BookShop.DataAccess;
using Moq;
using BookShop.BL.Products;
using BookShop.BL.Customers;

namespace BookShop.BL.UnitTest.Products
{
    [TestFixture]
    public class ProductProviderTests
    {
        [Test]
        public void testGetAllProducts()
        {
            Expression expression = null;
            Mock<IRepository<ProductEntity>> productsRepository = new Mock<IRepository<ProductEntity>>();
            productsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
                .Callback((Expression<Func<ProductEntity, bool>> x) => { expression = x; });
            var productsProvider = new ProductsProvider(productsRepository.Object, MapperHelper.Mapper);
            var products = productsProvider.GetProducts();

            productsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<ProductEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
