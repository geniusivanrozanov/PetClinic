using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class ServiceVetRepository : BaseRepository<ServiceVetEntity, Guid>, IServiceVetVetRepository
{
    public ServiceVetRepository(AppDbContext context) : base(context) { }

    public async Task AddRangeServiceVetAsync(IEnumerable<ServiceVetEntity> entities) => await AddRangeAsync(entities);

    public async Task<ServiceVetEntity> AddServiceVetAsync(ServiceVetEntity entity) => await AddAsync(entity);

    public async Task<IEnumerable<ServiceVetEntity>> FindServiceVetAsync(Expression<Func<ServiceVetEntity, bool>> predicate) => await FindAsync(predicate);

    public async Task<IEnumerable<ServiceVetEntity>> GetAllServiceVetsAsync() => await GetAllAsync();

    public async Task<ServiceVetEntity?> GetServiceVetAsync(Guid id) => await GetAsync(id);

    public void RemoveRangeServiceVet(IEnumerable<ServiceVetEntity> entities) => RemoveRange(entities);

    public void RemoveServiceVet(ServiceVetEntity entity) => Remove(entity);

    public ServiceVetEntity UpdateServiceVet(ServiceVetEntity entity) => Update(entity);
}
