using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/accounts")]
public class AuthenticationController : ControllerBase
{
    private readonly IUserAccountService clientAccountService;
    
    public AuthenticationController(IUserAccountService clientAccountService)
    {
        this.clientAccountService = clientAccountService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterThroughGoogle()
    {
        var clientId = "";
        var authString = $"https://accounts.google.com/o/oauth2/auth?client_id={clientId}&redirect_uri={redirect_uri}&access_type=offline&response_type=code&scope={scopes.join(' ')}";
        return Ok();
    }

    [HttpPost("client/sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistrationRequestDto userData)
    {
        return Ok(await clientAccountService.RegisterClientAsync(userData));
    }

    [HttpPost("vet/sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterVetAsync([FromBody] VetRegistrationRequestDto userData)
    {        
        return Ok(await clientAccountService.RegisterVetAccount(userData));
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDto userData)
    {
        return Ok(await clientAccountService.LoginUserAsync(userData));
    }
}
