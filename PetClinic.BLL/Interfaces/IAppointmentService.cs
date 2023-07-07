using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IAppointmentService
{
    Task AddAppointmentAsync(AddAppointmentDto appointment);
    Task<GetAppointmentDto> GetAppointmentByIdAsync(Guid id);
    Task<IEnumerable<GetAppointmentDto>> GetAppointmentsAsync(Guid userId);
    Task<GetAppointmentDto> UpdateAppointmentAsync(UpdateAppointmentDto appointment);
    Task DeleteAppointmentAsync(Guid id);
}
