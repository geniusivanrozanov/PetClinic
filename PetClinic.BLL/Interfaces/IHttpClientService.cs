namespace PetClinic.BLL.Interfaces;

public interface IHttpClientService
{
    Task<string> Execute(string token);
}
