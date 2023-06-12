using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class AppointmentEntity : IEntity<Guid>
{
    public Guid Id { get; set; }

    public DateTime DateTime { get; set; }

    public Guid ReviewId { get; set; }
    public ReviewEntity? Review { get; set; }

    public Guid PetId { get; set; }
    public PetEntity Pet { get; set; } = default!;

    public Guid ServiceId { get; set; }
    public ServiceVetEntity Service { get; set; } = default!;
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
