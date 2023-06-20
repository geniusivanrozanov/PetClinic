using PetClinic.DAL.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IVetRepository
{
    Task AddRangeVetAsync(IEnumerable<VetEntity> entities);
    Task<VetEntity> AddVetAsync(VetEntity entity);
    Task<IEnumerable<VetEntity>> FindVetAsync(Expression<Func<VetEntity, bool>> predicate);
    Task<IEnumerable<VetEntity>> GetAllVetsAsync();
    Task<VetEntity?> GetVetAsync(Guid id);
    void RemoveRangeVet(IEnumerable<VetEntity> entities);
    void RemoveVet(VetEntity entity);
    VetEntity UpdateVet(VetEntity entity);
}