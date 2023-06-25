namespace PetClinic.BLL.DTOs.AddMethodDto;

public class AddAppointmentDto
{
    public DateTime AppointmentDateAndTime { get; set; } = default!;
    public string PetId { get; set; } = default!;
    public string ServiceId { get; set; } = default!;
}
