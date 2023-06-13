using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.Email).HasMaxLength(30);
        builder.Property(u => u.FirstName).HasMaxLength(30);
        builder.Property(u => u.LastName).HasMaxLength(30);
        builder.Property(u => u.PhoneNumber).HasMaxLength(15);
    }
}
