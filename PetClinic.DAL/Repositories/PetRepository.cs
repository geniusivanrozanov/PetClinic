using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class PetRepository : BaseRepository<PetEntity, Guid>, IPetRepository
{
    public PetRepository(AppDbContext context) : base(context) { }

    public async Task<PetEntity> AddPetAsync(PetEntity entity) => await AddAsync(entity);

    public async Task AddRangePetAsync(IEnumerable<PetEntity> entities) => await AddRangeAsync(entities);

    public async Task<IEnumerable<PetEntity>> FindPetAsync(Expression<Func<PetEntity, bool>> predicate) => await FindAsync(predicate);

    public async Task<IEnumerable<PetEntity>> GetAllPetAsync() => await GetAllAsync();

    public async Task<PetEntity?> GetPetAsync(Guid id) => await GetAsync(id);

    public void RemovePet(PetEntity entity) => Remove(entity);

    public void RemoveRangePet(IEnumerable<PetEntity> entities) => RemoveRange(entities);
   
    public PetEntity UpdatePet(PetEntity entity) => Update(entity);
}
