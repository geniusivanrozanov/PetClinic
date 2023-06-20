using PetClinic.DAL.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IServiceRepository
{
    Task AddRangeServiceAsync(IEnumerable<ServiceEntity> entities);
    Task<ServiceEntity> AddServiceAsync(ServiceEntity entity);
    Task<IEnumerable<ServiceEntity>> FindServiceAsync(Expression<Func<ServiceEntity, bool>> predicate);
    Task<IEnumerable<ServiceEntity>> GetAllServicesAsync();
    Task<ServiceEntity?> GetServiceAsync(Guid id);
    void RemoveRangeService(IEnumerable<ServiceEntity> entities);
    void RemoveService(ServiceEntity entity);
    ServiceEntity UpdateService(ServiceEntity entity);
}