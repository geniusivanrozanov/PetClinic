namespace PetClinic.BLL.DTOs.AddMethodDto;

public class AddPetDto
{
    public string Name { get; set; } = default!;
    public string ClientId { get; set; } = default!;
    public string PetTypeId { get; set; } = default!;
}
