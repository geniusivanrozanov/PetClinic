using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class PetTypeEntityConfiguration : IEntityTypeConfiguration<PetTypeEntity>
{
    public void Configure(EntityTypeBuilder<PetTypeEntity> builder)
    {
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).HasMaxLength(20);

        builder.HasData
        (
            new PetTypeEntity
            {
                Id = new Guid("0605974a-977c-4739-aa55-7e26e4eb2422"),
                Name = "Cat",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            },
            new PetTypeEntity
            {
                Id = new Guid("c9a68d44-b5b8-4b96-9558-b4e52e750987"),
                Name = "Dog",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            },
            new PetTypeEntity
            {
                Id = new Guid("13109317-ea78-4274-ad6e-e9a159f7f2f1"),
                Name = "Rabbit",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            },
            new PetTypeEntity
            {
                Id = new Guid("a160449b-fb70-4991-9ddb-918b707829a8"),
                Name = "Parrot",
                CreatedAt = GetCurrentTime(),
                UpdatedAt = GetCurrentTime(),
                IsDeleted = false,
            },
            new PetTypeEntity
            {
                Id = new Guid("f4dc2dab-9477-4ebe-8fb2-40306e739dee"),
                Name = "Hamster",
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

