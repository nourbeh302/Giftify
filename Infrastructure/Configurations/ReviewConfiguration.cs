using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .Property(r => r.Comment)
            .IsRequired(false)
            .HasMaxLength(1024);

        builder
            .HasOne(r => r.AddedBy)
            .WithMany();
    }
}
