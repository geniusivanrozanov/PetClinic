using System.Text.RegularExpressions;

namespace PetClinic.BLL.Validators.AuthMethodDtoValidators;

public static class PasswordValidator
{
    public static bool IsValidPassword(string password)
    {
        bool result = password.Length >= 7 && password.Length <= 16
            && Regex.IsMatch(password, "[A-Z]")
            && Regex.IsMatch(password, "[a-z]")
            && Regex.IsMatch(password, @"\d")
            && Regex.IsMatch(password, @"[!-/:-@\[-_{-~]")
            && !Regex.IsMatch(password, @"[^\dA-Za-z!-/:-@\[-_{-~]");

        return result;
    }
}
