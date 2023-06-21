namespace PetClinic.DAL.Interfaces.Entities;

public interface IEntity<TId> : ICreatedAt, IUpdatedAt, IDeletable
{
    TId Id { get; set; }
}