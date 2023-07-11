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

    public IAppointmentRepository AppointmentRepository => _appointmentRepository ??= new AppointmentRepository(_context);
    public IDepartmentRepository DepartmentRepository => _departmentRepository ??= new DepartmentRepository(_context);
    public IOrderCallRepository OrderCallRepository => _orderCallRepository ??= new OrderCallRepository(_context);
    public IPetRepository PetRepository => _petRepository ??= new PetRepository(_context);
    public IPetTypeRepository PetTypeRepository => _petTypeRepository ??= new PetTypeRepository(_context);
    public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_context);
    public IServiceRepository ServiceRepository => _serviceRepository ??= new ServiceRepository(_context);
    public IServiceVetVetRepository ServiceVetRepository => _serviceVetRepository ??= new ServiceVetRepository(_context);
    public IVetRepository VetRepository => _vetRepository ??= new VetRepository(_context);

    public UnitOfWork(AppDbContext context)
    {
        _context = context;       
    }

    public int Complete() => _context.SaveChanges();

    public void Dispose() => _context.Dispose();

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
}
