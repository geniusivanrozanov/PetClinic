using AutoMapper;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Exceptions;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.ExceptionConstants;

namespace PetClinic.BLL.Services;

public class ServicesService : IServicesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public ServicesService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<GetServiceDto>> GetServicesAsync()
    {
        var cachedServices = await _cacheService.GetDataAsync<IEnumerable<GetServiceDto>>(CacheKeys.servicesKey);
    
        if (cachedServices is null)
        {
            var services = await _unitOfWork.ServiceRepository.GetAllAsync() ??
                throw new NotFoundException(ExceptionMessages.ServicesNotFound);
            
            await _cacheService.SetDataAsync(CacheKeys.servicesKey, services, DateTimeOffset.Now.AddMinutes(1));

            return _mapper.Map<IEnumerable<GetServiceDto>>(services);
        }

        return cachedServices;
    }

    public async Task<GetServiceDto> GetServiceByIdAsync(Guid serviceId)
    {
        var cachedServices = await _cacheService
            .GetDataAsync<IEnumerable<GetServiceDto>>(CacheKeys.servicesKey);

        if (cachedServices is null)
        {
            var service = await _unitOfWork.ServiceRepository.GetAsync(serviceId) ?? 
                throw new NotFoundException(ExceptionMessages.ServicesNotFound);

            return _mapper.Map<GetServiceDto>(service);
        }        

        var cachService = cachedServices.Where(d => d.Id == serviceId).FirstOrDefault() ??
            throw new NotFoundException(ExceptionMessages.ServicesNotFound);

        return cachService;
    }
}
