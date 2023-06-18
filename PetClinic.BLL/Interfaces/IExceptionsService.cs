namespace PetClinic.BLL.Interfaces;

public interface IExceptionsService
{
    (int statusCode, string message) GetStatusCodeAndMessageOnException(Exception exception);
}
