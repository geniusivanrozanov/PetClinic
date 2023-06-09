namespace PetClinic.DAL.Entities;

public class VetEntity : BaseEntity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int Experience { get; set; }    
    public string Bio { get; set; } = default!;

    public Guid DepartmentId { get; set; }
    public DepartmentEntity Department { get; set; } = default!;
    
    public Guid ClientId { get; set; }
    public UserEntity User { get; set; } = default!;

    public List<ServiceVetEntity>? ServiceVets { get; set; }
}
