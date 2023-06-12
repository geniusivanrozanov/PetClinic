using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class StatusEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    public List<OrderCallEntity>? OrderCalls { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
