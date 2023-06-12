using PetClinic.DAL.Entities;


namespace PetClinic.DAL.Repositories;

public class PetTypeRepository : BaseRepository<PetTypeEntity, Guid>
{
    public PetTypeRepository(AppDbContext context) : base(context) { }
}
