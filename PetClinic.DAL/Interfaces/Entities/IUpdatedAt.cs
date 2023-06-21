using System;

namespace PetClinic.DAL.Interfaces.Entities;

public interface IUpdatedAt
{
    DateTime UpdatedAt { get; set; }
}