using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Extensions;
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
    [Authorize(Policy=PolicyNames.AdminClientPolicy)]
    public async Task<IActionResult> AddAsync(AddAppointmentDto appointment)
    {
        await appointmentService.AddAppointmentAsync(appointment);
        return Created("", appointment);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy=PolicyNames.AdminPolicy)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await appointmentService.DeleteAppointmentAsync(id);
        return Ok(id);
    }

    [HttpGet("{id}")]
    [Authorize(Policy=PolicyNames.AdminClientPolicy)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var appointment = await appointmentService.GetAppointmentByIdAsync(id);
        return Ok(appointment);
    }

    [HttpGet]
    [Authorize(Policy=PolicyNames.AdminClientPolicy)]
    public async Task<IActionResult> GetAllAsync()
    {
        var appointments = await appointmentService.GetAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpPut]
    [Authorize(Policy=PolicyNames.AdminPolicy)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAppointmentDto appointment)
    {
        await appointmentService.UpdateAppointmentAsync(appointment);
        return Ok(appointment);
    }
}
