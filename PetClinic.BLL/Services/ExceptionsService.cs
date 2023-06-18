using PetClinic.BLL.Interfaces;

namespace PetClinic.BLL.Services;

public class ExceptionsService : IExceptionsService
{
    public (int statusCode, string message) GetStatusCodeAndMessageOnException(Exception exception)
    {
        throw new NotImplementedException();
    }
}
