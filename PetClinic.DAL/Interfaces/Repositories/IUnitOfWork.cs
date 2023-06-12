using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
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
    int Complete();
    Task<int> CompleteAsync();
}
