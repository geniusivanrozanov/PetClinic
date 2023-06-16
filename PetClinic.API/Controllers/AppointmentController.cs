using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/Appointment")]

public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        this.appointmentService = appointmentService;
    }


    [HttpPost]
    public async Task Add(AddAppointmentDto appointment)
    {
        await appointmentService.AddAppointmentAsync(appointment);
    }

    [HttpDelete("id")]
    public void Delete(Guid id)
    {
        appointmentService.DeleteAppointment(id);
    }

    [HttpGet("id")]
    public async Task<GetAppointmentDto> GetById(Guid id)
    {
        return await appointmentService.GetAppointmentByIdAsync(id);
    }

    [HttpGet]
    public  async Task<IEnumerable<GetAppointmentDto>> GetAll()
    {
        return await appointmentService.GetAppointmentsAsync();
    }

    [HttpPut("id")]
    public GetAppointmentDto Update(AddAppointmentDto appointment, Guid id)
    {
        return appointmentService.UpdateAppointment(appointment, id);
    }
}
