using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;
using System.Text;

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

    [HttpPost("google/sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterThroughGoogleAsync()
    {
        var clientId = "867055353627-vsg9n4r105df7ifv4dr2mqk4nhrortjn.apps.googleusercontent.com";
        var redirectUri = "https://localhost:7124/accounts/google/sign-up";

        var scopes = new StringBuilder();
        
        scopes.Append("https://www.googleapis.com/auth/userinfo.email ");
        scopes.Append("https://www.googleapis.com/auth/userinfo.profile ");
        scopes.Append("https://www.googleapis.com/auth/calendar");
        
        var authString = $"https://accounts.google.com/o/oauth2/auth?client_id={clientId}&redirect_uri={redirectUri}&access_type=offline&response_type=code&scope={scopes}";
        
        Response.Redirect(authString);

        return Ok(authString);
    }

    [HttpPost("google/sign-up/token")]
    public async Task<IActionResult> GetTokenFromGoogleCodeAsync([FromQuery] string code)
    {
        var clientSecrets = new ClientSecrets
        {
            ClientId = "867055353627-vsg9n4r105df7ifv4dr2mqk4nhrortjn.apps.googleusercontent.com",
            ClientSecret = "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"
        };

        var credential = new GoogleAuthorizationCodeFlow(
            new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = clientSecrets
            });

        TokenResponse token = await credential.ExchangeCodeForTokenAsync(
            "",
            code,
            "https://localhost:7124/accounts/google/sign-up",
            CancellationToken.None
        );

        var user = await GetUserInfoByToken(token.AccessToken);

        return Ok(user);
    }

    private async Task<GoogleDataResponse> GetUserInfoByToken(string token)
    {
        HttpClient client = new HttpClient();

        string cliUrl = $"https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token={token}";

        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, cliUrl);
        using HttpResponseMessage response = await client.SendAsync(request);

        var jsonUserData = await response.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<GoogleDataResponse>(jsonUserData);

        var userEntity = new UserGoogleRegistrationDto
        {

        };

        return user;
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
