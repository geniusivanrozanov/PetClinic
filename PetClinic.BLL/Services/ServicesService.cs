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
    private readonly ICacheService cacheService;

    public ServicesService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.cacheService = cacheService;
    }

    public async Task<IEnumerable<GetServiceDto>> GetServicesAsync()
    {
        var cachedServices = await cacheService.GetDataAsync<IEnumerable<GetServiceDto>>(CacheKeys.servicesKey);
    
        if (cachedServices is null)
        {
            var services = await unitOfWork.ServiceRepository.GetAllAsync() ??
                throw new NotFoundException(ExceptionMessages.ServicesNotFound);
            
            await cacheService.SetDataAsync(CacheKeys.servicesKey, services, DateTimeOffset.Now.AddMinutes(1));
            return mapper.Map<IEnumerable<GetServiceDto>>(services);
        }

        return cachedServices;
    }

    public async Task<GetServiceDto> GetServiceByIdAsync(Guid serviceId)
    {
        var cachedServices = await cacheService
            .GetDataAsync<IEnumerable<GetServiceDto>>(CacheKeys.appointmentsKey);

        if (cachedServices is null)
        {
            var service = await unitOfWork.ServiceRepository.GetAsync(serviceId) ?? 
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);

            return mapper.Map<GetServiceDto>(service);
        }        

        var cachService = cachedServices.Where(d => d.Id == serviceId).FirstOrDefault() ??
            throw new NotFoundException(ExceptionMessages.DepartmentsNotFound);

        return cachService;
    }
}
