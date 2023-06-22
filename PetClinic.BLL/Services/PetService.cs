using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Exceptions;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.Exceptions;


namespace PetClinic.BLL.Services;

public class PetService : IPetService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ICacheService cachedService;

    public PetService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cachedService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.cachedService = cachedService;
    }
    
    public async Task AddPetAsync(AddPetDto pet)
    {
        var result = mapper.Map<PetEntity>(pet);
        await unitOfWork.PetRepository.AddAsync(result);
        await unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.petsKey, DateTimeOffset.Now.AddMinutes(1));
    }

    public async Task DeletePetAsync(Guid id)
    {
        var pet = await unitOfWork.PetRepository.GetAsync(id) ?? 
            throw new NotFoundException();

        unitOfWork.PetRepository.Remove(pet);
        await unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.petsKey, DateTimeOffset.Now.AddMinutes(1));
    }

    public async Task<GetPetDto> GetPetByIdAsync(Guid id)
    {
        var cachedPets = await cachedService
            .GetDataAsync<IEnumerable<GetPetDto>>(CacheKeys.petsKey);

        if (cachedPets is null)
        {
            var pet = await unitOfWork.PetRepository.GetAsync(id) ??
                throw new NotFoundException(ExceptionMessages.PetNotFound);
            
            return mapper.Map<GetPetDto>(pet);
        }

        var cachPet = cachedPets.Where(d => d.Id == id).FirstOrDefault() ??
            throw new NotFoundException(ExceptionMessages.DepartmentsNotFound);

        return cachPet;
    }

    public async Task<IEnumerable<GetPetDto>> GetPetsAsync()
    {
        var pets = await unitOfWork.PetRepository.GetAllAsync() ??
            throw new NotFoundException(ExceptionMessages.PetNotFound);
        
        return mapper.Map<IEnumerable<GetPetDto>>(pets);
    }

    public async Task<GetPetDto> UpdatePetAsync(UpdatePetDto pet)
    {
        var mappedItem = mapper.Map<PetEntity>(pet);
        var result = unitOfWork.PetRepository.Update(mappedItem);

        await unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.petsKey, DateTimeOffset.Now.AddMinutes(1));

        return mapper.Map<GetPetDto>(result);
    }

    private async Task UpdateCacheAsync(string key, DateTimeOffset expiryTime)
    {
        var pets = await unitOfWork.PetRepository.GetAllAsync();
        var petsDto = mapper.Map<IEnumerable<GetPetDto>>(pets);

        await cachedService.SetDataAsync(key, petsDto, expiryTime);
    }
}