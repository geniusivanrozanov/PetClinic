using Microsoft.Extensions.DependencyInjection;

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

    }
}
