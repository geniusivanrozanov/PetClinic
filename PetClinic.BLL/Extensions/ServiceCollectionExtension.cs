using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
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

    public static void AddFluentValidation(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.AddFluentValidation(fv => {
            fv.ImplicitlyValidateChildProperties = true;
            fv.ImplicitlyValidateRootCollectionElements = true;
            
            fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IServicesService, ServicesService>()
                .AddScoped<IDepartmentService, DepartmentService>()
                .AddScoped<IUserAccountService, UserAccountService>()
                .AddScoped<IOrderCallService, OrderCallService>()
                .AddScoped<IAppointmentService, AppointmentService>()
                .AddScoped<IVetService, VetService>()
                .AddScoped<IPetService, PetService>()
                .AddScoped<IPetTypeService, PetTypeService>()
                .AddScoped<ICacheService, CacheService>()
                .AddSingleton<IExceptionsService, ExceptionsService>();
    }
}
