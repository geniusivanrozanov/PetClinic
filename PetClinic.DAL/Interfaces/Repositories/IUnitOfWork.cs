namespace PetClinic.DAL.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository Repository { get; }
        int Complete();       
    }
}
