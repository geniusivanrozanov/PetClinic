namespace PetClinic.BLL.DTOs.GetMethodDto;

public class GetScheduleDto
{
    public DateTime AppointmentDate { get; set; }
    public Guid VetId { get; set; }
}
