using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class AppointmentRepository : BaseRepository<AppointmentEntity, Guid>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext context) : base(context) { }

    public async Task<AppointmentEntity> AddAppointmentAsync(AppointmentEntity entity) => await AddAsync(entity);
    
    public async Task AddRangeAppointmentAsync(IEnumerable<AppointmentEntity> entities) => await AddRangeAsync(entities);
  
    public async Task<IEnumerable<AppointmentEntity>> FindAppointmentAsync(Expression<Func<AppointmentEntity, bool>> predicate) => await FindAsync(predicate);
   
    public async Task<IEnumerable<AppointmentEntity>> GetAllAppointmentsAsync() => await GetAllAsync();
  
    public async Task<AppointmentEntity?> GetAppointmentAsync(Guid id) => await GetAsync(id);

    public void RemoveAppointment(AppointmentEntity entity) => Remove(entity);
   
    public void RemoveRangeAppointment(IEnumerable<AppointmentEntity> entities) => RemoveRange(entities);

    public AppointmentEntity UpdateAppointment(AppointmentEntity entity) => Update(entity);
}
