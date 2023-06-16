namespace PetClinic.BLL.Exceptions;

public class Exceptions
{
    public static NotFoundException DepartmentsNotFound = new ("Departments are not found");
    public static NotFoundException ServicesNotFound = new ("Services are not found");
    public static NotFoundException DepartmentNotFound = new ("Department with the given id does not exist");
    public static NotFoundException ServiceNotFound = new ("Service with the given id does not exist");
    public static UserAlreadyExists UserAlreadyExists = new ("User with th same email was registered");
    public static RegistrationFailedException RegistrationFailedException = new ("Registration is failed");
    public static NotFoundException VetsNotFound = new("Vets are not found");
    public static NotFoundException VetNotFound = new("Vet with the given id does not exist");
    public static NotFoundException AppointmentNotFound = new("Appointment with the given id does not exist");
    public static NotFoundException AppointmentsNotFound = new("Appointments are not found");
    public static UserAlreadyExistsException UserAlreadyExistsException = new ("User with the same email was registered");
    public static UserDoesNotExistException UserDoesNotExistException = new ("User with the given email wasn't registered");
    public static InvalidDataException InvalidPasswordException = new ("Password is invalid");
}
