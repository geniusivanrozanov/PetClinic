using FluentValidation;
using PetClinic.BLL.DTOs.AuthDto;

namespace PetClinic.BLL.Validators.AuthMethodDtoValidators;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator()
    {
        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .Must(EmailValidator.IsValidEmail)
            .WithMessage("Invalid email.");

        RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty()
            // .Must(PasswordValidator.IsValidPassword)
            .WithMessage("Invalid password");
    }
}
