using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.Property(r => r.Id).ValueGeneratedOnAdd();

        builder.HasData
        (
            new RoleEntity
            {
                Id = new Guid("396f1365-f763-4f2a-a873-fdbef1c12ba3"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            },
            new RoleEntity
            {
                Id = new Guid("85300f9e-e1e5-423f-a759-059e4a6a7f3a"),
                Name = "Client",
                NormalizedName = "CLIENT",
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
