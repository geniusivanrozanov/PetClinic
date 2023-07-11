using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Utilites;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IConfiguration _config;
    private readonly string _secretCode;

    public TokenService(UserManager<UserEntity> userManager, 
        IConfiguration config)
    {
        _userManager = userManager;
        _config = config;
        _secretCode = _config!["JwtConfig:Secret"];
    }

    public async Task<string> GenerateJwtTokenAsync(UserEntity user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_secretCode);
        
        var roles = await _userManager.GetRolesAsync(user);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim(AuthClaims.IdClaim, $"{user.Id}"),
                new Claim(ClaimTypes.Role, $"{roles[0]}"),
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
