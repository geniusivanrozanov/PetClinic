using PetClinic.DAL.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IDepartmentRepository
{
    Task<DepartmentEntity?> GetDepartmentAsync(Guid id);
    Task<IEnumerable<DepartmentEntity>> GetAllDepartmentsAsync();
    Task<IEnumerable<DepartmentEntity>> FindDepartmentAsync(Expression<Func<DepartmentEntity, bool>> predicate);
    Task<DepartmentEntity> AddDepartmentAsync(DepartmentEntity entity);
    Task AddRangeDepartmentAsync(IEnumerable<DepartmentEntity> entities);
    void RemoveDepartment(DepartmentEntity entity);
    void RemoveRangeDepartment(IEnumerable<DepartmentEntity> entities);
    DepartmentEntity UpdateDepartment(DepartmentEntity entity);
}
