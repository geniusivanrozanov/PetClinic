using PetClinic.BLL.Extensions;
using PetClinic.DAL;
using PetClinic.DAL.Extensions;
using Serilog;
using PetClinic.API.Extensions;


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Logging.AddSerilog();

builder.Services.AddControllers()
                .AddFluentValidation();

builder.Services.AddDataAccessLayer(configuration);
builder.Services.AddBusinessLogicLayer();

builder.Services.AddAuthentication();

builder.Services.AddIdentity();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    await app.SeedDataToDbAsync();
}

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Services.MigrateDatabase<AppDbContext>();

app.Run();
