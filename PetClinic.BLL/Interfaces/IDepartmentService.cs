using PetClinic.BLL.DTOs.GetMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<GetDepartmentDto>> GetDepartmentsAsync();
    Task<GetDepartmentDto> GetDepatmentByIdAsync(Guid departmentId);
}
