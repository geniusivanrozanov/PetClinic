namespace PetClinic.DAL.Interfaces.Entities;

public interface IDeletable
{
    bool IsDeleted { get; set; }
}