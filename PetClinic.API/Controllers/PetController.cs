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
[Route("api/pets")]
public class PetController : ControllerBase
{
    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpPost]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task AddAsync(AddPetDto pet)
    {
        await _petService.AddPetAsync(pet);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = $"{Roles.ClientRole}, {Roles.AdminRole}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _petService.GetPetByIdAsync(id));
    }

    [HttpGet]
    [Authorize(Roles = $"{Roles.ClientRole}, {Roles.AdminRole}")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _petService.GetPetsAsync());
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _petService.DeletePetAsync(id);

        return Ok(id);
    }

    [HttpPut]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePetDto appointment)
    {
        await _petService.UpdatePetAsync(appointment);

        return Ok(appointment);
    }
}
