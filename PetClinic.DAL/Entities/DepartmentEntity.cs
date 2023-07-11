using System.Text.Json.Serialization;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class DepartmentEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Address { get; set; } = default!;
    public string Name { get; set; } = default!;

    [JsonIgnore]
    public virtual List<VetEntity>? Vets { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
