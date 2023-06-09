namespace PetClinic.DAL.Entities
{
    public class ServiceVetEntity : BaseEntity
    {
        public Guid ServiceId { get; set; }
        public ServiceEntity Service { get; set; } = default!;

        public Guid VetId { get; set; }
        public VetEntity Vet { get; set; } = default!;

        public List<AppointmentEntity> Appointments { get; set; } = default!;
    }
}
