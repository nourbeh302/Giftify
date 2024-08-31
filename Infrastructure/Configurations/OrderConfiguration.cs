using Domain.Gifts;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasOne(o => o.ShippingAddress)
            .WithOne()
            .HasForeignKey<Order>(o => o.ShippingAddressId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(o => o.BillingAddress)
            .WithOne()
            .HasForeignKey<Order>(o => o.BillingAddressId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(o => o.Gifts)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "OrderGifts",
                j => j.HasOne<Gift>()
                      .WithMany()
                      .HasForeignKey("GiftId")
                      .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Order>()
                      .WithMany()
                      .HasForeignKey("OrderId")
                      .OnDelete(DeleteBehavior.NoAction));
        // Note: orders should never be deleted
    }
}
