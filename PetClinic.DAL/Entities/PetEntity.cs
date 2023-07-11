using System.Text.Json.Serialization;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class PetEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    public Guid ClientId { get; set; }
    
    [JsonIgnore]
    public virtual UserEntity User { get; set; } = default!;

    public Guid PetTypeId { get; set; }
    public virtual PetTypeEntity PetType { get; set; } = default!;

    [JsonIgnore]
    public virtual List<AppointmentEntity>? Appointments { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
