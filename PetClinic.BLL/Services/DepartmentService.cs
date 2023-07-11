using AutoMapper;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Exceptions;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.ExceptionConstants;

namespace PetClinic.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<GetDepartmentDto>> GetDepartmentsAsync()
    {
        var cachedDepartments = await _cacheService.GetDataAsync<IEnumerable<GetDepartmentDto>>(CacheKeys.departmentsKey);
    
        if (cachedDepartments is null)
        {
            var departments = await _unitOfWork.DepartmentRepository.GetAllDepartmentsAsync() ?? 
                throw new NotFoundException(ExceptionMessages.DepartmentsNotFound);

            var departmentsDto = departments!.Select(department => new GetDepartmentDto
            {
                Id = department.Id,
                Address = department.Address,
                Name = department.Name,
                Vets = _mapper.Map<List<GetVetDto>>(department.Vets),
            });

            var expiryTime = DateTimeOffset.Now.AddMinutes(1);

            await _cacheService.SetDataAsync(CacheKeys.departmentsKey, departments, expiryTime);

            return departmentsDto;
        }
        
        return cachedDepartments;
    }

    public async Task<GetDepartmentDto> GetDepatmentByIdAsync(Guid departmentId)
    {
        var cachedDepartments = await _cacheService.GetDataAsync<IEnumerable<GetDepartmentDto>>(CacheKeys.departmentsKey);
            
        if (cachedDepartments is null)
        {
            var department = await _unitOfWork.DepartmentRepository.GetDepartmentAsync(departmentId) ??
                throw new NotFoundException(ExceptionMessages.DepartmentsNotFound);
        
            var departmentDto = _mapper.Map<GetDepartmentDto>(department);
            departmentDto.Vets = _mapper.Map<List<GetVetDto>>(department.Vets);

            return departmentDto;
        }

        var cachDepartment = cachedDepartments.Where(d => d.Id == departmentId).FirstOrDefault() ??
            throw new NotFoundException(ExceptionMessages.DepartmentsNotFound);

        return cachDepartment;
    }
}
