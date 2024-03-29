using AutoMapper;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.PagingDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Features.Request.Paging;
using PetClinic.DAL.Features.Request.Paging.Parameters;
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
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cachedService = cachedService;
    }

    public async Task<IEnumerable<GetPetTypeDto>> GetPetTypesAsync()
    {
        var cachedPetTypes = await _cachedService.GetDataAsync<IEnumerable<GetPetTypeDto>>(CacheKeys.petTypesKey);
    
        if (cachedPetTypes is null)
        {
            var petTypes = await _unitOfWork.PetTypeRepository.GetAllPetTypesAsync() ??
                throw new NotFoundException(ExceptionMessages.PetTypeNotFound);
        
        
            await _cachedService.SetDataAsync(CacheKeys.petTypesKey, petTypes, DateTimeOffset.Now.AddMinutes(1));
            return _mapper.Map<IEnumerable<GetPetTypeDto>>(petTypes);
        }

        return cachedPetTypes;
    }

    public async Task<PagedList<GetPetTypeDto>> GetPetTypesPagedAsync(PetTypeParametersDto petTypeParametersDto)
    {
        var petTypeParameters = _mapper.Map<PetTypeParameters>(petTypeParametersDto);
        var petTypes = await _unitOfWork.PetTypeRepository.GetAllPetTypesAsync();
        var petTypesDto = _mapper.Map<IEnumerable<GetPetTypeDto>>(petTypes);

        return PagedList<GetPetTypeDto>.ToPagedList(petTypesDto, petTypeParameters.PageNumber, petTypeParameters.PageSize);
    }
}
