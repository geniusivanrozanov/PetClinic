using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Exceptions;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.ExceptionConstants;

namespace PetClinic.BLL.Services;

public class PetService : IPetService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cachedService;

    public PetService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cachedService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cachedService = cachedService;
    }

    public async Task AddPetAsync(AddPetDto pet)
    {
        var result = _mapper.Map<PetEntity>(pet);
        await _unitOfWork.PetRepository.AddPetAsync(result);
        await _unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.petsKey, DateTimeOffset.Now.AddMinutes(1));
    }

    public async Task DeletePetAsync(Guid id)
    {
        var pet = await _unitOfWork.PetRepository.GetPetAsync(id) ??
            throw new NotFoundException();

        _unitOfWork.PetRepository.RemovePet(pet);
        await _unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.petsKey, DateTimeOffset.Now.AddMinutes(1));
    }

    public async Task<GetPetDto> GetPetByIdAsync(Guid id)
    {
        var cachedPets = await _cachedService
            .GetDataAsync<IEnumerable<GetPetDto>>(CacheKeys.petsKey);

        if (cachedPets is null)
        {
            var pet = await _unitOfWork.PetRepository.GetPetAsync(id) ??
                throw new NotFoundException(ExceptionMessages.PetNotFound);

            return _mapper.Map<GetPetDto>(pet);
        }

        var cachPet = cachedPets.Where(d => d.Id == id).FirstOrDefault() ??
            throw new NotFoundException(ExceptionMessages.PetNotFound);

        return cachPet;
    }

    public async Task<IEnumerable<GetPetDto>> GetPetsAsync()
    {
        var pets = await _unitOfWork.PetRepository.GetAllPetAsync() ??
            throw new NotFoundException(ExceptionMessages.PetNotFound);
 
        return _mapper.Map<IEnumerable<GetPetDto>>(pets);
    }

    public async Task<GetPetDto> UpdatePetAsync(UpdatePetDto pet)
    {
        var mappedItem = _mapper.Map<PetEntity>(pet);
        var result = _unitOfWork.PetRepository.UpdatePet(mappedItem);

        await _unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.petsKey, DateTimeOffset.Now.AddMinutes(1));

        return _mapper.Map<GetPetDto>(result);
    }

    private async Task UpdateCacheAsync(string key, DateTimeOffset expiryTime)
    {
        var pets = await _unitOfWork.PetRepository.GetAllPetAsync();
        var petsDto = _mapper.Map<IEnumerable<GetPetDto>>(pets);

        await _cachedService.SetDataAsync(key, petsDto, expiryTime);
    }
}
