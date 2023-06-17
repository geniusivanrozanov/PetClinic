using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/services")]
public class ServicesController : ControllerBase
{
    private readonly IServicesService _servicesService;

    public ServicesController(IServicesService servicesService)
    {
        _servicesService = servicesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetServicesAsync()
    {
        var services = await _servicesService.GetServicesAsync();

        return Ok(services);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetServiceByIdAsync([FromRoute] Guid id)
    {
        var service = await _servicesService.GetServiceByIdAsync(id);

        return Ok(service);
    }
}
