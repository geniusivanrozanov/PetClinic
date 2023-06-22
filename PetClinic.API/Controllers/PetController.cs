using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Interfaces;


namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/pets")]
public class PetController : ControllerBase
{
    private readonly IPetService petService;

    public PetController(IPetService petService)
    {
        this.petService = petService;
    }

    [HttpPost]
    public async Task AddAsync(AddPetDto pet)
    {
        await petService.AddPetAsync(pet);
    }

    [HttpGet("{id}")]
    public async Task<GetPetDto> GetByIdAsync([FromRoute] Guid id)
    {
        return await petService.GetPetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IEnumerable<GetPetDto>> GetAllAsync()
    {
        return await petService.GetPetsAsync();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await petService.DeletePetAsync(id);

        return Ok(id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePetDto appointment)
    {
        await petService.UpdatePetAsync(appointment);

        return Ok(appointment);
    }
}
