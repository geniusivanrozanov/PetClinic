using System.Text.Json.Serialization;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class PetTypeEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    [JsonIgnore]
    public virtual List<PetEntity>? Pets { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
