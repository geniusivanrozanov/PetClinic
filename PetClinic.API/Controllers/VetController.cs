using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Extensions;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;


namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/vets")]
[AllowAnonymous]
public class VetController : ControllerBase
{
    private readonly IVetService vetService;

    public VetController(IVetService vetService)
    {
        this.vetService = vetService;
    }

    [HttpPost("review")]
    [Authorize(Policy = PolicyNames.VetPolicy)]
    public async Task<IActionResult> AddAsync([FromBody] AddReviewDto review)
    {
        await vetService.AddReviewAsync(review);

        return Created("", review);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        return Ok(await vetService.GetVetByIdAsync(id));
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await vetService.GetVetsAsync());
    }

    [HttpGet("{vetId}/shedule/{appointmentDate}")]
    [Authorize(Policy = PolicyNames.AdminVetPolicy)]
    public async Task<IActionResult> GetScheduleAsync(DateTime appointmentDate, Guid vetId)
    {
        var getScheduleDto = new GetScheduleDto
        {
            AppointmentDate = appointmentDate,
            VetId = vetId,
        };

        return Ok(await vetService.GetScheduleAsync(getScheduleDto));
    }
}
