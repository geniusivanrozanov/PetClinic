using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;

namespace PetClinic.API.Controllers;

[ApiController]
<<<<<<< HEAD
[Route("api/accounts")]
=======
[Route("api/account")]
>>>>>>> refs/remotes/origin/feature-api-layer
public class AuthenticationController : ControllerBase
{
    private readonly IUserAccountService clientAccountService;
    
    public AuthenticationController(IUserAccountService clientAccountService)
    {
        this.clientAccountService = clientAccountService;
    }

    [HttpPost("client/sign-up")]
    [AllowAnonymous]
    public async Task<string> RegisterUser([FromBody] UserRegistrationRequestDto userData)
    {
        return await clientAccountService.RegisterClientAsync(userData);
    }

    [HttpPost("vet/sign-up")]
    [AllowAnonymous]
    public async Task<string> RegisterVet([FromBody] VetRegistrationRequestDto userData)
    {        
        return await clientAccountService.RegisterVetAccount(userData);
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
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
