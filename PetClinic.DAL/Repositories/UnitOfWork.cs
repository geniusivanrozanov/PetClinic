using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

namespace PetClinic.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IRepository<AppointmentEntity, Guid> AppointmentRepository { get; }
    public IRepository<DepartmentEntity, Guid> DepartmentRepository { get; }
    public IRepository<OrderCallEntity, Guid> OrderCallRepository { get; }
    public IRepository<PetEntity, Guid> PetRepository { get; }
    public IRepository<PetTypeEntity, Guid> PetTypeRepository { get; }
    public IRepository<ReviewEntity, Guid> ReviewRepository { get; }
    public IRepository<ServiceEntity, Guid> ServiceRepository { get; }
    public IRepository<ServiceVetEntity, Guid> ServiceVetRepository { get; }
    public IRepository<VetEntity, Guid> VetRepository { get; }


    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        AppointmentRepository = new AppointmentRepository(_context);
        DepartmentRepository = new DepartmentRepository(_context);
        OrderCallRepository = new OrderCallRepository(_context);
        PetRepository = new PetRepository(_context);
        PetTypeRepository = new PetTypeRepository(_context);
        ReviewRepository = new ReviewRepository(_context);
        ServiceRepository = new ServiceRepository(_context);
        ServiceVetRepository = new ServiceVetRepository(_context);
        VetRepository = new VetRepository(_context);
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
