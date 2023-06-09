namespace PetClinic.DAL.Entities;

public class OrderCallEntity : BaseEntity
{
    public string PhoneNumber { get; set; } = default!;
    
    public Guid StatusId { get; set; }
    public StatusEntity Status { get; set; } = default!;
}

