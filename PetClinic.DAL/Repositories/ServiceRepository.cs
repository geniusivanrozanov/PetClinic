using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class ServiceRepository : BaseRepository<ServiceEntity, Guid>, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context) { }

    public async Task AddRangeServiceAsync(IEnumerable<ServiceEntity> entities) => await AddRangeAsync(entities);

    public async Task<ServiceEntity> AddServiceAsync(ServiceEntity entity) => await AddAsync(entity);

    public async Task<IEnumerable<ServiceEntity>> FindServiceAsync(Expression<Func<ServiceEntity, bool>> predicate) => await FindAsync(predicate);

    public async Task<IEnumerable<ServiceEntity>> GetAllServicesAsync() => await GetAllAsync();

    public async Task<ServiceEntity?> GetServiceAsync(Guid id) => await GetAsync(id);

    public void RemoveRangeService(IEnumerable<ServiceEntity> entities) => RemoveRange(entities);

    public void RemoveService(ServiceEntity entity) => Remove(entity);

    public ServiceEntity UpdateService(ServiceEntity entity) => Update(entity);
}
