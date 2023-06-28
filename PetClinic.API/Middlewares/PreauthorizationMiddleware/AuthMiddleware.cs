using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PetClinic.BLL.Utilites;

namespace PetClinic.API.Middlewares.PreauthorizationMiddleware;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            var authHeader = httpContext.Request.Headers["Authorization"].ToString();
            
            if (authHeader is not "")
            {
                var tokenType = GetTokenType(authHeader);
                var token = authHeader.Replace($"{tokenType} ", "");
            
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var userRole = jwtSecurityToken.Claims.First(claim => claim.Type == AuthClaims.RoleClaim).Value;

                var claim = new Claim(ClaimTypes.Role, userRole);
                var claimsIdentity = new ClaimsIdentity(new[] { claim }, "BasicAuthentication");
                var claimPrincipal = new ClaimsPrincipal(claimsIdentity);

                httpContext.User = claimPrincipal;
            }
            
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    private string GetTokenType(string token)
    {
        return token.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
    }
}
