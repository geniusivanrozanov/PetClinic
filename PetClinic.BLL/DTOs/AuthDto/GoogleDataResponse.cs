
using Newtonsoft.Json;

namespace PetClinic.BLL.DTOs.AuthDto;

public class GoogleDataResponse
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("verified_email")]
    public string VerifiedEmail { get; set; }
    
    [JsonProperty("given_name")]
    public string GivenName { get; set; }

    [JsonProperty("family_name")]
    public string FamilyName { get; set; } 
    public string Picture { get; set; }
    public string Locale { get; set; }    
}
