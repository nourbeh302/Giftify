using Domain.Gifts;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class GiftConfiguration : IEntityTypeConfiguration<Gift>
{
    public void Configure(EntityTypeBuilder<Gift> builder)
    {
        builder.HasKey(g => g.Id);

        builder
            .Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder
            .Property(g => g.Description)
            .IsRequired()
            .HasMaxLength(1024);

        // One-to-Many relationship with User
        builder.HasOne(g => g.CreatedBy)
             .WithMany()
             .IsRequired()
             .OnDelete(DeleteBehavior.Cascade);

        // Many-to-Many relationship with Product
        builder
            .HasMany(g => g.Products)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "GiftProducts",
                j => j.HasOne<Product>()
                      .WithMany()
                      .HasForeignKey("ProductId")
                      .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Gift>()
                      .WithMany()
                      .HasForeignKey("GiftId")
                      .OnDelete(DeleteBehavior.Cascade));
    }
}
