namespace PetClinic.BLL.Exceptions;

public class RegistrationFailedException : Exception
{
    public RegistrationFailedException() { }
    public RegistrationFailedException(string message)
        : base(message) { }
    public RegistrationFailedException(string message, Exception inner)
        : base(message, inner) { }   
}
