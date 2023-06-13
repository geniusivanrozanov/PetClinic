namespace PetClinic.BLL.DTOs;

public class GetOrderCallDto
{
    public Guid Id { get; set; }
    public string Status { get; set; } = default!;     
}
