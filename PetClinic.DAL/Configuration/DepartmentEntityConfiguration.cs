using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class DepartmentEntityConfiguration : IEntityTypeConfiguration<DepartmentEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
    {
        builder.HasData
        (
            new DepartmentEntity
            {
                Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                Address = "пр. Независимости, 177",
                Name = "Вет-клиника филиал 1",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            },
            new DepartmentEntity
            {
                Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                Address = "ул. Академическая, 26",
                Name = "Вет-клиника филиал 2",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            },
            new DepartmentEntity
            {
                Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                Address = "ул. Карастояновой, 2",
                Name = "Вет-клиника филиал 3",
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
