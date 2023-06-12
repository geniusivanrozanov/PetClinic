using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class DepartmentEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Address { get; set; } = default!;
    public string Name { get; set; } = default!;

    public List<VetEntity>? Vets { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
