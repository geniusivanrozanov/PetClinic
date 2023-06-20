using AutoMapper;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Exceptions;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.ExceptionConstants;


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

    public async Task<IEnumerable<GetServiceDto>> GetServicesAsync()
    {
        var services = await unitOfWork.ServiceRepository.GetAllAsync();

        if (services is null)
        {
            throw new NotFoundException(ExceptionMessages.ServicesNotFound);
        }

        return mapper.Map<IEnumerable<GetServiceDto>>(services); 
    }

    public async Task<GetServiceDto> GetServiceByIdAsync(Guid serviceId)
    {
        var service = await unitOfWork.ServiceRepository.GetAsync(serviceId);

        if (service is null)
        {
            throw new NotFoundException(ExceptionMessages.ServicesNotFound);
        }

        return mapper.Map<GetServiceDto>(service);
    }
}
