using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetClinic.BLL.Configurations;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Services;

public class ClientAccountService : IClientAccountService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly JwtConfig _jwtConfig;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public ClientAccountService(UserManager<UserEntity> userManager, IMapper mapper, IConfiguration config)
    {
        _userManager = userManager;
        _config = config;
        _jwtConfig = new JwtConfig
        {
            Secret = _config!["JwtConfig:Secret"]
        };
        _mapper = mapper;
    }

    public async Task<string> RegisterUser(UserRegistrationRequestDto userData)
    {
        var userIsExist = await _userManager.FindByEmailAsync(userData.Email);

        if (userIsExist is not null)
        {
            throw Exceptions.Exceptions.UserAlreadyExists;
        }

        var newUser = _mapper.Map<UserEntity>(userData);

        var isCreated = await _userManager.CreateAsync(newUser, userData.Password);
    
        if (!isCreated.Succeeded)
        {
            throw Exceptions.Exceptions.RegistrationFailedException;
        }

        var token = GenerateJwtToken(newUser);

        return token;
    }

    private string GenerateJwtToken(UserEntity user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim("Role", "Client"),
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
