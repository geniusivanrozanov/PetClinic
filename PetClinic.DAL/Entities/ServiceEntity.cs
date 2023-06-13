using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class ServiceEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Duration { get; set; } = default!;

    public virtual List<ServiceVetEntity>? ServiceVets { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
