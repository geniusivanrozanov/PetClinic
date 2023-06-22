using Microsoft.AspNetCore.Mvc;
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
    public async Task AddAsync([FromBody] AddReviewDto review)
    {
        await vetService.AddReviewAsync(review);
    }

    [HttpGet("{id}")]
    public async Task<GetVetDto> GetByIdAsync([FromRoute] Guid id)
    {
        return await vetService.GetVetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IEnumerable<GetVetDto>> GetAllAsync()
    {
        return await vetService.GetVetsAsync();
    }

    [HttpGet("{vetId}/shedule/{appointmentDate}")]
    public async Task<IEnumerable<GetAppointmentDto>> GetScheduleAsync(DateTime appointmentDate, Guid vetId)
    {
        var getScheduleDto = new GetScheduleDto
        {
            AppointmentDate = appointmentDate,
            VetId = vetId,
        };

        return await vetService.GetScheduleAsync(getScheduleDto);
    }
}
