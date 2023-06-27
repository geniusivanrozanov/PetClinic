namespace PetClinic.BLL.DTOs.GetMethodDto;

public class GetAppointmentDto
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; } = default!;
    public string ServiceName { get; set; } = default!;
    public string PetName { get; set; } = default!;
}
