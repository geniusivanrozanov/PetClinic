namespace PetClinic.BLL.DTOs.UpdateMethodDto;

public class UpdatePetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid ClientId { get; set; }
    public Guid PetTypeId { get; set; }
}
