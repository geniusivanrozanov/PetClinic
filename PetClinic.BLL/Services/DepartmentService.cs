using AutoMapper;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Exceptions;
using PetClinic.DAL.Interfaces.Repositories;


using ExceptionMessages = PetClinic.BLL.Exceptions.ExceptionConstants;

namespace PetClinic.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ICacheService cacheService;

    public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.cacheService = cacheService;
    }

    public async Task<IEnumerable<GetDepartmentDto>> GetDepartmentsAsync()
    {
        var cachedDepartments = await cacheService.GetDataAsync<IEnumerable<GetDepartmentDto>>(CacheKeys.departmentsKey);
    
        if (cachedDepartments is null)
        {
            var departments = await unitOfWork.DepartmentRepository.GetAllAsync() ?? 
                throw new NotFoundException(ExceptionMessages.DepartmentsNotFound);

            var departmentsDto = departments!.Select(department => new GetDepartmentDto
            {
                Id = department.Id,
                Address = department.Address,
                Name = department.Name,
                Vets = mapper.Map<List<GetVetDto>>(department.Vets),
            });

            var expiryTime = DateTimeOffset.Now.AddMinutes(1);

            await cacheService.SetDataAsync(CacheKeys.departmentsKey, departments, expiryTime);

            return departmentsDto;
        }
        
        return cachedDepartments;
    }

    public async Task<GetDepartmentDto> GetDepatmentByIdAsync(Guid departmentId)
    {
        var cachedDepartments = await cacheService.GetDataAsync<IEnumerable<GetDepartmentDto>>(CacheKeys.departmentsKey);
            
        if (cachedDepartments is null)
        {
            var department = await unitOfWork.DepartmentRepository.GetAsync(departmentId) ??
                throw new NotFoundException(ExceptionMessages.DepartmentsNotFound);
        
            var departmentDto = mapper.Map<GetDepartmentDto>(department);
            departmentDto.Vets = mapper.Map<List<GetVetDto>>(department.Vets);

            return departmentDto;
        }

        var cachDepartment = cachedDepartments.Where(d => d.Id == departmentId).FirstOrDefault() ??
            throw new NotFoundException(ExceptionMessages.DepartmentsNotFound);

        return cachDepartment;
    }
}
