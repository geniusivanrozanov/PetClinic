using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Extensions;
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
    [Authorize(Policy = PolicyNames.ClientPolicy)]
    public async Task Add(AddPetDto pet)
    {
        await petService.AddPetAsync(pet);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = PolicyNames.AdminClientPolicy)]
    public async Task<GetPetDto> GetById([FromRoute] Guid id)
    {
        return await petService.GetPetByIdAsync(id);
    }

    [HttpGet]
    [Authorize(Policy = PolicyNames.AdminPolicy)]
    public async Task<IEnumerable<GetPetDto>> GetAll()
    {
        return await petService.GetPetsAsync();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = PolicyNames.ClientPolicy)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await petService.DeletePetAsync(id);

        return Ok(id);
    }

    [HttpPut]
    [Authorize(Policy = PolicyNames.ClientPolicy)]
    public async Task<IActionResult> Update([FromBody] UpdatePetDto appointment)
    {
        await petService.UpdatePetAsync(appointment);

        return Ok(appointment);
    }
}
