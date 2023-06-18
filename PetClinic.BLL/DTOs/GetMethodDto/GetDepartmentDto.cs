namespace PetClinic.BLL.DTOs.GetMethodDto;

public class GetDepartmentDto
{
    public Guid Id { get; set; }
    public string Address { get; set; } = default!;
    public string Name { get; set; } = default!;
    public List<GetVetDto>? Vets { get; set; }
}

