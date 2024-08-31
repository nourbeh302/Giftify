﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240831081751_AddAddressEntity")]
    partial class AddAddressEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Gifts.Gift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("Domain.Orders.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Floor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Governate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BillingAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("ShippingAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BillingAddressId")
                        .IsUnique();

                    b.HasIndex("ShippingAddressId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Products", t =>
                        {
                            t.HasCheckConstraint("CK_Products_Price_GreaterThanZero", "Price > 0");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("39c95e72-cf33-44be-a93e-b9b6097c4324"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3229),
                            Category = 0,
                            Description = "This is a sony headphones description",
                            Price = 700.5,
                            Quantity = 5L,
                            Sku = "S0K462HYLS",
                            Title = "Sony"
                        },
                        new
                        {
                            Id = new Guid("69f7c992-b590-459d-8827-54dbe1493a87"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3240),
                            Category = 3,
                            Description = "This is a LED lamp which used for lightning",
                            Price = 50.0,
                            Quantity = 5L,
                            Sku = "KOP1ESOSE3",
                            Title = "Lamp"
                        },
                        new
                        {
                            Id = new Guid("2e1c51ca-3243-464d-9f16-f6b985e28a7d"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3241),
                            Category = 0,
                            Description = "The latest flagship smartphone from Apple.",
                            Price = 1299.99,
                            Quantity = 5L,
                            Sku = "IPH14P0001",
                            Title = "iPhone 14 Pro"
                        },
                        new
                        {
                            Id = new Guid("8e8d0322-5ce9-4178-91a1-e2c3aa6fd977"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3243),
                            Category = 0,
                            Description = "A powerful Android smartphone with advanced features.",
                            Price = 1199.99,
                            Quantity = 5L,
                            Sku = "SGS23U0002",
                            Title = "Samsung Galaxy S23 Ultra"
                        },
                        new
                        {
                            Id = new Guid("d2a2510f-8b37-4d31-a3ed-a7b645a29751"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3244),
                            Category = 0,
                            Description = "A premium laptop with a sleek design and powerful performance.",
                            Price = 1499.99,
                            Quantity = 5L,
                            Sku = "DXPS130003",
                            Title = "Dell XPS 13"
                        },
                        new
                        {
                            Id = new Guid("9eb262cd-df1d-4377-9727-7e33e42ba6c9"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3245),
                            Category = 0,
                            Description = "A high-performance laptop powered by the M2 chip.",
                            Price = 1699.99,
                            Quantity = 5L,
                            Sku = "MBP0004",
                            Title = "MacBook Pro M2"
                        },
                        new
                        {
                            Id = new Guid("7caf6b66-4108-4d38-9492-0a71ed80d7c1"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3246),
                            Category = 0,
                            Description = "The latest gaming console from Sony.",
                            Price = 499.99000000000001,
                            Quantity = 5L,
                            Sku = "PS50005",
                            Title = "PlayStation 5"
                        },
                        new
                        {
                            Id = new Guid("fe08feeb-c55a-4cd8-9130-e4ea1ee90a91"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3248),
                            Category = 0,
                            Description = "A powerful gaming console from Microsoft.",
                            Price = 499.99000000000001,
                            Quantity = 5L,
                            Sku = "XSX0006",
                            Title = "Xbox Series X"
                        },
                        new
                        {
                            Id = new Guid("beafb549-6a09-4fbd-8f27-9dbc44ec906c"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3251),
                            Category = 0,
                            Description = "A hybrid console with a high-resolution OLED screen.",
                            Price = 349.99000000000001,
                            Quantity = 5L,
                            Sku = "NSO0007",
                            Title = "Nintendo Switch OLED"
                        },
                        new
                        {
                            Id = new Guid("1be601ee-9054-4b5e-a233-bb0654f6f54f"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3252),
                            Category = 0,
                            Description = "A high-quality OLED TV with stunning picture quality.",
                            Price = 1999.99,
                            Quantity = 5L,
                            Sku = "LGTVC20008",
                            Title = "LG OLED TV C2 Series"
                        },
                        new
                        {
                            Id = new Guid("6d138d7c-d6c4-41e8-8ecb-3e66ebe7b52a"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3253),
                            Category = 0,
                            Description = "A high-quality QLED TV with excellent picture quality.",
                            Price = 1799.99,
                            Quantity = 5L,
                            Sku = "SAMQ90B0009",
                            Title = "Samsung QLED TV QN90B"
                        },
                        new
                        {
                            Id = new Guid("60671684-b470-4ec7-8496-b7290c3469cc"),
                            AddedOnUtc = new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3254),
                            Category = 3,
                            Description = "A reliable dishwasher with efficient cleaning performance.",
                            Price = 799.99000000000001,
                            Quantity = 5L,
                            Sku = "BOSH0010",
                            Title = "Bosch Dishwasher"
                        });
                });

            modelBuilder.Entity("Domain.Products.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GiftProducts", b =>
                {
                    b.Property<Guid>("GiftId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GiftId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("GiftProducts");
                });

            modelBuilder.Entity("OrderGifts", b =>
                {
                    b.Property<Guid>("GiftId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GiftId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderGifts");
                });

            modelBuilder.Entity("Domain.Gifts.Gift", b =>
                {
                    b.HasOne("Domain.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Domain.Orders.Order", b =>
                {
                    b.HasOne("Domain.Orders.Address", "BillingAddress")
                        .WithOne()
                        .HasForeignKey("Domain.Orders.Order", "BillingAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Orders.Address", "ShippingAddress")
                        .WithOne()
                        .HasForeignKey("Domain.Orders.Order", "ShippingAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BillingAddress");

                    b.Navigation("ShippingAddress");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Products.Review", b =>
                {
                    b.HasOne("Domain.Users.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedBy");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GiftProducts", b =>
                {
                    b.HasOne("Domain.Gifts.Gift", null)
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderGifts", b =>
                {
                    b.HasOne("Domain.Gifts.Gift", null)
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Orders.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
