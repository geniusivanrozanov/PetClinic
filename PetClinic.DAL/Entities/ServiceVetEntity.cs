using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities
{
    public class ServiceVetEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public ServiceEntity Service { get; set; } = default!;

        public Guid VetId { get; set; }
        public VetEntity Vet { get; set; } = default!;

        public List<AppointmentEntity> Appointments { get; set; } = default!;
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
