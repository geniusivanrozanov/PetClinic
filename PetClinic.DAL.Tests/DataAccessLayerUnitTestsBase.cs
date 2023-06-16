using System.Collections.Immutable;
using System.Linq.Expressions;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PetClinic.DAL.Interfaces.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using PetClinic.DAL.Repositories;
using PetClinic.DAL.Tests.TestEntities;

namespace PetClinic.DAL.Tests;

public abstract class DataAccessLayerUnitTestsBase<TEntity> : IDisposable
    where TEntity : IEntity<Guid>
{
    private readonly SqliteConnection _sqliteConnection;
    private readonly AppDbContext _context;
    protected readonly UnitOfWork RepositoryManager;
    protected readonly EntitiesGenerator<TEntity> EntitiesGenerator;
    protected abstract IRepository<TEntity, Guid> Repository { get; }

    protected DataAccessLayerUnitTestsBase(EntitiesGenerator<TEntity> entitiesGenerator)
    {
        _sqliteConnection = new SqliteConnection(Configuration.SqliteConnectionString);
        _sqliteConnection.Open();
        
        var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(_sqliteConnection)
            .Options; 
        
        _context = new AppDbContext(contextOptions);
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        
        RepositoryManager = new UnitOfWork(_context);
        
        EntitiesGenerator = entitiesGenerator;
    }

    [Fact]
    public virtual void Add_SingleValidEntity_AddsSingleEntityToDataBase()
    {
        //Assign
        var entity = EntitiesGenerator.GetValidEntity();
        var startCount = Repository
            .GetAll()
            .Count();
        
        //Act
        Repository.Add(entity);
        RepositoryManager.Complete();

        var endCount = Repository
            .GetAll()
            .Count();
        var numberOfAddedEntities = endCount - startCount;

        //Assert
        numberOfAddedEntities.Should().Be(1);
        entity.Id.Should().NotBe(Guid.Empty);
        entity.CreatedAt.Should().NotBe(DateTime.MinValue);
        entity.UpdatedAt.Should().NotBe(DateTime.MinValue);
        entity.IsDeleted.Should().Be(false);
    }

    [Fact]
    public virtual void AddRange_ListOfValidEntities_AddsListOfEntitiesToDataBase()
    {
        //Assign
        var entities = EntitiesGenerator.GetValidEntitiesList();
        var startCount = Repository
            .GetAll()
            .Count();
        
        //Act
        Repository.AddRange(entities);
        RepositoryManager.Complete();

        var endCount = Repository
            .GetAll()
            .Count();
        var numberOfAddedEntities = endCount - startCount;

        //Assert
        numberOfAddedEntities.Should().Be(entities.Count());
        entities.Should().AllSatisfy((entity) =>
        {
            entity.Id.Should().NotBe(Guid.Empty);
            entity.CreatedAt.Should().NotBe(DateTime.MinValue);
            entity.UpdatedAt.Should().NotBe(DateTime.MinValue);
            entity.IsDeleted.Should().Be(false);
        });
    }

    [Fact]
    public virtual void Update_UpdatedEntity_UpdatesEntityDataInDataBase()
    {
        //Assign
        var entity = EntitiesGenerator.GetValidEntity();
        Repository.Add(entity);
        RepositoryManager.Complete();
        _context.ChangeTracker.Clear();

        var updatedEntity = EntitiesGenerator.CloneEntity(entity);
        EntitiesGenerator.UpdateEntity(updatedEntity);
        
        //Act
        Repository.Update(updatedEntity);
        RepositoryManager.Complete();
        
        //Assert
        updatedEntity.Id.Should().Be(entity.Id);
        updatedEntity.UpdatedAt.Should().NotBe(entity.UpdatedAt);
        updatedEntity.UpdatedAt.Should().NotBe(updatedEntity.CreatedAt);
    }

    [Fact]
    public virtual void Remove_ExistingEntity_SetsIsDeletedToTrue()
    {
        //Assign
        var entity = EntitiesGenerator.GetValidEntity();
        var startNumberOfEntities = Repository
            .GetAll()
            .Count();
        Repository.Add(entity);
        RepositoryManager.Complete();
        
        
        //Act
        Repository.Remove(entity);
        RepositoryManager.Complete();
        
        var endNumberOfEntities = Repository
            .GetAll()
            .Count();

        //Assert
        endNumberOfEntities.Should().Be(startNumberOfEntities);
        entity.IsDeleted.Should().BeTrue();
    }
    
    [Fact]
    public virtual void RemoveRange_ExistingEntities_SetsIsDeletedToTrueInAllDeletedEntities()
    {
        //Assign
        var entities = EntitiesGenerator.GetValidEntitiesList();
        var startNumberOfEntities = Repository
            .GetAll()
            .Count();
        Repository.AddRange(entities);
        RepositoryManager.Complete();
        
        
        //Act
        Repository.RemoveRange(entities);
        RepositoryManager.Complete();
        
        var endNumberOfEntities = Repository
            .GetAll()
            .Count();

        //Assert
        endNumberOfEntities.Should().Be(startNumberOfEntities);
        entities.Should().AllSatisfy((entity) =>
        {
            entity.IsDeleted.Should().BeTrue();
        });
    }

    [Fact]
    public virtual void Find_SearchFilterPredicate_ReturnsFoundEntitiesFromDataBase()
    {
        //Assign
        var notFilteredEntities = EntitiesGenerator.GetEntitiesForSearch();
        Repository.AddRange(notFilteredEntities);
        RepositoryManager.Complete();
        _context.ChangeTracker.Clear();

        var filter = EntitiesGenerator.GetFilterForSearch();
        var filteredEntities = notFilteredEntities.Where(filter.Compile());

        //Act
        var foundEntities = Repository
            .Find(filter)
            .ToList();
        
        //Assign
        foreach (var entity in filteredEntities)
        {
            foundEntities.Should().Contain(foundEntity => foundEntity.Id.Equals(entity.Id));
        }
    }
    
    public void Dispose()
    {
        _sqliteConnection.Dispose();
        _context.Dispose();
        RepositoryManager.Dispose();
    }
}