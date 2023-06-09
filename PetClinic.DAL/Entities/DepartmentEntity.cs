namespace PetClinic.DAL.Entities;

public class DepartmentEntity : BaseEntity
{
    public string Address { get; set; } = default!;
    public string Name { get; set; } = default!;

    public List<VetEntity> Vets { get; set; }
}
