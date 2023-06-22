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
    public async Task Add(AddAppointmentDto appointment)
    {
        await appointmentService.AddAppointmentAsync(appointment);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy=PolicyNames.AdminPolicy)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await appointmentService.DeleteAppointmentAsync(id);

        return Ok(id);
    }

    [HttpGet("{id}")]
    [Authorize(Policy=PolicyNames.AdminClientPolicy)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var appointment = await appointmentService.GetAppointmentByIdAsync(id);
        return Ok(appointment);
    }

    [HttpGet]
    [Authorize(Policy=PolicyNames.AdminClientPolicy)]
    public async Task<IActionResult> GetAll()
    {
        var appointments = await appointmentService.GetAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpPut]
    [Authorize(Policy=PolicyNames.AdminPolicy)]
    public async Task<IActionResult> Update([FromBody] UpdateAppointmentDto appointment)
    {
        await appointmentService.UpdateAppointmentAsync(appointment);

        return Ok(appointment);
    }
}
