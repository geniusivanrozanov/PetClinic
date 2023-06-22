using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PetClinic.DAL.Entities;
using Serilog;
using Serilog.Events;

namespace PetClinic.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options => 
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwt => 
        {
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("JwtConfig:Secret").Value!);

            jwt.SaveToken = true;
            jwt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration.GetSection("JwtConfig:Issuer").Value,
                ValidateAudience = true,
                ValidAudience = configuration.GetSection("JwtConfig:Audience").Value,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                RequireExpirationTime = true,
            };
        });

        services.AddAuthorization(opts => {
            opts.AddPolicy(PolicyNames.ClientPolicy, policy =>
                policy.RequireClaim(AuthClaims.RoleClaim, Roles.ClientRole)
            );
            opts.AddPolicy(PolicyNames.AdminPolicy, policy =>
                policy.RequireClaim(AuthClaims.RoleClaim, Roles.AdminRole)
            );
            opts.AddPolicy(PolicyNames.VetPolicy, policy =>
                policy.RequireClaim(AuthClaims.RoleClaim, Roles.VetRole)
            );
            opts.AddPolicy(PolicyNames.AdminClientPolicy, policy =>
                policy.RequireClaim(AuthClaims.RoleClaim, Roles.AdminRole, Roles.ClientRole)
            );
            opts.AddPolicy(PolicyNames.AdminVetPolicy, policy =>
                policy.RequireClaim(AuthClaims.RoleClaim, Roles.AdminRole, Roles.VetRole)
            );
        });
    }

    public static void AddSerilog(this ILoggingBuilder loggingBuilder)
    {
        var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();

        loggingBuilder.AddSerilog(logger);
    }
}
