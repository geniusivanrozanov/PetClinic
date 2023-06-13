using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Repositories;

public class OrderCallRepository : BaseRepository<OrderCallEntity, Guid>
{
    public OrderCallRepository(AppDbContext context) : base(context) { }
}
