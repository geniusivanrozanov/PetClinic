using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class VetRepository : BaseRepository<VetEntity, Guid>, IVetRepository
{
    public VetRepository(AppDbContext context) : base(context) { }

    public async Task AddRangeVetAsync(IEnumerable<VetEntity> entities) => await AddRangeAsync(entities);

    public async Task<VetEntity> AddVetAsync(VetEntity entity) => await AddAsync(entity);

    public async Task<IEnumerable<VetEntity>> FindVetAsync(Expression<Func<VetEntity, bool>> predicate) => await FindAsync(predicate);

    public async Task<IEnumerable<VetEntity>> GetAllVetsAsync() => await GetAllAsync();

    public async Task<VetEntity?> GetVetAsync(Guid id) => await GetAsync(id);

    public void RemoveRangeVet(IEnumerable<VetEntity> entities) => RemoveRange(entities);

    public void RemoveVet(VetEntity entity) => Remove(entity);

    public VetEntity UpdateVet(VetEntity entity) => Update(entity);
}
