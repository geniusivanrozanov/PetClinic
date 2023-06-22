using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Interfaces;


namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/appointments")]
[AllowAnonymous]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        this.appointmentService = appointmentService;
    }

    [HttpPost]
    public async Task AddAsync(AddAppointmentDto appointment)
    {
        await appointmentService.AddAppointmentAsync(appointment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await appointmentService.DeleteAppointmentAsync(id);

        return Ok(id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var appointment = await appointmentService.GetAppointmentByIdAsync(id);
        return Ok(appointment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var appointments = await appointmentService.GetAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAppointmentDto appointment)
    {
        await appointmentService.UpdateAppointmentAsync(appointment);

        return Ok(appointment);
    }
}
