using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Repositories;

public class VetRepository : BaseRepository<VetEntity, Guid>
{
    public VetRepository(AppDbContext context) : base(context) { }
}
