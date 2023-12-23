using System.Linq.Expressions;
using BookShop.BL.UnitTest.Mapper;
using BookShop.DataAccess.Entities;
using BookShop.DataAccess;
using Moq;
using BookShop.BL.Customers;

namespace BookShop.BL.UnitTest.Customers
{
    [TestFixture]
    public class CustomerProviderTests
    {
        [Test]
        public void testGetAllCustomers()
        {
            Expression expression = null;
            Mock<IRepository<CustomerEntity>> customersRepository = new Mock<IRepository<CustomerEntity>>();
            customersRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<CustomerEntity, bool>>>()))
                .Callback((Expression<Func<CustomerEntity, bool>> x) => { expression = x; });
            var customersProvider = new CustomersProvider(customersRepository.Object, MapperHelper.Mapper);
            var customers = customersProvider.GetCustomers();

            customersRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<CustomerEntity, bool>>>()), Times.Exactly(1));

        }
    }
}
