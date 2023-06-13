namespace PetClinic.BLL.DTOs;

public class AddAppointmentDto
{
    public string AppointmentDateAndTime { get; set; } = default!;
    public Guid PetId { get; set; } = default!;
    public Guid ServiceId { get; set; } = default!;
}
