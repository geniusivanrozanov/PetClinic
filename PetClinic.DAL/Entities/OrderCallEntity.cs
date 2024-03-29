using System.Text.Json.Serialization;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class OrderCallEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; } = default!;
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
