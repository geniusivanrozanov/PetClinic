using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PetClinic.DAL.Interfaces.Repositories;
using PetClinic.DAL.Repositories;

namespace PetClinic.DAL.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {   
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    /// <summary>
    /// Registers database contexts to service collection
    /// </summary>
    /// <param name="services">services collection</param>
    /// <param name="configuration">application configuration</param>
    /// <exception cref="ArgumentNullException">If there is no connection string found</exception>
    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresPetClinic");
        ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString)
                   .UseLazyLoadingProxies();
        });
    }
    
    /// <summary>
    /// Applies migrations for <see cref="TContext"/>
    /// </summary>
    /// <param name="serviceProvider">Service provider</param>
    /// <typeparam name="TContext">Type of DbContext</typeparam>
    public static IServiceProvider MigrateDatabase<TContext>(this IServiceProvider serviceProvider) 
        where TContext : DbContext
    {
        using var scope = serviceProvider
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        try
        {
            var context = scope.ServiceProvider.GetRequiredService<TContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<TContext>>();
            logger.LogError(ex, "An error occurred while migrating the database");
            throw;
        }

        return serviceProvider;
    }
}
