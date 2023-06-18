using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IAppointmentService
{
    Task<Guid> AddAppointmentAsync(AddAppointmentDto appointment);
    Task<GetAppointmentDto> GetAppointmentByIdAsync(Guid id);
    Task<IEnumerable<GetAppointmentDto>> GetAppointmentsAsync();
    Task<GetAppointmentDto> UpdateAppointmentAsync(UpdateAppointmentDto appointment);
    Task DeleteAppointmentAsync(Guid id);
}
