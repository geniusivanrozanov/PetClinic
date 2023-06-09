namespace PetClinic.DAL.Entities;

public class StatusEntity : BaseEntity
{
    public string Name { get; set; } = default!;

    public List<OrderCallEntity>? OrderCalls { get; set; }
}
