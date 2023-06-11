using PetClinic.DAL.DbContext;
using PetClinic.DAL.Interfaces.Repositories;

namespace PetClinic.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository Repository { get; }

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Repository = new Repository(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();   
        }

      
    }
}
