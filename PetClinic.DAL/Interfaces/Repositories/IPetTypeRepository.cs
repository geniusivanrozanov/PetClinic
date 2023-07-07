using PetClinic.DAL.Entities;
using System.Linq.Expressions;


namespace PetClinic.DAL.Interfaces.Repositories;

public interface IPetTypeRepository
{
    Task<PetTypeEntity?> GetPetTypeAsync(Guid id);
    Task<IEnumerable<PetTypeEntity>> GetAllPetTypesAsync();
    Task<IEnumerable<PetTypeEntity>> FindPetTypeAsync(Expression<Func<PetTypeEntity, bool>> predicate);
    Task<PetTypeEntity> AddPetTypeAsync(PetTypeEntity entity);
    Task AddRangePetTypeAsync(IEnumerable<PetTypeEntity> entities);
    void RemovePetType(PetTypeEntity entity);
    void RemoveRangePetType(IEnumerable<PetTypeEntity> entities);
    PetTypeEntity UpdatePetType(PetTypeEntity entity);
}
