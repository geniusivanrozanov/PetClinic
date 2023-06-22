using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/pet-types")]
public class PetTypeController : ControllerBase
{
    private readonly IPetTypeService petTypeService;

    public PetTypeController(IPetTypeService petTypeService)
    {
        this.petTypeService = petTypeService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetPetTypesAsync()
    {
        var petTypes = await petTypeService.GetPetTypesAsync();

        return Ok(petTypes);
    }
}

