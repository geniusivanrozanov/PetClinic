using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
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
    public async Task<IActionResult> Delete(Guid id)
    {
        await appointmentService.DeleteAppointmentAsync(id);

        return Ok(id);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var appointment = await appointmentService.GetAppointmentByIdAsync(id);
        return Ok(appointment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var appointments = await appointmentService.GetAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpPut("id")]
    public async Task<IActionResult> Update(UpdateAppointmentDto appointment)
    {
        await appointmentService.UpdateAppointmentAsync(appointment);

        return Ok(appointment);
    }
}
