namespace PetClinic.BLL.DTOs.AuthDto;

public class GoogleDataResponse
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string VerifiedEmail { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public string Picture { get; set; }
    public string Locale { get; set; }    
}
