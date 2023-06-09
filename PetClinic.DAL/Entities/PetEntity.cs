namespace PetClinic.DAL.Entities;

public class PetEntity : BaseEntity
{
    public string Name { get; set; } = default!;

    public Guid ClientId { get; set; }
    public UserEntity User { get; set; } = default!;

    public Guid PetTypeId { get; set; }
    public PetTypeEntity PetType { get; set; } = default!;

    public List<AppointmentEntity>? Appointments { get; set; }
}
