using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.PagingDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/pet-types")]
[AllowAnonymous]
public class PetTypeController : ControllerBase
{
    private readonly IPetTypeService petTypeService;

    public PetTypeController(IPetTypeService petTypeService)
    {
        this.petTypeService = petTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPetTypesAsync()
    {
        var petTypes = await petTypeService.GetPetTypesAsync();

        return Ok(petTypes);
    }

    [HttpGet("paging")]
    public async Task<IActionResult> GetPetTypesPagingAsync([FromQuery] PetTypeParametersDto petTypeParametersDto)
    {
        var petTypes = await petTypeService.GetPetTypesPagedAsync(petTypeParametersDto);

        return Ok(petTypes);
    }
}

