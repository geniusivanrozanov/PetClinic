using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Middlewares.Filters;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;

namespace PetClinic.API.Controllers;

[ApiController]
[ValidationFilter]
[Route("api/appointments")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly IConfiguration config;

    public AppointmentController(IAppointmentService appointmentService, IConfiguration config)
    {
        this._appointmentService = appointmentService;
        this.config = config;
    }

    [HttpPost]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> AddAsync(AddAppointmentDto appointment)
    {
        await _appointmentService.AddAppointmentAsync(appointment);

        return Created("", appointment);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.AdminRole)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _appointmentService.DeleteAppointmentAsync(id);

        return Ok(id);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

        return Ok(appointment);
    }

    [HttpGet]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> GetAllAsync()
    {
        var appointments = await _appointmentService.GetAppointmentsAsync();

        return Ok(appointments);
    }

    [HttpPut]
    [Authorize(Roles = Roles.AdminRole)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAppointmentDto appointment)
    {
        await _appointmentService.UpdateAppointmentAsync(appointment);

        return Ok(appointment);
    }
}
