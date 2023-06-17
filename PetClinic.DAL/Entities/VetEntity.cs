using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class VetEntity : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Experience { get; set; } = default!;
    public string Bio { get; set; } = default!;

    public Guid DepartmentId { get; set; }
    public virtual DepartmentEntity Department { get; set; } = default!;
    
    public Guid ClientId { get; set; }
    public virtual UserEntity User { get; set; } = default!;

    public virtual List<ServiceVetEntity>? ServiceVets { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
