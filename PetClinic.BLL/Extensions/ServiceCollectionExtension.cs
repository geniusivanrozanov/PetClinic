using System.Reflection;
using FluentValidation.AspNetCore;
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
        services.AddScoped<IServicesService, ServicesService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IUserAccountService, UserAccountService>();
        services.AddScoped<IOrderCallService, OrderCallService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IVetService, VetService>();
        services.AddScoped<IPetService, PetService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPetTypeService, PetTypeService>();
        
        services.AddSingleton<IExceptionsService, ExceptionsService>();
    }
}
