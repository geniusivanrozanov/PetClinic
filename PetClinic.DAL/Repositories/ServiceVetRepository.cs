using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Repositories;

public class ServiceVetRepository : BaseRepository<ServiceVetEntity, Guid>
{
    public ServiceVetRepository(AppDbContext context) : base(context) { }
}
