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
    [Migration("20240823074718_AddGiftNameAndDescription")]
    partial class AddGiftNameAndDescription
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
                            Id = new Guid("8a951375-d6fb-4711-ba7e-01e93c6df6f0"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7631),
                            Category = 0,
                            Description = "This is a sony headphones description",
                            Price = 700.5,
                            Quantity = 5L,
                            Sku = "S0K462HYLS",
                            Title = "Sony"
                        },
                        new
                        {
                            Id = new Guid("de825c15-6411-4b51-86a3-ef1f248793d2"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7638),
                            Category = 3,
                            Description = "This is a LED lamp which used for lightning",
                            Price = 50.0,
                            Quantity = 5L,
                            Sku = "KOP1ESOSE3",
                            Title = "Lamp"
                        },
                        new
                        {
                            Id = new Guid("d714cc29-1886-4e2f-ba96-a6b6e1f675b4"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7640),
                            Category = 0,
                            Description = "The latest flagship smartphone from Apple.",
                            Price = 1299.99,
                            Quantity = 5L,
                            Sku = "IPH14P0001",
                            Title = "iPhone 14 Pro"
                        },
                        new
                        {
                            Id = new Guid("a84f50ce-d90d-416d-b610-4b7af68c92e8"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7642),
                            Category = 0,
                            Description = "A powerful Android smartphone with advanced features.",
                            Price = 1199.99,
                            Quantity = 5L,
                            Sku = "SGS23U0002",
                            Title = "Samsung Galaxy S23 Ultra"
                        },
                        new
                        {
                            Id = new Guid("ba5869ac-2f68-4ce1-80e7-65afe091e3c9"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7643),
                            Category = 0,
                            Description = "A premium laptop with a sleek design and powerful performance.",
                            Price = 1499.99,
                            Quantity = 5L,
                            Sku = "DXPS130003",
                            Title = "Dell XPS 13"
                        },
                        new
                        {
                            Id = new Guid("d05c041e-18ab-4b3c-ae25-de7b597e3343"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7644),
                            Category = 0,
                            Description = "A high-performance laptop powered by the M2 chip.",
                            Price = 1699.99,
                            Quantity = 5L,
                            Sku = "MBP0004",
                            Title = "MacBook Pro M2"
                        },
                        new
                        {
                            Id = new Guid("9b576432-964d-4040-81eb-a7877050288b"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7645),
                            Category = 0,
                            Description = "The latest gaming console from Sony.",
                            Price = 499.99000000000001,
                            Quantity = 5L,
                            Sku = "PS50005",
                            Title = "PlayStation 5"
                        },
                        new
                        {
                            Id = new Guid("86dc53c1-7780-417e-b76f-d03f44dc9817"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7646),
                            Category = 0,
                            Description = "A powerful gaming console from Microsoft.",
                            Price = 499.99000000000001,
                            Quantity = 5L,
                            Sku = "XSX0006",
                            Title = "Xbox Series X"
                        },
                        new
                        {
                            Id = new Guid("b51653ed-a9f8-4520-b55b-10a11bdeb089"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7651),
                            Category = 0,
                            Description = "A hybrid console with a high-resolution OLED screen.",
                            Price = 349.99000000000001,
                            Quantity = 5L,
                            Sku = "NSO0007",
                            Title = "Nintendo Switch OLED"
                        },
                        new
                        {
                            Id = new Guid("adf3dd50-26f0-489e-9e00-5958c132a9ba"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7652),
                            Category = 0,
                            Description = "A high-quality OLED TV with stunning picture quality.",
                            Price = 1999.99,
                            Quantity = 5L,
                            Sku = "LGTVC20008",
                            Title = "LG OLED TV C2 Series"
                        },
                        new
                        {
                            Id = new Guid("d45c76b3-8519-486b-997c-e4e5c844b3b4"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7653),
                            Category = 0,
                            Description = "A high-quality QLED TV with excellent picture quality.",
                            Price = 1799.99,
                            Quantity = 5L,
                            Sku = "SAMQ90B0009",
                            Title = "Samsung QLED TV QN90B"
                        },
                        new
                        {
                            Id = new Guid("04b141e5-b3b1-4305-a72e-acb9b5619e7d"),
                            AddedOnUtc = new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7655),
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
