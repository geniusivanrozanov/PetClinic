using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Middlewares.Filters;
using Newtonsoft.Json;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;
using System.Text;
using System.Text.Json;

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

    [HttpGet("google/sign-up")]
    [AllowAnonymous]
    public IActionResult GetGoogleAuthUrl()
    {
        var authString = _clientAccountService.GetAuthString();
        Response.Redirect(authString);

        return Ok(authString);
    }

    [HttpPost("google/sign-up")]
    public async Task<IActionResult> GetTokenFromGoogleCodeAsync([FromQuery] string code)
    {
        var token = await _clientAccountService.RegisterUserWithGoogle(code);

        return Ok(token);
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
