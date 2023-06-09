namespace PetClinic.DAL.Entities;

public class ServiceEntity : BaseEntity
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Duration { get; set; } = default!;

    public List<ServiceVetEntity>? ServiceVets { get; set; }
}
