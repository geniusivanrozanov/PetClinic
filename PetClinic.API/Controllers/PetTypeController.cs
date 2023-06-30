using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Middlewares.Filters;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[ValidationFilter]
[Route("api/pet-types")]
public class PetTypeController : ControllerBase
{
    private readonly IPetTypeService _petTypeService;

    public PetTypeController(IPetTypeService petTypeService)
    {
        _petTypeService = petTypeService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetPetTypesAsync()
    {
        var petTypes = await _petTypeService.GetPetTypesAsync();

        return Ok(petTypes);
    }
}

