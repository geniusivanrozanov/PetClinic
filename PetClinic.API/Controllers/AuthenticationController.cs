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

    [HttpPost("client/sign-up")]
    [AllowAnonymous]
    public async Task<string> RegisterUserAsync([FromBody] UserRegistrationRequestDto userData)
    {
        return await clientAccountService.RegisterClientAsync(userData);
    }

    [HttpPost("vet/sign-up")]
    [AllowAnonymous]
    public async Task<string> RegisterVetAsync([FromBody] VetRegistrationRequestDto userData)
    {        
        return await clientAccountService.RegisterVetAccount(userData);
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<string> LoginUserAsync([FromBody] LoginUserDto userData)
    {
        return await clientAccountService.LoginUserAsync(userData);
    }
}
