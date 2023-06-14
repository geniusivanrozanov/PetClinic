using AutoMapper;
using PetClinic.BLL.DTOs;
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

    public IEnumerable<GetDepartmentDto> GetDepartments()
    {
        var departments = unitOfWork.DepartmentRepository.GetAllAsync();

        if (departments is null)
        {
            throw Exceptions.Exceptions.DepartmentsNotFound;
        }

        return mapper.Map<IEnumerable<GetDepartmentDto>>(departments);
    }

    public GetDepartmentDto GetDepatmentById(Guid departmentId)
    {
        var department = unitOfWork.DepartmentRepository.GetAsync(departmentId);

        if (department is null)
        {
            throw Exceptions.Exceptions.DepartmentNotFound;
        }

        return mapper.Map<GetDepartmentDto>(department);
    }
}
