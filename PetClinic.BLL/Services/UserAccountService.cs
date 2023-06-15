using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetClinic.BLL.Configurations;
using PetClinic.BLL.DTOs;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

namespace PetClinic.BLL.Services;

public class UserAccountService : IUserAccountService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly JwtConfig _jwtConfig;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    private readonly IUnitOfWork _unitOfWork;

    public UserAccountService(UserManager<UserEntity> userManager, IMapper mapper, IConfiguration config, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _config = config;
        _jwtConfig = new JwtConfig
        {
            Secret = _config!["JwtConfig:Secret"]
        };
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GetUserDto>> GetAllAccounts()
    {
        var accounts = await _userManager.Users.ToListAsync();

        var accountsDto = _mapper.Map<IEnumerable<GetUserDto>>(accounts);

        return  accountsDto;
    }

    public async Task<string> RegisterClientAsync(UserRegistrationRequestDto userData)
    {
        var newUser = await RegisterUserAccount(userData, DAL.Entities.Roles.ClientRole);
        var token = GenerateJwtToken(newUser);

        return token;
    }

    public async Task<string> RegisterVetAccount(UserRegistrationRequestDto userData, AddVetDto vetData)
    {
        var newUser = await RegisterUserAccount(userData, DAL.Entities.Roles.VetRole);
        
        var newVet = _mapper.Map<VetEntity>(vetData);
        newVet.ClientId = newUser.Id;
        
        await _unitOfWork.VetRepository.AddAsync(newVet);
        
        var token = GenerateJwtToken(newUser);

        return token;
    }

    public async Task<string> LoginUserAsync(LoginUserDto userData)
    {
        var existingUser = await _userManager.FindByEmailAsync(userData.Email);

        if (existingUser is null)
        {
            throw Exceptions.Exceptions.UserDoesNotExistException;
        }

        var passwordIsCorrect = await _userManager.CheckPasswordAsync(existingUser, userData.Password);

        if (!passwordIsCorrect)
        {
            throw Exceptions.Exceptions.InvalidPasswordException;
        }

        var jwtToken = GenerateJwtToken(existingUser);

        return jwtToken;
    }

    public async Task UpdateUserAccount(UpdateUserAccountDto userData)
    {
        var user = _mapper.Map<UserEntity>(userData);
        await _userManager.UpdateAsync(user);
    }

    public async Task DeleteUserAccount(Guid accountId)
    {
        var userToDelete = await _userManager.FindByIdAsync($"{accountId}");
        await _userManager.DeleteAsync(userToDelete);
    }

    private async Task<UserEntity> RegisterUserAccount(UserRegistrationRequestDto userData, string role)
    {
        var userIsExist = await _userManager.FindByEmailAsync(userData.Email);

        if (userIsExist is not null)
        {
            throw Exceptions.Exceptions.UserAlreadyExistsException;
        }

        var newUser = _mapper.Map<UserEntity>(userData);

        var isCreated = await _userManager.CreateAsync(newUser, userData.Password);
    
        if (!isCreated.Succeeded)
        {
            throw Exceptions.Exceptions.RegistrationFailedException;
        }

        await _userManager.AddToRoleAsync(newUser, role);
        
        return newUser;
    }

    private string GenerateJwtToken(UserEntity user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim("Id", $"{user.Id}"),
                new Claim("Role", $"{user.Role}"),
            }),
            Expires = DateTime.Now.AddMinutes(5),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256
            ),
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        return jwtTokenHandler.WriteToken(token);
    }
}
