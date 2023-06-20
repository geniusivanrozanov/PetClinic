using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces;

namespace PetClinic.DAL.Configuration;

public class DbInitializer
{
    public static async Task SeedDataAsync(AppDbContext dbContext)
    {
        await dbContext.Database.EnsureCreatedAsync();

        await dbContext.Departments.AddRangeAsync
        (
            new DepartmentEntity
            {
                Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                Address = "пр. Независимости, 177",
                Name = "Вет-клиника филиал 1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new DepartmentEntity
            {
                Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                Address = "ул. Академическая, 26",
                Name = "Вет-клиника филиал 2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new DepartmentEntity
            {
                Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                Address = "ул. Карастояновой, 2",
                Name = "Вет-клиника филиал 3",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            });

        await dbContext.PetTypes.AddRangeAsync
        (
            new PetTypeEntity
            {
                Id = new Guid("0605974a-977c-4739-aa55-7e26e4eb2422"),
                Name = "Cat",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new PetTypeEntity
            {
                Id = new Guid("c9a68d44-b5b8-4b96-9558-b4e52e750987"),
                Name = "Dog",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new PetTypeEntity
            {
                Id = new Guid("13109317-ea78-4274-ad6e-e9a159f7f2f1"),
                Name = "Rabbit",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new PetTypeEntity
            {
                Id = new Guid("a160449b-fb70-4991-9ddb-918b707829a8"),
                Name = "Parrot",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new PetTypeEntity
            {
                Id = new Guid("f4dc2dab-9477-4ebe-8fb2-40306e739dee"),
                Name = "Hamster",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            }
        );

        await dbContext.Roles.AddRangeAsync
        (
            new RoleEntity
            {
                Id = new Guid("396f1365-f763-4f2a-a873-fdbef1c12ba3"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new RoleEntity
            {
                Id = new Guid("85300f9e-e1e5-423f-a759-059e4a6a7f3a"),
                Name = "Client",
                NormalizedName = "CLIENT",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            }
        );

        await dbContext.Statuses.AddRangeAsync
        (
            new StatusEntity
            {
                Id = new Guid("2b513574-cabc-41ce-9fbc-e67255b84431"),
                Name = "Received",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new StatusEntity
            {
                Id = new Guid("fb29bcb5-4493-4b03-b18e-11c50c650621"),
                Name = "Accepted",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new StatusEntity
            {
                Id = new Guid("01b2b3b3-0f43-49c1-a138-dd39d76bb65a"),
                Name = "Closed",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            }
        );

        await dbContext.SaveChangesAsync();
    }
}
