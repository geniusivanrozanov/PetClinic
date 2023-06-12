using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;


namespace PetClinic.DAL.Repositories;

public class AppointmentRepository : BaseRepository<AppointmentEntity, Guid>
{
    public AppointmentRepository(AppDbContext context) : base(context) { }
    
}
