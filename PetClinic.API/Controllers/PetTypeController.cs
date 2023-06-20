using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers
{
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
        public async Task<IActionResult> GetPetTypes()
        {
            var petTypes = await petTypeService.GetPetTypes();

            return Ok(petTypes);
        }
    }
}
