namespace PetClinic.DAL.Entities;

public class ReviewEntity : BaseEntity
{
    public string Diagnosis { get; set; } = default!;
    public string VetComments { get; set; } = default!;

    public AppointmentEntity Appointment { get; set; } = default!;
}