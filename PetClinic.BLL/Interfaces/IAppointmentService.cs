using PetClinic.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.Interfaces;

public interface IAppointmentService
{
    Task AddAppointmentAsync(AddAppointmentDto appointment);
    Task<GetAppointmentDto> GetAppointmentByIdAsync(Guid id);
    Task<IEnumerable<GetAppointmentDto>> GetAppointmentsAsync();
    GetAppointmentDto UpdateAppointment(AddAppointmentDto appointment);
    void DeleteAppointment(Guid id);
}
