namespace PetClinic.BLL.DTOs.UpdateMethodDto;

public class UpdateAppointmentDto
{
    public Guid Id { get; set; }
    public string AppointmentDateAndTime { get; set; } = default!;
    public Guid PetId { get; set; } = default!;
    public Guid ServiceId { get; set; } = default!;
}
