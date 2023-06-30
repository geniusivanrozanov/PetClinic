using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Middlewares.Filters;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[ValidationFilter]
[Route("api/accounts")]
public class AuthenticationController : ControllerBase
{
    private readonly IUserAccountService _clientAccountService;
    
    public AuthenticationController(IUserAccountService clientAccountService)
    {
        _clientAccountService = clientAccountService;
    }

    [HttpPost("client/sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistrationRequestDto userData)
    {
        return Ok(await _clientAccountService.RegisterClientAsync(userData));
    }

    [HttpPost("vet/sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterVetAsync([FromBody] VetRegistrationRequestDto userData)
    {        
        return Ok(await _clientAccountService.RegisterVetAccount(userData));
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDto userData)
    {
        return Ok(await _clientAccountService.LoginUserAsync(userData));
    }
}
