using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PetClinic.DAL;
using PetClinic.DAL.Entities;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.Filters;

namespace PetClinic.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(configuration.GetSection("JwtConfig:Secret").Value!)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
    }

    public static void AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<UserEntity, RoleEntity>(options => 
            options.SignIn.RequireConfirmedEmail = false)
            .AddEntityFrameworkStores<AppDbContext>();
    }

    public static void AddSerilog(this ILoggingBuilder loggingBuilder)
    {
        var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();

        loggingBuilder.AddSerilog(logger);
    }

    public static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standart Authorization header using the Bearer scheme(\"bearer {token}\")",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    }
}
