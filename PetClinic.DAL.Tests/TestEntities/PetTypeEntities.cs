using System.Linq.Expressions;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Tests.TestEntities;

public class PetTypeEntities : EntitiesGenerator<PetTypeEntity>
{
    public override IEnumerable<PetTypeEntity> GetValidEntitiesList() => new[]
    {
        new PetTypeEntity()
        {
            Name = "Cat"
        },
        new PetTypeEntity()
        {
            Name = "Dog"
        },
        new PetTypeEntity()
        {
            Name = "Hamster"
        }
    };

    public override IEnumerable<PetTypeEntity> GetEntitiesForSearch() => new[]
    {
        new PetTypeEntity()
        {
            Name = "Cat"
        },
        new PetTypeEntity()
        {
            Name = "Crab"
        },
        new PetTypeEntity()
        {
            Name = "Camel"
        },
        new PetTypeEntity()
        {
            Name = "Dog"
        },
        new PetTypeEntity()
        {
            Name = "Hamster"
        }
    };

    public override Expression<Func<PetTypeEntity, bool>> GetFilterForSearch()
    {
        return (entity) => entity.Name.StartsWith("C");
    }

    public override void UpdateEntity(PetTypeEntity entity)
    {
        entity.Name = "Updated name";
    }

    public override PetTypeEntity CloneEntity(PetTypeEntity entity) => new PetTypeEntity()
    {
        Id = entity.Id,
        Name = entity.Name,
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
        IsDeleted = entity.IsDeleted
    };

    public override PetTypeEntity GetValidEntity() => new PetTypeEntity()
    {
        Name = "Cat"
    };
}