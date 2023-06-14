<<<<<<< HEAD
=======
using PetClinic.BLL.Configurations;
>>>>>>> 477e7d9a35b33a364d53deb6466ac9415c59bf9a
using PetClinic.BLL.Extensions;
using PetClinic.DAL;
using PetClinic.DAL.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
<<<<<<< HEAD
using PetClinic.DAL.Entities;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.Filters;
=======
using Microsoft.AspNetCore.Identity.UI;
using PetClinic.DAL.Entities;
>>>>>>> 477e7d9a35b33a364d53deb6466ac9415c59bf9a

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Logging.AddSerilog(logger);
builder.Services.AddDataAccessLayer(configuration);
builder.Services.AddBusinessLogicLayer();

<<<<<<< HEAD
builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme,
=======
// builder.Services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
builder.Services.AddAuthentication(options => 
{
>>>>>>> 477e7d9a35b33a364d53deb6466ac9415c59bf9a
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt => 
{
<<<<<<< HEAD
    var key = Encoding.ASCII.GetBytes(configuration.GetSection("JwtConfig:Secret").Value!);
=======
    var key = Encoding.ASCII.GetBytes(configuration.GetSection("JwtConfig:Secret").Value);
>>>>>>> 477e7d9a35b33a364d53deb6466ac9415c59bf9a

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

builder.Services.AddDefaultIdentity<UserEntity>(options => 
    options.SignIn.RequireConfirmedEmail = false)
<<<<<<< HEAD
    .AddRoles<RoleEntity>()
=======
>>>>>>> 477e7d9a35b33a364d53deb6466ac9415c59bf9a
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
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
<<<<<<< HEAD

=======
>>>>>>> 477e7d9a35b33a364d53deb6466ac9415c59bf9a
app.UseAuthorization();

app.MapControllers();

app.Services.MigrateDatabase<AppDbContext>();

app.Run();
