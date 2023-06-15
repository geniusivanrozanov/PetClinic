using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/Identity/Account")]
public class AuthenticationController : ControllerBase
{
    private readonly IUserAccountService clientAccountService;

    public AuthenticationController(IUserAccountService clientAccountService)
    {
        this.clientAccountService = clientAccountService;
    }

    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<string> RegisterUser([FromBody] UserRegistrationRequestDto userData)
    {
        return await clientAccountService.RegisterClientAsync(userData);
    }

    [HttpPost("Login")]
    [AllowAnonymous] // string123SDFG!
    public async Task<string> LoginUser([FromBody] LoginUserDto userData)
    {
        return await clientAccountService.LoginUserAsync(userData);
    }

    [HttpGet]
    [Authorize]
    public IActionResult TestMethod()
    {
        return Ok("Hello");
    }
}
