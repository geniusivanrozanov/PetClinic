namespace PetClinic.BLL.DTOs;

public class GetServiceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Duration { get; set; } = default!;
    public Guid VetId { get; set; }
}
