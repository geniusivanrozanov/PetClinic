using PetClinic.DAL.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IServiceVetVetRepository
{
    Task AddRangeServiceVetAsync(IEnumerable<ServiceVetEntity> entities);
    Task<ServiceVetEntity> AddServiceVetAsync(ServiceVetEntity entity);
    Task<IEnumerable<ServiceVetEntity>> FindServiceVetAsync(Expression<Func<ServiceVetEntity, bool>> predicate);
    Task<IEnumerable<ServiceVetEntity>> GetAllServiceVetsAsync();
    Task<ServiceVetEntity?> GetServiceVetAsync(Guid id);
    void RemoveRangeServiceVet(IEnumerable<ServiceVetEntity> entities);
    void RemoveServiceVet(ServiceVetEntity entity);
    ServiceVetEntity UpdateServiceVet(ServiceVetEntity entity);
}