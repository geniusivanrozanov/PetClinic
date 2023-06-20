using PetClinic.DAL.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IAppointmentRepository
{
    Task<AppointmentEntity?> GetAppointmentAsync(Guid id);
    Task<IEnumerable<AppointmentEntity>> GetAllAppointmentsAsync();
    Task<IEnumerable<AppointmentEntity>> FindAppointmentAsync(Expression<Func<AppointmentEntity, bool>> predicate);
    Task<AppointmentEntity> AddAppointmentAsync(AppointmentEntity entity);
    Task AddRangeAppointmentAsync(IEnumerable<AppointmentEntity> entities);
    void RemoveAppointment(AppointmentEntity entity);
    void RemoveRangeAppointment(IEnumerable<AppointmentEntity> entities);
    AppointmentEntity UpdateAppointment(AppointmentEntity entity);
}
