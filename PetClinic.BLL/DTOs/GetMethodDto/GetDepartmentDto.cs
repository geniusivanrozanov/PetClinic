namespace PetClinic.BLL.DTOs;

public class GetDepartmentDto
{
    public Guid Id { get; set; }
    public string Address { get; set; } = default!;
    public string Name { get; set; } = default!;
}

