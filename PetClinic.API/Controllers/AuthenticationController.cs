using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;
using System.Text;
using System.Text.Json;

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

    [HttpGet("google/sign-up")]
    [AllowAnonymous]
    public IActionResult GetGoogleAuthUrl()
    {
        var authString = clientAccountService.GetAuthString();
        Response.Redirect(authString);

        return Ok(authString);
    }

    [HttpPost("google/sign-up")]
    public async Task<IActionResult> GetTokenFromGoogleCodeAsync([FromQuery] string code)
    {
        var token = await clientAccountService.RegisterUserWithGoogle(code);

        return Ok(token);
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

public class dsAuthorizationBroker : GoogleWebAuthorizationBroker
    {
        public static string RedirectUri;

        public new static async Task<UserCredential> AuthorizeAsync(
            ClientSecrets clientSecrets,
            IEnumerable<string> scopes,
            string user,
            CancellationToken taskCancellationToken,
            IDataStore dataStore = null)
        {
            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = clientSecrets,
            };
            return await AuthorizeAsyncCore(initializer, scopes, user,
                taskCancellationToken, dataStore).ConfigureAwait(false);
        }

        private static async Task<UserCredential> AuthorizeAsyncCore(
            GoogleAuthorizationCodeFlow.Initializer initializer,
            IEnumerable<string> scopes,
            string user,
            CancellationToken taskCancellationToken,
            IDataStore dataStore)
        {
            initializer.Scopes = scopes;
            initializer.DataStore = dataStore ?? new FileDataStore(Folder);
            var flow = new dsAuthorizationCodeFlow(initializer);
            
            return await new AuthorizationCodeInstalledApp(flow, 
                new LocalServerCodeReceiver())
                .AuthorizeAsync(user, taskCancellationToken).ConfigureAwait(false);
        }
    }


    public class dsAuthorizationCodeFlow : GoogleAuthorizationCodeFlow
    {
        public dsAuthorizationCodeFlow(Initializer initializer)
            : base(initializer) { }

        public override AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri)
        {
            return base.CreateAuthorizationCodeRequest(dsAuthorizationBroker.RedirectUri);
        }
    }    