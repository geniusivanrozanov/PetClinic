using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class ServiceEntityConfiguration : IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).HasMaxLength(100);

        builder.HasData(new ServiceEntity
        {
            Id = new Guid("afc747bf-2c6f-4c6a-88e9-1385cef793d6"),
            Name = "Intestinal Parasite Screening",
            Price = 25,
            Duration = "40",
            IsDeleted = false,
            CreatedAt = GetCurrentTime(),
            UpdatedAt = GetCurrentTime(),
        });
    }

    private DateTime GetCurrentTime()
    {
        return DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")).ToUniversalTime();
    }
}
