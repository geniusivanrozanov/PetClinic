using PetClinic.BLL.DTOs;

namespace PetClinic.BLL.Interfaces;

public interface IDepartmentService
{
    IEnumerable<GetDepartmentDto> GetDepartments();
    GetDepartmentDto GetDepatmentById(Guid departmentId);
}
