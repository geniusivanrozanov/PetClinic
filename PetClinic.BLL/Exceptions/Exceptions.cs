namespace PetClinic.BLL.Exceptions;

public class Exceptions
{
    public static NotFoundException DepartmentsNotFound = new ("Departments are not found");
    public static NotFoundException ServicesNotFound = new ("Services are not found");
    public static NotFoundException DepartmentNotFound = new ("Department with the given id does not exist");
    public static NotFoundException ServiceNotFound = new ("Service with the given id does not exist");
    public static UserAlreadyExists UserAlreadyExists = new ("User with th same email was registered");
    public static RegistrationFailedException RegistrationFailedException = new ("Registration is failed");
}
