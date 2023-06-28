using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;

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
    [Authorize(Roles = Roles.ClientRole)]
    public async Task AddAsync(AddPetDto pet)
    {
        await petService.AddPetAsync(pet);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = $"{Roles.ClientRole}, {Roles.AdminRole}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        return Ok(await petService.GetPetByIdAsync(id));
    }

    [HttpGet]
    [Authorize(Roles = $"{Roles.ClientRole}, {Roles.AdminRole}")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await petService.GetPetsAsync());
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await petService.DeletePetAsync(id);

        return Ok(id);
    }

    [HttpPut]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePetDto appointment)
    {
        await petService.UpdatePetAsync(appointment);

        return Ok(appointment);
    }
}
