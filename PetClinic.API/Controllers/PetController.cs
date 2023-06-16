using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Interfaces;


namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/Pet")]
public class PetController : ControllerBase
{
    private readonly IPetService petService;

    public PetController(IPetService petService)
    {
        this.petService = petService;
    }

    [HttpPost]
    public async Task Add(AddPetDto pet)
    {
        await petService.AddPetAsync(pet);
    }

    [HttpGet("id")]
    public async Task<GetPetDto> GetById(Guid id)
    {
        return await petService.GetPetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IEnumerable<GetPetDto>> GetAll()
    {
        return await petService.GetPetsAsync();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await petService.DeletePetAsync(id);

        return Ok(id);
    }

    [HttpPut("id")]
    public async Task<IActionResult> Update(UpdatePetDto appointment)
    {
        await petService.UpdatePetAsync(appointment);

        return Ok(appointment);
    }
}
