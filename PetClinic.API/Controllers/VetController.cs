using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;


namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/Vet")]
public class VetController
{
    private readonly IVetService vetService;

    public VetController(IVetService vetService)
    {
        this.vetService = vetService;
    }


    [HttpPost("add-review")]
    public async Task Add(AddReviewDto review)
    {
        await vetService.AddReviewAsync(review);
    }

    [HttpGet("id")]
    public async Task<GetVetDto> GetById(Guid id)
    {
        return await vetService.GetVetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IEnumerable<GetVetDto>> GetAll()
    {
        return await vetService.GetVetsAsync();
    }

    [HttpGet]
    public async Task<IEnumerable<GetAppointmentDto>> GetSchedule(GetScheduleDto getScheduleDto)
    {
        return await vetService.GetScheduleAsync(getScheduleDto);
    }
}
