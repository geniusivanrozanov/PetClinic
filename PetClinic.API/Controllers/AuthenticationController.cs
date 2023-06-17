using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/account")]
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

    [HttpPost("sign-in")]
    [AllowAnonymous] // string123SDFG!!
    public async Task<string> LoginUser([FromBody] LoginUserDto userData)
    {
        return await clientAccountService.LoginUserAsync(userData);
    }

    [HttpGet]
    [Authorize(Roles = Roles.ClientRole)]
    public IActionResult TestMethod()
    {
        return Ok("Hello");
    }
}
