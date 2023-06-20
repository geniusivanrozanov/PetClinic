using FluentValidation;
using PetClinic.BLL.DTOs.AuthDto;

namespace PetClinic.BLL.Validators.AuthMethodDtoValidators;

public class VetRegistrationRequestDtoValidator : AbstractValidator<VetRegistrationRequestDto>
{
    public VetRegistrationRequestDtoValidator()
    {
        RuleFor(v => v.AccountData.FirstName)
            .NotNull()
            .NotEmpty()
            .Length(2, 30)
            .WithMessage("Firstname should between 2 and 30 characters.");

        RuleFor(v => v.AccountData.LastName)
            .NotNull()
            .NotEmpty()
            .Length(4, 30)
            .WithMessage("Lastname should between 4 and 30 characters.");

        RuleFor(v => v.AccountData.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .MaximumLength(15)
            .WithMessage("Phone number should be longer than 15 digits.");

        RuleFor(v => v.AccountData.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Username should not be empty.");

        RuleFor(v => v.AccountData.Email)
            .NotNull()
            .NotEmpty()
            .Must(EmailValidator.IsValidEmail)
            .WithMessage("Invalid email.");

        RuleFor(v => v.AccountData.Password)
            .NotNull()
            .NotEmpty()
            .Must(PasswordValidator.IsValidPassword)
            .WithMessage("Invalid password");

        RuleFor(v => v.VetInfo.Experience)
            .NotNull()
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("More than 200 characters.");

        RuleFor(v => v.VetInfo.Bio)
            .NotNull()
            .NotEmpty()
            .MaximumLength(500)
            .WithMessage("More than 500 characters.");
    }
}
