using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class ReviewEntityConfiguration : IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Diagnosis).HasMaxLength(300);
        builder.Property(p => p.VetComments).HasMaxLength(300);
    }
}
