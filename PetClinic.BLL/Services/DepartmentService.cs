using AutoMapper;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Interfaces.Repositories;

namespace PetClinic.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<GetDepartmentDto>> GetDepartmentsAsync()
    {
        var departments = await unitOfWork.DepartmentRepository.GetAllAsync();

        if (departments is null)
        {
            throw Exceptions.Exceptions.DepartmentsNotFound;
        }

        return mapper.Map<IEnumerable<GetDepartmentDto>>(departments);
    }

    public async Task<GetDepartmentDto> GetDepatmentByIdAsync(Guid departmentId)
    {
        var department = await unitOfWork.DepartmentRepository.GetAsync(departmentId);

        if (department is null)
        {
            throw Exceptions.Exceptions.DepartmentNotFound;
        }

        return mapper.Map<GetDepartmentDto>(department);
    }
}
