using PetClinic.BLL.Extensions;
using PetClinic.DAL;
using PetClinic.DAL.Extensions;
using Serilog;
using Serilog.Events;
using PetClinic.API.Extensions;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PetClinic.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers()
                .AddFluentValidation();

builder.Services.AddDataAccessLayer(configuration);
builder.Services.AddBusinessLogicLayer();

builder.Services.AddAuthorization(opts => {
        opts.AddPolicy("Client", policy =>
            policy.RequireClaim("Role", Roles.ClientRole)
        );
        opts.AddPolicy("Admin", policy =>
            policy.RequireClaim("Role", Roles.AdminRole)
        );
        opts.AddPolicy("Vet", policy =>
            policy.RequireClaim("Role", Roles.VetRole)
        );
    });

builder.Services.AddDefaultIdentity<UserEntity>()
    .AddRoles<RoleEntity>()
    .AddEntityFrameworkStores<AppDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standart Authorization header using the Bearer scheme(\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Pet Clinic API",
        Description = "API."
    });

    // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // options.IncludeXmlComments(xmlPath);
}
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value!)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Services.MigrateDatabase<AppDbContext>();

app.Run();
