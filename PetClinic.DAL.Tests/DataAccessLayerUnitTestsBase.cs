using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PetClinic.DAL.Repositories;

namespace PetClinic.DAL.Tests;

public abstract class DataAccessLayerUnitTestsBase : IDisposable
{
    private readonly AppDbContext _context;
    protected readonly UnitOfWork RepositoryManager;

    protected DataAccessLayerUnitTestsBase()
    {
        var sqliteConnection = new SqliteConnection(Configuration.ConnectionString);
        sqliteConnection.Open();
        
        var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(sqliteConnection)
            .Options; 
        
        _context = new AppDbContext(contextOptions);
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        
        RepositoryManager = new UnitOfWork(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
        RepositoryManager.Dispose();
    }
}