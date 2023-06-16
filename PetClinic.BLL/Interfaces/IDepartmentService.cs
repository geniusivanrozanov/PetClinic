using PetClinic.BLL.DTOs;

namespace PetClinic.BLL.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<GetDepartmentDto>> GetDepartmentsAsync();
    Task<GetDepartmentDto> GetDepatmentByIdAsync(Guid departmentId);
}
