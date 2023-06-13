using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Repositories;

public class AppointmentRepository : BaseRepository<AppointmentEntity, Guid>
{
    public AppointmentRepository(AppDbContext context) : base(context) { }
    
}
