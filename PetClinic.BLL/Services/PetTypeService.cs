using AutoMapper;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.ExceptionConstants;


namespace PetClinic.BLL.Services;

public class PetTypeService : IPetTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cachedService;


    public PetTypeService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cachedService)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
        this._cachedService = cachedService;
    }

    public async Task<IEnumerable<GetPetTypeDto>> GetPetTypesAsync()
    {
        var cachedPetTypes = await _cachedService.GetDataAsync<IEnumerable<GetPetTypeDto>>(CacheKeys.petTypesKey);
    
        if (cachedPetTypes is null)
        {
            var petTypes = await _unitOfWork.PetTypeRepository.GetAllAsync() ??
                throw new NotFoundException(ExceptionMessages.PetTypeNotFound);
        
        
            await _cachedService.SetDataAsync(CacheKeys.petTypesKey, petTypes, DateTimeOffset.Now.AddMinutes(1));
            return _mapper.Map<IEnumerable<GetPetTypeDto>>(petTypes);
        }

        return cachedPetTypes;
    }
}
