using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetClinic.DAL.Interfaces.Repositories;
using PetClinic.DAL.Repositories;

namespace PetClinic.DAL
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostreSqlConnection")));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}