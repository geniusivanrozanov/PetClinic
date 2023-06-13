using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Repositories;

public class ServiceRepository : BaseRepository<ServiceEntity, Guid>
{
    public ServiceRepository(AppDbContext context) : base(context) { }
}
