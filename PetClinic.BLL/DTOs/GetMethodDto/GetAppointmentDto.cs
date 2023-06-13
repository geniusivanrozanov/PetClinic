namespace PetClinic.BLL.DTOs;

public class GetAppointmentDto
{
    public Guid Id { get; set; }
    public string AppointmentDate { get; set; } = default!;
    public string ServiceName { get; set; } = default!;
    public string PetName { get; set; } = default!;
}
