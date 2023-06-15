using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class StatusEntityConfiguration : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.Property(r => r.Id).ValueGeneratedOnAdd();

        builder.HasData
        (
            new StatusEntity
            {
                Id = new Guid("2b513574-cabc-41ce-9fbc-e67255b84431"),
                Name = "Received",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            },
            new StatusEntity
            {
                Id = new Guid("fb29bcb5-4493-4b03-b18e-11c50c650621"),
                Name = "Accepted",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            },
            new StatusEntity
            {
                Id = new Guid("01b2b3b3-0f43-49c1-a138-dd39d76bb65a"),
                Name = "Closed",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            }
        );
    }

    private DateTime GetCurrentTime()
    {
        return DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")).ToUniversalTime();
    }
}
