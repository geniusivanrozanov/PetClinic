namespace PetClinic.DAL.Entities;

public class AppointmentEntity : BaseEntity
{
    public DateTime DateTime { get; set; }

    public Guid ReviewId { get; set; }
    public ReviewEntity? Review { get; set; }

    public Guid PetId { get; set; }
    public PetEntity Pet { get; set; } = default!;

    public Guid ServiceId { get; set; }
    public ServiceVetEntity Service { get; set; } = default!;
}
