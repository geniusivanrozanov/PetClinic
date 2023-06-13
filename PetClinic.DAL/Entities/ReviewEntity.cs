using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class ReviewEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Diagnosis { get; set; } = default!;
    public string VetComments { get; set; } = default!;

    public virtual AppointmentEntity Appointment { get; set; } = default!;
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}