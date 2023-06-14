using AutoMapper;
using PetClinic.BLL.DTOs;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Interfaces.Repositories;

namespace PetClinic.BLL.Services;

public class ServicesService : IServicesService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ServicesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public IEnumerable<GetServiceDto> GetServices()
    {
        var services = unitOfWork.ServiceRepository.GetAllAsync();

        if (services is null)
        {
            throw Exceptions.Exceptions.ServicesNotFound;
        }

        return mapper.Map<IEnumerable<GetServiceDto>>(services); 
    }

    public GetServiceDto GetServiceById(Guid serviceId)
    {
        var service = unitOfWork.ServiceRepository.GetAsync(serviceId);

        if (service is null)
        {
            throw Exceptions.Exceptions.ServiceNotFound;
        }

        return mapper.Map<GetServiceDto>(service);
    }
}
