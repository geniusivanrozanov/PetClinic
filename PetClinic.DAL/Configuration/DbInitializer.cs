using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class DbInitializer
{
    public static async Task SeedDataAsync(AppDbContext dbContext)
    {
        await dbContext.Database.EnsureCreatedAsync();
        
        if (dbContext.PetTypes.Count() == 0)
        {
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
                }
            );
        }

        if (dbContext.PetTypes.Count() == 0)
        {
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
        }

        if (dbContext.Roles.Count() == 0)
        {
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
                },
                new RoleEntity
                {
                    Id = new Guid("4a2eb2b2-b4a9-4a34-9dff-b688f9643cad"),
                    Name = "Vet",
                    NormalizedName = "VET",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                }
            );
        }

        if (dbContext.Services.Count() == 0)
        {
            await dbContext.Services.AddRangeAsync
            (
                new ServiceEntity
                {
                    Id = new Guid("afc747bf-2c6f-4c6a-88e9-1385cef793d6"),
                    Name = "Intestinal Parasite Screening",
                    Price = 25,
                    Duration = "40",
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                }
            );
        }

        await dbContext.SaveChangesAsync();
    }
}
