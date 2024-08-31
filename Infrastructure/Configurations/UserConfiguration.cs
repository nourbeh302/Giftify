using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(64);
        
        builder
            .Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(64);

        builder
            .HasIndex(u => u.Email)
            .IsUnique();

        builder
            .Property(u => u.Address)
            .HasMaxLength(256);
    }
}
