using BookShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccess
{
    public class BookShopDbContext : DbContext
    {
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<CharacteristicEntity> Characteristics { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PointOfDeliveryEntity> PointsOfDelivery { get; set; }
        public DbSet<ProductAuthorEntity> ProductsAuthors { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PublishingHouseEntity> PublishingHouses { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<ShoppingBasketEntity> ShoppingBaskets { get; set; }

        public BookShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AdminEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<AuthorEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AuthorEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<CharacteristicEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CharacteristicEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<CharacteristicEntity>().HasOne(x => x.Genre)
                .WithMany(x => x.Characteristics)
                .HasForeignKey(x => x.GenreId);
            modelBuilder.Entity<CharacteristicEntity>().HasOne(x => x.Product)
                .WithMany(x => x.Characteristics)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<CustomerEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CustomerEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<GenreEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<GenreEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<LanguageEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<LanguageEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<OrderEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<OrderEntity>().HasOne(x => x.ShoppingBasket)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ShoppingBasketId);
            modelBuilder.Entity<OrderEntity>().HasOne(x => x.PointOfDelivery)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.PointOfDeliveryId);

            modelBuilder.Entity<PointOfDeliveryEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PointOfDeliveryEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<ProductAuthorEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ProductAuthorEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ProductAuthorEntity>().HasOne(x => x.Product)
                .WithMany(x => x.ProductsAuthors)
                .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<ProductAuthorEntity>().HasOne(x => x.Author)
                .WithMany(x => x.ProductsAuthors)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<ProductEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ProductEntity>().HasOne(x => x.PublishingHouse)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.PublishingHouseId);
            modelBuilder.Entity<ProductEntity>().HasOne(x => x.Language)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.LanguageId);

            modelBuilder.Entity<PublishingHouseEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PublishingHouseEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<ReviewEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ReviewEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ReviewEntity>().HasOne(x => x.Customer)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.CustomerId);
            modelBuilder.Entity<ReviewEntity>().HasOne(x => x.Product)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ShoppingBasketEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ShoppingBasketEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ShoppingBasketEntity>().HasOne(x => x.Customer)
                .WithMany(x => x.ShoppingBaskets)
                .HasForeignKey(x => x.CustomerId);
            modelBuilder.Entity<ShoppingBasketEntity>().HasOne(x => x.Product)
                .WithMany(x => x.ShoppingBaskets)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
