using PetClinic.DAL.Entities;

namespace PetClinic.BLL.DTOs.GetMethodDto;

public class GetServiceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Duration { get; set; } = default!;
    // public List<GetVetDto>? ServiceVets { get; set; }
}
