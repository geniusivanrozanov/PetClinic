using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IAppointmentRepository AppointmentRepository { get; }
    public IDepartmentRepository DepartmentRepository { get; }
    public IOrderCallRepository OrderCallRepository { get; }
    public IPetRepository PetRepository { get; }
    public IPetTypeRepository PetTypeRepository { get; }
    public IReviewRepository ReviewRepository { get; }
    public IServiceRepository ServiceRepository { get; }
    public IServiceVetVetRepository ServiceVetRepository { get; }
    public IVetRepository VetRepository { get; }
    
    int Complete();
    Task<int> CompleteAsync();
}
