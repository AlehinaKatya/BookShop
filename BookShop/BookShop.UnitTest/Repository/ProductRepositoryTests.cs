using BookShop.DataAccess;
using BookShop.DataAccess.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace BookShop.UnitTest.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class ProductRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllProductsTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var publishingHouse = new PublishingHouseEntity()
            {
                Title = "My Publishing House",
                ExternalId = Guid.NewGuid()
            };
            context.PublishingHouses.Add(publishingHouse);
            context.SaveChanges();

            var language = new LanguageEntity()
            {
                Title = "My Language",
                ExternalId = Guid.NewGuid()
            };
            context.Languages.Add(language);
            context.SaveChanges();

            var products = new ProductEntity[]
            {
            new ProductEntity()
            {
                Title = "Test1",
                Price = 500,
                Status = 0,
                Annotation = "Test1",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2023,
                ExternalId = Guid.NewGuid()
            },
            new ProductEntity()
            {
                Title = "Test2",
                Price = 600,
                Status = 0,
                Annotation = "Test2",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2022,
                ExternalId = Guid.NewGuid()
            }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            //execute
            var repository = new Repository<ProductEntity>(DbContextFactory);
            var actualProducts = repository.GetAll();

            //assert        
            actualProducts.Should().BeEquivalentTo(products, options => options.Excluding(x => x.Annotation)
                .Excluding(x => x.PublishingHouse)
                .Excluding(x => x.Language));
        }

        [Test]
        public void GetAllProductsWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var publishingHouse = new PublishingHouseEntity()
            {
                Title = "My Publishing House",
                ExternalId = Guid.NewGuid()
            };
            context.PublishingHouses.Add(publishingHouse);
            context.SaveChanges();

            var language = new LanguageEntity()
            {
                Title = "My Language",
                ExternalId = Guid.NewGuid()
            };
            context.Languages.Add(language);
            context.SaveChanges();

            var products = new ProductEntity[]
            {
            new ProductEntity()
            {
                Title = "Test1",
                Price = 500,
                Status = 0,
                Annotation = "Test1",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2023,
                ExternalId = Guid.NewGuid()
            },
            new ProductEntity()
            {
                Title = "Test2",
                Price = 600,
                Status = 0,
                Annotation = "Test2",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2022,
                ExternalId = Guid.NewGuid()
            }
            };
            context.Products.AddRange(products);
            context.SaveChanges();
            //execute

            var repository = new Repository<ProductEntity>(DbContextFactory);
            var actualProducts = repository.GetAll(x => x.Title == "Test2").ToArray();

            //assert
            actualProducts.Should().BeEquivalentTo(products.Where(x => x.Title == "Test2"),
                options => options.Excluding(x => x.Annotation)
                .Excluding(x => x.PublishingHouse)
                .Excluding(x => x.Language));
        }

        [Test]
        public void SaveNewProductTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var publishingHouse = new PublishingHouseEntity()
            {
                Title = "My Publishing House",
                ExternalId = Guid.NewGuid()
            };
            context.PublishingHouses.Add(publishingHouse);
            context.SaveChanges();

            var language = new LanguageEntity()
            {
                Title = "My Language",
                ExternalId = Guid.NewGuid()
            };
            context.Languages.Add(language);
            context.SaveChanges();

            //execute

            var product = new ProductEntity()
            {
                Title = "Test1",
                Price = 500,
                Status = 0,
                Annotation = "Test1",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2023,
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<ProductEntity>(DbContextFactory);
            repository.Save(product);

            //assert
            var actualProduct = context.Products.SingleOrDefault();
            actualProduct.Should().BeEquivalentTo(product, options => options.Excluding(x => x.Annotation)
                .Excluding(x => x.PublishingHouse)
                .Excluding(x => x.Language)
                .Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));
            actualProduct.Id.Should().NotBe(default);
            actualProduct.ModificationTime.Should().NotBe(default);
            actualProduct.CreationTime.Should().NotBe(default);
            actualProduct.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateProductTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var publishingHouse = new PublishingHouseEntity()
            {
                Title = "My Publishing House",
                ExternalId = Guid.NewGuid()
            };
            context.PublishingHouses.Add(publishingHouse);
            context.SaveChanges();

            var language = new LanguageEntity()
            {
                Title = "My Language",
                ExternalId = Guid.NewGuid()
            };
            context.Languages.Add(language);
            context.SaveChanges();

            var product = new ProductEntity()
            {
                Title = "Test1",
                Price = 500,
                Status = 0,
                Annotation = "Test1",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2023,
                ExternalId = Guid.NewGuid()
            };
            context.Products.Add(product);
            context.SaveChanges();

            //execute

            product.Title = "new title";
            product.Price = 700;
            product.YearOfPublication = 2024;
            var repository = new Repository<ProductEntity>(DbContextFactory);
            repository.Save(product);

            //assert
            var actualProduct = context.Products.SingleOrDefault();
            actualProduct.Should().BeEquivalentTo(product, options => options.Excluding(x => x.Annotation)
                .Excluding(x => x.PublishingHouse)
                .Excluding(x => x.Language));
        }


        [Test]
        public void DeleteProductTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var publishingHouse = new PublishingHouseEntity()
            {
                Title = "My Publishing House",
                ExternalId = Guid.NewGuid()
            };
            context.PublishingHouses.Add(publishingHouse);
            context.SaveChanges();

            var language = new LanguageEntity()
            {
                Title = "My Language",
                ExternalId = Guid.NewGuid()
            };
            context.Languages.Add(language);
            context.SaveChanges();

            var product = new ProductEntity()
            {
                Title = "Test1",
                Price = 500,
                Status = 0,
                Annotation = "Test1",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2023,
                ExternalId = Guid.NewGuid()
            };
            context.Products.Add(product);
            context.SaveChanges();

            //execute

            var repository = new Repository<ProductEntity>(DbContextFactory);
            repository.Delete(product);

            //assert
            context.Products.Count().Should().Be(0);
        }

        [Test]
        public void GetByIdTest_PositiveCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var publishingHouse = new PublishingHouseEntity()
            {
                Title = "My Publishing House",
                ExternalId = Guid.NewGuid()
            };
            context.PublishingHouses.Add(publishingHouse);
            context.SaveChanges();

            var language = new LanguageEntity()
            {
                Title = "My Language",
                ExternalId = Guid.NewGuid()
            };
            context.Languages.Add(language);
            context.SaveChanges();

            var products = new ProductEntity[]
            {
            new ProductEntity()
            {
                Title = "Test1",
                Price = 500,
                Status = 0,
                Annotation = "Test1",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2023,
                ExternalId = Guid.NewGuid()
            },
            new ProductEntity()
            {
                Title = "Test2",
                Price = 600,
                Status = 0,
                Annotation = "Test2",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2022,
                ExternalId = Guid.NewGuid()
            }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            //execute
            var repository = new Repository<ProductEntity>(DbContextFactory);
            var actualProduct = repository.GetById(products[0].Id);

            //assert
            actualProduct.Should().BeEquivalentTo(products[0], options => options.Excluding(x => x.Annotation)
                .Excluding(x => x.PublishingHouse)
                .Excluding(x => x.Language));
        }
        [Test]
        public void GetByIdTest_NegativeCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var publishingHouse = new PublishingHouseEntity()
            {
                Title = "My Publishing House",
                ExternalId = Guid.NewGuid()
            };
            context.PublishingHouses.Add(publishingHouse);
            context.SaveChanges();

            var language = new LanguageEntity()
            {
                Title = "My Language",
                ExternalId = Guid.NewGuid()
            };
            context.Languages.Add(language);
            context.SaveChanges();

            var products = new ProductEntity[]
            {
            new ProductEntity()
            {
                Title = "Test1",
                Price = 500,
                Status = 0,
                Annotation = "Test1",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2023,
                ExternalId = Guid.NewGuid()
            },
            new ProductEntity()
            {
                Title = "Test2",
                Price = 600,
                Status = 0,
                Annotation = "Test2",
                PublishingHouseId = publishingHouse.Id,
                LanguageId = language.Id,
                ProductType = 0,
                CoverType = 0,
                YearOfPublication = 2022,
                ExternalId = Guid.NewGuid()
            }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            //execute
            var repository = new Repository<ProductEntity>(DbContextFactory);
            var actualProduct = repository.GetById(products[products.Length - 1].Id + 1);

            //assert
            actualProduct.Should().BeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            using (var context = DbContextFactory.CreateDbContext())
            {
                context.Products.RemoveRange(context.Products);
                context.SaveChanges();
            }
        }
    }
}
