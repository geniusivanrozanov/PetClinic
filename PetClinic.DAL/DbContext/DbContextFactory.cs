using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PetClinic.DAL.DbContext;

public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        string connectionString = "User ID=admin;Password=admin;Host=localhost;Port=5432;Database=petClinic; Integrated Security=true;Pooling=true;";
        optionsBuilder.UseNpgsql(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        
        return new AppDbContext(optionsBuilder.Options);
    }
}
