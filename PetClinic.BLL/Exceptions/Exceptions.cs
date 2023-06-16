namespace PetClinic.BLL.Exceptions;

public static class Exceptions
{
    public const string DepartmentsNotFound = "Departments are not found";
    public const string ServicesNotFound = "Services are not found";
    public const string VetsNotFound = "Vets are not found";
    public const string AppointmentsNotFound = "Appointments are not found";
    public const string PetNotFound = "Pets are not found";

    public const string UserAlreadyExists = "User with th same email was registered";
    public const string UserDoesNotExist = "User with the given email wasn't registered";

    public const string RegistrationFailed = "Registration is failed";
    public const string InvalidPassword = "Password is invalid";
}
