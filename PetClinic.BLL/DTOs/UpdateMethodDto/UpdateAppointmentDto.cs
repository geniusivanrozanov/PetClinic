namespace PetClinic.BLL.DTOs.UpdateMethodDto;

public class UpdateAppointmentDto
{
    public Guid Id { get; set; }
    public DateTime AppointmentDateAndTime { get; set; } = default!;
    public string PetId { get; set; } = default!;
    public string ServiceId { get; set; } = default!;
}
