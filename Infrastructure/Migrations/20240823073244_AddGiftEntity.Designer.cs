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
    [Migration("20240823073244_AddGiftEntity")]
    partial class AddGiftEntity
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

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("Domain.Gifts.Product", b =>
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
                            Id = new Guid("3a3cfb26-4de7-4642-a439-565d76dedc0d"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6847),
                            Category = 0,
                            Description = "This is a sony headphones description",
                            Price = 700.5,
                            Quantity = 5L,
                            Sku = "S0K462HYLS",
                            Title = "Sony"
                        },
                        new
                        {
                            Id = new Guid("e6b07ca8-33ef-4285-b92c-4ba8f03b53bb"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6870),
                            Category = 3,
                            Description = "This is a LED lamp which used for lightning",
                            Price = 50.0,
                            Quantity = 5L,
                            Sku = "KOP1ESOSE3",
                            Title = "Lamp"
                        },
                        new
                        {
                            Id = new Guid("b5a79cf0-1abc-4558-bd41-391a9ba49aa0"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6872),
                            Category = 0,
                            Description = "The latest flagship smartphone from Apple.",
                            Price = 1299.99,
                            Quantity = 5L,
                            Sku = "IPH14P0001",
                            Title = "iPhone 14 Pro"
                        },
                        new
                        {
                            Id = new Guid("657c70f3-21b9-4165-b717-92d4b503ed84"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6874),
                            Category = 0,
                            Description = "A powerful Android smartphone with advanced features.",
                            Price = 1199.99,
                            Quantity = 5L,
                            Sku = "SGS23U0002",
                            Title = "Samsung Galaxy S23 Ultra"
                        },
                        new
                        {
                            Id = new Guid("96399555-f641-410c-b23c-f7218b910ea2"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6875),
                            Category = 0,
                            Description = "A premium laptop with a sleek design and powerful performance.",
                            Price = 1499.99,
                            Quantity = 5L,
                            Sku = "DXPS130003",
                            Title = "Dell XPS 13"
                        },
                        new
                        {
                            Id = new Guid("4527d8f7-d933-4b94-93c9-d052386b732f"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6876),
                            Category = 0,
                            Description = "A high-performance laptop powered by the M2 chip.",
                            Price = 1699.99,
                            Quantity = 5L,
                            Sku = "MBP0004",
                            Title = "MacBook Pro M2"
                        },
                        new
                        {
                            Id = new Guid("e3747d97-e312-449b-ab39-f70abf53fb79"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6878),
                            Category = 0,
                            Description = "The latest gaming console from Sony.",
                            Price = 499.99000000000001,
                            Quantity = 5L,
                            Sku = "PS50005",
                            Title = "PlayStation 5"
                        },
                        new
                        {
                            Id = new Guid("8fa1e893-58c3-4658-afb5-f184d1209fa8"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6879),
                            Category = 0,
                            Description = "A powerful gaming console from Microsoft.",
                            Price = 499.99000000000001,
                            Quantity = 5L,
                            Sku = "XSX0006",
                            Title = "Xbox Series X"
                        },
                        new
                        {
                            Id = new Guid("4ac75600-cf55-482c-9d2d-15e640bd3d60"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6880),
                            Category = 0,
                            Description = "A hybrid console with a high-resolution OLED screen.",
                            Price = 349.99000000000001,
                            Quantity = 5L,
                            Sku = "NSO0007",
                            Title = "Nintendo Switch OLED"
                        },
                        new
                        {
                            Id = new Guid("2e9c0385-c3b8-4ea7-a811-0dddca2b43d5"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6883),
                            Category = 0,
                            Description = "A high-quality OLED TV with stunning picture quality.",
                            Price = 1999.99,
                            Quantity = 5L,
                            Sku = "LGTVC20008",
                            Title = "LG OLED TV C2 Series"
                        },
                        new
                        {
                            Id = new Guid("55c7de33-9d0b-4763-b9f5-7132e82c0342"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6885),
                            Category = 0,
                            Description = "A high-quality QLED TV with excellent picture quality.",
                            Price = 1799.99,
                            Quantity = 5L,
                            Sku = "SAMQ90B0009",
                            Title = "Samsung QLED TV QN90B"
                        },
                        new
                        {
                            Id = new Guid("a1750acf-5fad-43b1-af89-c57a168ef37f"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6886),
                            Category = 3,
                            Description = "A reliable dishwasher with efficient cleaning performance.",
                            Price = 799.99000000000001,
                            Quantity = 5L,
                            Sku = "BOSH0010",
                            Title = "Bosch Dishwasher"
                        });
                });

            modelBuilder.Entity("Domain.Gifts.Review", b =>
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

            modelBuilder.Entity("Domain.Gifts.Gift", b =>
                {
                    b.HasOne("Domain.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Domain.Gifts.Review", b =>
                {
                    b.HasOne("Domain.Users.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Gifts.Product", "Product")
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

                    b.HasOne("Domain.Gifts.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
