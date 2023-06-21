using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class DepartmentRepository : BaseRepository<DepartmentEntity, Guid>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context) { }

    public async Task<DepartmentEntity> AddDepartmentAsync(DepartmentEntity entity) => await AddAsync(entity);
   
    public async Task AddRangeDepartmentAsync(IEnumerable<DepartmentEntity> entities) => await AddRangeAsync(entities);
  
    public async Task<IEnumerable<DepartmentEntity>> FindDepartmentAsync(Expression<Func<DepartmentEntity, bool>> predicate) => await FindAsync(predicate);
  
    public async Task<IEnumerable<DepartmentEntity>> GetAllDepartmentsAsync() => await GetAllAsync();
    
    public async Task<DepartmentEntity?> GetDepartmentAsync(Guid id) => await GetAsync(id);

    public void RemoveDepartment(DepartmentEntity entity) => Remove(entity);
  
    public void RemoveRangeDepartment(IEnumerable<DepartmentEntity> entities) => RemoveRange(entities);

    public DepartmentEntity UpdateDepartment(DepartmentEntity entity) => Update(entity);
}
