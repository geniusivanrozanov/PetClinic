using System.Net;

namespace PetClinic.BLL.Interfaces;

public interface IExceptionsService
{
    HttpStatusCode GetStatusCodeAndMessageOnException(Exception exception);
}
