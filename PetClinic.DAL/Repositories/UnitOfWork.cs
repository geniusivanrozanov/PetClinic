using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

namespace PetClinic.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context = null!;
    private AppointmentRepository _appointmentRepository = null!;
    private DepartmentRepository _departmentRepository = null!;
    private OrderCallRepository _orderCallRepository = null!;
    private PetRepository _petRepository = null!;
    private PetTypeRepository _petTypeRepository = null!;
    private ReviewRepository _reviewRepository = null!;
    private ServiceRepository _serviceRepository = null!;
    private ServiceVetRepository _serviceVetRepository = null!;
    private VetRepository _vetRepository = null!;

    public IRepository<AppointmentEntity, Guid> AppointmentRepository => _appointmentRepository ??= new AppointmentRepository(_context);
    public IRepository<DepartmentEntity, Guid> DepartmentRepository => _departmentRepository ??= new DepartmentRepository(_context);
    public IRepository<OrderCallEntity, Guid> OrderCallRepository => _orderCallRepository ??= new OrderCallRepository(_context);
    public IRepository<PetEntity, Guid> PetRepository => _petRepository ??= new PetRepository(_context);
    public IRepository<PetTypeEntity, Guid> PetTypeRepository => _petTypeRepository ??= new PetTypeRepository(_context);
    public IRepository<ReviewEntity, Guid> ReviewRepository => _reviewRepository ??= new ReviewRepository(_context);
    public IRepository<ServiceEntity, Guid> ServiceRepository => _serviceRepository ??= new ServiceRepository(_context);
    public IRepository<ServiceVetEntity, Guid> ServiceVetRepository => _serviceVetRepository ??= new ServiceVetRepository(_context);
    public IRepository<VetEntity, Guid> VetRepository => _vetRepository ??= new VetRepository(_context);

    public UnitOfWork(AppDbContext context)
    {
        _context = context;       
    }

    public int Complete() => _context.SaveChanges();

    public void Dispose() => _context.Dispose();

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
}
