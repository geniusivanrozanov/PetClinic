namespace PetClinic.BLL.DTOs;

public class AddServiceDto
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Duration { get; set; } = default!;
}
