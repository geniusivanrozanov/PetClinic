using PetClinic.DAL.Entities;



namespace PetClinic.DAL.Repositories;

public class ReviewRepository : BaseRepository<ReviewEntity, Guid>
{
    public ReviewRepository(AppDbContext context) : base(context) { }
}
