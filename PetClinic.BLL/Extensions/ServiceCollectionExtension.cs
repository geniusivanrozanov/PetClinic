using Microsoft.Extensions.DependencyInjection;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Services;

namespace PetClinic.BLL.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddServices();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IServicesService, ServicesService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IClientAccountService, ClientAccountService>();
    }
}
