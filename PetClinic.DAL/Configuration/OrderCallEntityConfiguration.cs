using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class OrderCallEntityConfiguration : IEntityTypeConfiguration<OrderCallEntity>
{
    public void Configure(EntityTypeBuilder<OrderCallEntity> builder)
    {
        builder.HasKey(oc => oc.Id);
        
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(oc => oc.PhoneNumber).HasMaxLength(15);
    }
}

