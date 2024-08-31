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
    [Migration("20240822112905_InsertProducts")]
    partial class InsertProducts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Id = new Guid("923036f0-c8e6-401f-b26b-39f10184fa70"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(573),
                            Category = 0,
                            Description = "This is a sony headphones description",
                            Price = 700.5,
                            Quantity = 5L,
                            Sku = "S0K462HYLS",
                            Title = "Sony"
                        },
                        new
                        {
                            Id = new Guid("68aba4d7-3579-49f1-b113-2af56100b777"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(581),
                            Category = 3,
                            Description = "This is a LED lamp which used for lightning",
                            Price = 50.0,
                            Quantity = 5L,
                            Sku = "KOP1ESOSE3",
                            Title = "Lamp"
                        },
                        new
                        {
                            Id = new Guid("04c9a5af-b1e3-4535-ac67-0f340ae9057c"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(595),
                            Category = 0,
                            Description = "The latest flagship smartphone from Apple.",
                            Price = 1299.99,
                            Quantity = 5L,
                            Sku = "IPH14P0001",
                            Title = "iPhone 14 Pro"
                        },
                        new
                        {
                            Id = new Guid("75699388-9ef6-44db-9564-c0c64b8470f5"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(597),
                            Category = 0,
                            Description = "A powerful Android smartphone with advanced features.",
                            Price = 1199.99,
                            Quantity = 5L,
                            Sku = "SGS23U0002",
                            Title = "Samsung Galaxy S23 Ultra"
                        },
                        new
                        {
                            Id = new Guid("11f69943-9bf2-4117-bfa1-8047ecb5fa85"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(598),
                            Category = 0,
                            Description = "A premium laptop with a sleek design and powerful performance.",
                            Price = 1499.99,
                            Quantity = 5L,
                            Sku = "DXPS130003",
                            Title = "Dell XPS 13"
                        },
                        new
                        {
                            Id = new Guid("a81bff87-3947-41ef-910c-9ca604044999"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(599),
                            Category = 0,
                            Description = "A high-performance laptop powered by the M2 chip.",
                            Price = 1699.99,
                            Quantity = 5L,
                            Sku = "MBP0004",
                            Title = "MacBook Pro M2"
                        },
                        new
                        {
                            Id = new Guid("03147455-309e-4d2f-85b4-ba308e5e9904"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(600),
                            Category = 0,
                            Description = "The latest gaming console from Sony.",
                            Price = 499.99000000000001,
                            Quantity = 5L,
                            Sku = "PS50005",
                            Title = "PlayStation 5"
                        },
                        new
                        {
                            Id = new Guid("5109656e-ec93-49d0-b4b4-c685f56f54a7"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(602),
                            Category = 0,
                            Description = "A powerful gaming console from Microsoft.",
                            Price = 499.99000000000001,
                            Quantity = 5L,
                            Sku = "XSX0006",
                            Title = "Xbox Series X"
                        },
                        new
                        {
                            Id = new Guid("a1164f6e-12d9-4151-b68a-cd381e1f57e3"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(603),
                            Category = 0,
                            Description = "A hybrid console with a high-resolution OLED screen.",
                            Price = 349.99000000000001,
                            Quantity = 5L,
                            Sku = "NSO0007",
                            Title = "Nintendo Switch OLED"
                        },
                        new
                        {
                            Id = new Guid("11391204-3034-44ba-a39b-44b94e885483"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(604),
                            Category = 0,
                            Description = "A high-quality OLED TV with stunning picture quality.",
                            Price = 1999.99,
                            Quantity = 5L,
                            Sku = "LGTVC20008",
                            Title = "LG OLED TV C2 Series"
                        },
                        new
                        {
                            Id = new Guid("4a30048f-74cc-4fd2-a6cb-c3f8a2f8b9fa"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(607),
                            Category = 0,
                            Description = "A high-quality QLED TV with excellent picture quality.",
                            Price = 1799.99,
                            Quantity = 5L,
                            Sku = "SAMQ90B0009",
                            Title = "Samsung QLED TV QN90B"
                        },
                        new
                        {
                            Id = new Guid("921db079-08a6-427b-8250-a009d71f10d3"),
                            AddedOnUtc = new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(609),
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
#pragma warning restore 612, 618
        }
    }
}