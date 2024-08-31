using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    private const int InitialQuantity = 5;

        private readonly List<Product> _products = [
            new Product(
                id: Guid.NewGuid(),
                title: "Sony",
                description: "This is a sony headphones description",
                price: 700.5,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "S0K462HYLS"),
            new Product(
                id: Guid.NewGuid(),
                title: "Lamp",
                description: "This is a LED lamp which used for lightning",
                price: 50,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Appliances,
                sku: "KOP1ESOSE3"),
            new Product(
                id: Guid.NewGuid(),
                title: "iPhone 14 Pro",
                description: "The latest flagship smartphone from Apple.",
                price: 1299.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "IPH14P0001"),
            new Product(
                id: Guid.NewGuid(),
                title: "Samsung Galaxy S23 Ultra",
                description: "A powerful Android smartphone with advanced features.",
                price: 1199.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "SGS23U0002"),
            new Product(
                id: Guid.NewGuid(),
                title: "Dell XPS 13",
                description: "A premium laptop with a sleek design and powerful performance.",
                price: 1499.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "DXPS130003"),
            new Product(
                id: Guid.NewGuid(),
                title: "MacBook Pro M2",
                description: "A high-performance laptop powered by the M2 chip.",
                price: 1699.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "MBP0004"),
            new Product(
                id: Guid.NewGuid(),
                title: "PlayStation 5",
                description: "The latest gaming console from Sony.",
                price: 499.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "PS50005"),
            new Product(
                id: Guid.NewGuid(),
                title: "Xbox Series X",
                description: "A powerful gaming console from Microsoft.",
                price: 499.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "XSX0006"),
            new Product(
                id: Guid.NewGuid(),
                title: "Nintendo Switch OLED",
                description: "A hybrid console with a high-resolution OLED screen.",
                price: 349.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "NSO0007"),
            new Product(
                id: Guid.NewGuid(),
                title: "LG OLED TV C2 Series",
                description: "A high-quality OLED TV with stunning picture quality.",
                price: 1999.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "LGTVC20008"),
            new Product(
                id: Guid.NewGuid(),
                title: "Samsung QLED TV QN90B",
                description: "A high-quality QLED TV with excellent picture quality.",
                price: 1799.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Electronics,
                sku: "SAMQ90B0009"),
            new Product(
                id: Guid.NewGuid(),
                title: "Bosch Dishwasher",
                description: "A reliable dishwasher with efficient cleaning performance.",
                price: 799.99,
                addedOnUtc: DateTime.UtcNow,
                quantity: InitialQuantity,
                category: Category.Appliances,
                sku: "BOSH0010")
        ];

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(64);

        builder
            .Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(1024);

        builder
            .Property(p => p.Quantity)
            .IsRequired();

        builder
            .Property(p => p.Price)
            .IsRequired();

        builder.ToTable(t =>
            t.HasCheckConstraint("CK_Products_Price_GreaterThanZero", "Price > 0"));

        builder.HasData(_products);
    }
}
