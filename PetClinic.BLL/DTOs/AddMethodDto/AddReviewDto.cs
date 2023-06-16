namespace PetClinic.BLL.DTOs.AddMethodDto;

public class AddReviewDto
{
    public Guid AppointmentId { get; set; }
    public string Diagmosis { get; set; } = default!;
    public string VetComments { get; set; } = default!;
}
