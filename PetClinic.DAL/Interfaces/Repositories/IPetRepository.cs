using PetClinic.DAL.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public  interface IPetRepository
{
    Task<PetEntity?> GetPetAsync(Guid id);
    Task<IEnumerable<PetEntity>> GetAllPetAsync();
    Task<IEnumerable<PetEntity>> FindPetAsync(Expression<Func<PetEntity, bool>> predicate);
    Task<PetEntity> AddPetAsync(PetEntity entity);
    Task AddRangePetAsync(IEnumerable<PetEntity> entities);
    void RemovePet(PetEntity entity);
    void RemoveRangePet(IEnumerable<PetEntity> entities);
    PetEntity UpdatePet(PetEntity entity);
}
