namespace PetClinic.DAL.Entities;

public class PetTypeEntity : BaseEntity
{
    public string Name { get; set; } = default!;

    public List<PetEntity>? Pets { get; set; }
}
