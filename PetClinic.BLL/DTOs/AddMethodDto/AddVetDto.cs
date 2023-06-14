namespace PetClinic.BLL.DTOs;

public class AddVetDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int Experience { get; set; }
    public string Bio { get; set; } = default!;
    public Guid DepartmentId { get; set; }
    public Guid? ClientId { get; set; }
}