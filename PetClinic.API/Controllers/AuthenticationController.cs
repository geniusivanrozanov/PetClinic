using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IClientAccountService clientAccountService;

    public AuthenticationController(IClientAccountService clientAccountService)
    {
        this.clientAccountService = clientAccountService;
    }

    [HttpPost("sign-up")]
    public Task<string> RegisterUser([FromBody] UserRegistrationRequestDto userData)
    {
        return clientAccountService.RegisterUser(userData);
    }
}
