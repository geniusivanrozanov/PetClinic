using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Middlewares.Filters;
using PetClinic.BLL.DTOs.PagingDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[ValidationFilter]
[Route("api/pet-types")]
[AllowAnonymous]
public class PetTypeController : ControllerBase
{
    private readonly IPetTypeService _petTypeService;

    public PetTypeController(IPetTypeService petTypeService)
    {
        _petTypeService = petTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPetTypesAsync()
    {
        var petTypes = await _petTypeService.GetPetTypesAsync();

        return Ok(petTypes);
    }

    [HttpGet("paging")]
    public async Task<IActionResult> GetPetTypesPagingAsync([FromQuery] PetTypeParametersDto petTypeParametersDto)
    {
        var petTypes = await _petTypeService.GetPetTypesPagedAsync(petTypeParametersDto);

        return Ok(petTypes);
    }
}

