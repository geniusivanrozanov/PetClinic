namespace PetClinic.BLL.DTOs.GetMethodDto;

public class GetScheduleDto
{
    public DateOnly AppointmentDate { get; set; }
    public Guid VetId { get; set; }
}
