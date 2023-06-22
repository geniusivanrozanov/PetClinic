using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Extensions;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;


namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/vets")]
public class VetController
{
    private readonly IVetService vetService;

    public VetController(IVetService vetService)
    {
        this.vetService = vetService;
    }


    [HttpPost("review")]
    [Authorize(Policy = PolicyNames.VetPolicy)]
    public async Task Add([FromBody] AddReviewDto review)
    {
        await vetService.AddReviewAsync(review);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<GetVetDto> GetById([FromRoute] Guid id)
    {
        return await vetService.GetVetByIdAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IEnumerable<GetVetDto>> GetAll()
    {
        return await vetService.GetVetsAsync();
    }

    [HttpGet("{vetId}/shedule/{appointmentDate}")]
    
    public async Task<IEnumerable<GetAppointmentDto>> GetSchedule(DateOnly appointmentDate, Guid vetId) // (GetScheduleDto getScheduleDto)
    {
        var getScheduleDto = new GetScheduleDto
        {
            AppointmentDate = appointmentDate,
            VetId = vetId,
        };

        return await vetService.GetScheduleAsync(getScheduleDto);
    }
}
