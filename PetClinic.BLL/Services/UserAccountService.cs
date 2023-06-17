using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.DTOs.DeleteMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.Exceptions;


namespace PetClinic.BLL.Services;

public class UserAccountService : IUserAccountService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string _secretCode;

    public UserAccountService(UserManager<UserEntity> userManager, 
        IMapper mapper, IConfiguration config, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _config = config;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _secretCode = _config!["JwtConfig:Secret"];
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

        await _unitOfWork.CompleteAsync();

        var token = await GenerateJwtTokenAsync(newUser);

        return token;
    }

    public async Task<string> RegisterVetAccount(UserRegistrationRequestDto userData, AddVetDto vetData)
    {
        var newUser = await RegisterUserAccount(userData, DAL.Entities.Roles.VetRole);
        
        var newVet = _mapper.Map<VetEntity>(vetData);
        newVet.ClientId = newUser.Id;
        
        await _unitOfWork.VetRepository.AddAsync(newVet);
        await _unitOfWork.CompleteAsync();

        var token = await GenerateJwtTokenAsync(newUser);

        return token;
    }
    
    public async Task<string> LoginUserAsync(LoginUserDto userData)
    {
        var existingUser = await _userManager.FindByEmailAsync(userData.Email);

        if (existingUser is null)
        {
            throw new UserDoesNotExistException(ExceptionMessages.UserDoesNotExist);
        }

        var passwordIsCorrect = await _userManager.CheckPasswordAsync(existingUser, userData.Password);

        if (!passwordIsCorrect)
        {
            throw new Exceptions.InvalidDataException(ExceptionMessages.InvalidPassword);
        }

        var jwtToken = await GenerateJwtTokenAsync(existingUser);

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
        await _unitOfWork.CompleteAsync();

        return newUser;
    }

    private async Task<string> GenerateJwtTokenAsync(UserEntity user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_secretCode);
        
        var roles = await _userManager.GetRolesAsync(user);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim("Id", $"{user.Id}"),
                new Claim("Role", $"{roles[0]}"),
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