using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Repositories;

public class DepartmentRepository : BaseRepository<DepartmentEntity, Guid>
{
    public DepartmentRepository(AppDbContext context) : base(context) { }
}
