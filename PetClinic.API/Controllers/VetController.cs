using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;


namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/vets")]
public class VetController : ControllerBase
{
    private readonly IVetService vetService;

    public VetController(IVetService vetService)
    {
        this.vetService = vetService;
    }

    [HttpPost("review")]
    public async Task Add([FromBody] AddReviewDto review)
    {
        await vetService.AddReviewAsync(review);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(await vetService.GetVetByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await vetService.GetVetsAsync());
    }

    [HttpGet("{vetId}/shedule/{appointmentDate}")]
    public async Task<IActionResult> GetSchedule(DateOnly appointmentDate, Guid vetId) // (GetScheduleDto getScheduleDto)
    {
        var getScheduleDto = new GetScheduleDto
        {
            AppointmentDate = appointmentDate,
            VetId = vetId,
        };

        return Ok(await vetService.GetScheduleAsync(getScheduleDto));
    }
}
