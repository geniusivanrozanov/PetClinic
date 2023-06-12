using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Repositories;

public class PetRepository : BaseRepository<PetEntity, Guid>
{
    public PetRepository(AppDbContext context) : base(context) { }
}
