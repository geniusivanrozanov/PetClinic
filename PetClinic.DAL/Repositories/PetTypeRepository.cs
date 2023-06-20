using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class PetTypeRepository : BaseRepository<PetTypeEntity, Guid>, IPetTypeRepository
{
    public PetTypeRepository(AppDbContext context) : base(context) { }

    public async Task<PetTypeEntity> AddPetTypeAsync(PetTypeEntity entity) => await AddAsync(entity);

    public async Task AddRangePetTypeAsync(IEnumerable<PetTypeEntity> entities) => await AddRangeAsync(entities);
  
    public async Task<IEnumerable<PetTypeEntity>> FindPetTypeAsync(Expression<Func<PetTypeEntity, bool>> predicate) => await FindAsync(predicate);

    public async Task<IEnumerable<PetTypeEntity>> GetAllPetTypesAsync() => await GetAllAsync();

    public async Task<PetTypeEntity?> GetPetTypeAsync(Guid id) => await GetAsync(id);

    public void RemovePetType(PetTypeEntity entity) => Remove(entity);

    public void RemoveRangePetType(IEnumerable<PetTypeEntity> entities) => RemoveRange(entities);
  
    public PetTypeEntity UpdatePetType(PetTypeEntity entity) => Update(entity); 
}
