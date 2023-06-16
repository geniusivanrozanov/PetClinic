using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PetClinic.DAL;
using PetClinic.DAL.Entities;
using Serilog;
using Serilog.Events;

namespace PetClinic.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
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
