namespace PetClinic.BLL.DTOs.GetMethodDto;

public class GetOrderCallDto
{
    public Guid Id { get; set; }
    public string Status { get; set; } = default!;     
}
