using System.Net;
using System.Xml;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using InvalidDataException = System.IO.InvalidDataException;

namespace PetClinic.BLL.Services;

public class ExceptionsService : IExceptionsService
{
    private readonly Dictionary<Type, HttpStatusCode> _statusCodes;

    public ExceptionsService()
    {
        _statusCodes = new Dictionary<Type, HttpStatusCode>()
        {
            { typeof(NotFoundException), HttpStatusCode.NotFound },
            { typeof(InvalidDataException), HttpStatusCode.BadRequest },
            { typeof(UserAlreadyExistsException), HttpStatusCode.Conflict },
            { typeof(UserDoesNotExistException), HttpStatusCode.NotFound },
            { typeof(RegistrationFailedException), HttpStatusCode.BadRequest },
        };
    }

    public HttpStatusCode GetStatusCodeAndMessageOnException(Exception exception)
    {
        if (!_statusCodes.ContainsKey(exception.GetType()))
        {
            return HttpStatusCode.InternalServerError;
        }

        return _statusCodes[exception.GetType()];
    }
}
