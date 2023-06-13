namespace PetClinic.BLL.DTOs;

public class AddPetDto
{
    public string Name { get; set; } = default!;
    public Guid ClientId { get; set; }
    public Guid PetTypeId { get; set; }
}
