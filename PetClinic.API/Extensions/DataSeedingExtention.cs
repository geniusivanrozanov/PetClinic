using PetClinic.DAL;
using PetClinic.DAL.Configuration;

namespace PetClinic.API.Extensions;

public static class DataSeedingExtention
{
    public async static Task<IApplicationBuilder> SeedDataToDbAsync(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        
        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            await DbInitializer.SeedDataAsync(context);
        }
        catch (Exception ex)
        {
             
        }

        return app;
    }
}
