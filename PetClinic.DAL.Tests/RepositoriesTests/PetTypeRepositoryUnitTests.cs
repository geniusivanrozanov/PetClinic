using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using PetClinic.DAL.Repositories;
using PetClinic.DAL.Tests.TestEntities;

namespace PetClinic.DAL.Tests.RepositoriesTests;

public class PetTypeRepositoryUnitTests : DataAccessLayerUnitTestsBase<PetTypeEntity>
{
    protected override IRepository<PetTypeEntity, Guid> Repository => RepositoryManager.PetTypeRepository;
    
    public PetTypeRepositoryUnitTests() : 
        base(new PetTypeEntities())
    {
    }

}