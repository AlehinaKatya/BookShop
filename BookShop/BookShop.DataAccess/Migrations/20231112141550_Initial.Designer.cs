﻿// <auto-generated />
using System;
using BookShop.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookShop.DataAccess.Migrations
{
    [DbContext(typeof(BookShopDbContext))]
    [Migration("20231112141550_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookShop.DataAccess.Entities.AdminEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("admins");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.AuthorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("authors");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.CharacteristicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("GenreId");

                    b.HasIndex("ProductId");

                    b.ToTable("characteristics");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBith")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalisedDiscount")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("customers");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.GenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("genres");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.LanguageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("languages");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PointOfDeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingBasketId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("PointOfDeliveryId");

                    b.HasIndex("ShoppingBasketId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.PointOfDeliveryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("points_of_delivery");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ProductAuthorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("product_author");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Annotation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CoverType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<int>("PublishingHouseId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfPublication")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("LanguageId");

                    b.HasIndex("PublishingHouseId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.PublishingHouseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("publishing_houses");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ShoppingBasketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("shopping_baskets");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.CharacteristicEntity", b =>
                {
                    b.HasOne("BookShop.DataAccess.Entities.GenreEntity", "Genre")
                        .WithMany("Characteristics")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccess.Entities.ProductEntity", "Product")
                        .WithMany("Characteristics")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.OrderEntity", b =>
                {
                    b.HasOne("BookShop.DataAccess.Entities.PointOfDeliveryEntity", "PointOfDelivery")
                        .WithMany("Orders")
                        .HasForeignKey("PointOfDeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccess.Entities.ShoppingBasketEntity", "ShoppingBasket")
                        .WithMany("Orders")
                        .HasForeignKey("ShoppingBasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PointOfDelivery");

                    b.Navigation("ShoppingBasket");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ProductAuthorEntity", b =>
                {
                    b.HasOne("BookShop.DataAccess.Entities.AuthorEntity", "Author")
                        .WithMany("ProductsAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccess.Entities.ProductEntity", "Product")
                        .WithMany("ProductsAuthors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ProductEntity", b =>
                {
                    b.HasOne("BookShop.DataAccess.Entities.LanguageEntity", "Language")
                        .WithMany("Products")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccess.Entities.PublishingHouseEntity", "PublishingHouse")
                        .WithMany("Products")
                        .HasForeignKey("PublishingHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("PublishingHouse");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ReviewEntity", b =>
                {
                    b.HasOne("BookShop.DataAccess.Entities.CustomerEntity", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccess.Entities.ProductEntity", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ShoppingBasketEntity", b =>
                {
                    b.HasOne("BookShop.DataAccess.Entities.CustomerEntity", "Customer")
                        .WithMany("ShoppingBaskets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccess.Entities.ProductEntity", "Product")
                        .WithMany("ShoppingBaskets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.AuthorEntity", b =>
                {
                    b.Navigation("ProductsAuthors");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("ShoppingBaskets");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.GenreEntity", b =>
                {
                    b.Navigation("Characteristics");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.LanguageEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.PointOfDeliveryEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ProductEntity", b =>
                {
                    b.Navigation("Characteristics");

                    b.Navigation("ProductsAuthors");

                    b.Navigation("Reviews");

                    b.Navigation("ShoppingBaskets");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.PublishingHouseEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BookShop.DataAccess.Entities.ShoppingBasketEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
