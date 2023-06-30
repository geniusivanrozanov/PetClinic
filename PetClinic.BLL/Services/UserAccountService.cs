using System.Security.Claims;
using System.Text;
using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.DTOs.DeleteMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Utilites;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.ExceptionConstants;


namespace PetClinic.BLL.Services;

public class UserAccountService : IUserAccountService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    public UserAccountService(
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager, 
        IMapper mapper, 
        IUnitOfWork unitOfWork,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    public async Task<IEnumerable<GetUserDto>> GetAllAccounts()
    {
        var accounts = await _userManager.Users.ToListAsync();
        var accountsDto = _mapper.Map<IEnumerable<GetUserDto>>(accounts);

        return accountsDto;
    }

    public string GetAuthString()
    {
        var clientId = "867055353627-vsg9n4r105df7ifv4dr2mqk4nhrortjn.apps.googleusercontent.com";
        var redirectUri = "https://localhost:7124/accounts/google/sign-up";

        var scopes = new StringBuilder();
        
        scopes.Append("https://www.googleapis.com/auth/userinfo.email ");
        scopes.Append("https://www.googleapis.com/auth/userinfo.profile ");
        scopes.Append("https://www.googleapis.com/auth/calendar");
        
        var authString = $"https://accounts.google.com/o/oauth2/auth?client_id={clientId}&redirect_uri={redirectUri}&access_type=offline&response_type=code&scope={scopes}";
        
        return authString;
    }

    public async Task<string> RegisterUserWithGoogle(string code)
    {
        var googleToken = await GetGoogleAccessTokenAsync(code);
        var userGoogleRegistrationDto = await GetUserInfoByToken(googleToken);
        var userData = _mapper.Map<UserRegistrationRequestDto>(userGoogleRegistrationDto);
        userData.UserName = "Veronika";
        userData.Password = "String123456!789#";
        
        var newUser = await RegisterUserAccount(userData, DAL.Entities.Roles.ClientRole);

        await _unitOfWork.CompleteAsync();
        
        await _userManager.AddLoginAsync(newUser, new UserLoginInfo("Google", googleToken, newUser.FirstName));

        var jwtToken = await _tokenService.GenerateJwtTokenAsync(newUser);

        return jwtToken;
    }

    public async Task<string> RegisterClientAsync(UserRegistrationRequestDto userData)
    {
        var newUser = await RegisterUserAccount(userData, DAL.Entities.Roles.ClientRole);

        await _unitOfWork.CompleteAsync();

        var token = await _tokenService.GenerateJwtTokenAsync(newUser);

        return token;
    }

    public async Task<string> RegisterVetAccount(VetRegistrationRequestDto vetRegisterData)
    {
        var userData = _mapper.Map<UserRegistrationRequestDto>(vetRegisterData.AccountData);
        var vetData = _mapper.Map<AddVetDto>(vetRegisterData.VetInfo);
        vetData.FirstName = vetRegisterData.AccountData.FirstName;
        vetData.LastName = vetRegisterData.AccountData.LastName;

        var newUser = await RegisterUserAccount(userData, DAL.Entities.Roles.VetRole);
        
        var newVet = _mapper.Map<VetEntity>(vetData);
        newVet.ClientId = newUser.Id;
        
        await _unitOfWork.VetRepository.AddAsync(newVet);
        await _unitOfWork.CompleteAsync();

        var token = await _tokenService.GenerateJwtTokenAsync(newUser);

        return token;
    }
    
    public async Task<string> LoginUserAsync(LoginUserDto userData)
    {
        var existingUser = await _userManager.FindByEmailAsync(userData.Email) ??
            throw new UserDoesNotExistException(ExceptionMessages.UserDoesNotExist);

        var passwordIsCorrect = await _userManager.CheckPasswordAsync(existingUser, userData.Password);

        if (!passwordIsCorrect)
        {
            throw new Exceptions.InvalidDataException(ExceptionMessages.InvalidPassword);
        }

        var jwtToken = await _tokenService.GenerateJwtTokenAsync(existingUser);

        return jwtToken;
    }

    public async Task UpdateUserAccount(UpdateUserAccountDto userData)
    {
        var user = _mapper.Map<UserEntity>(userData);

        await _userManager.UpdateAsync(user);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteUserAccount(DeleteUserAccountDto account)
    {
        var userToDelete = await _userManager.FindByIdAsync($"{account.AccountId}");

        await _userManager.DeleteAsync(userToDelete);
        await _unitOfWork.CompleteAsync();
    }

    private async Task<string> GetGoogleAccessTokenAsync(string code)
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

        return token.AccessToken;
    }

    private async Task<UserGoogleRegistrationDto> GetUserInfoByToken(string token)
    {
        HttpClient client = new HttpClient();

        string cliUrl = $"https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token={token}";

        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, cliUrl);
        using HttpResponseMessage response = await client.SendAsync(request);

        var jsonUserData = await response.Content.ReadAsStringAsync();
        
        var user = JsonConvert.DeserializeObject<GoogleDataResponse>(jsonUserData);

        var userGoogleRegistrationDto = _mapper.Map<UserGoogleRegistrationDto>(user);

        return userGoogleRegistrationDto;
    }

    private async Task<UserEntity> RegisterUserAccount(UserRegistrationRequestDto userData, string role)
    {
        var userIsExist = await _userManager.FindByEmailAsync(userData.Email);
    
        if (userIsExist is not null)
        {
            throw new UserAlreadyExistsException(ExceptionMessages.UserAlreadyExists);
        }

        var newUser = _mapper.Map<UserEntity>(userData);

        var isCreated = await _userManager.CreateAsync(newUser, userData.Password);

        if (!isCreated.Succeeded)
        {
            throw new RegistrationFailedException(ExceptionMessages.RegistrationFailed);
        }

        await _userManager.AddToRoleAsync(newUser, role);
        await _userManager.AddClaimAsync(newUser, new Claim(ClaimTypes.Role, role));

        await _unitOfWork.CompleteAsync();

        return newUser;
    }
}
