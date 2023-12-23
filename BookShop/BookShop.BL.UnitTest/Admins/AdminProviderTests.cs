using System.Linq.Expressions;
using BookShop.BL.Admins;
using BookShop.BL.UnitTest.Mapper;
using BookShop.DataAccess;
using BookShop.DataAccess.Entities;
using Moq;
using NUnit.Framework;

namespace BookShop.BL.UnitTest.Admins
{
    [TestFixture]
    public class AdminProviderTests
    {
        [Test]
        public void testGetAllAdmins()
        {
            Expression expression = null;
            Mock<IRepository<AdminEntity>> adminsRepository = new Mock<IRepository<AdminEntity>>();
            adminsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<AdminEntity, bool>>>()))
                .Callback((Expression<Func<AdminEntity, bool>> x) => { expression = x; });
            var adminsProvider = new AdminsProvider(adminsRepository.Object, MapperHelper.Mapper);
            var admins = adminsProvider.GetAdmins();

            adminsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<AdminEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
