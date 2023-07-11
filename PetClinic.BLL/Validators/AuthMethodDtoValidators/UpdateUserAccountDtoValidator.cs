using FluentValidation;
using PetClinic.BLL.DTOs.AuthDto;

namespace PetClinic.BLL.Validators.AuthMethodDtoValidators;

public class UpdateUserAccountDtoValidator : AbstractValidator<UpdateUserAccountDto>
{
    public UpdateUserAccountDtoValidator()
    {
        RuleFor(u => u.FirstName)
            .NotNull()
            .NotEmpty()
            .Length(2, 30)
            .WithMessage("Firstname should between 2 and 30 characters.");

        RuleFor(u => u.LastName)
            .NotNull()
            .NotEmpty()
            .Length(4, 30)
            .WithMessage("Lastname should between 4 and 30 characters.");

        RuleFor(u => u.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .MaximumLength(15)
            .WithMessage("Phone number should be longer than 15 digits.");

        RuleFor(u => u.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Username should not be empty.");

        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Invalid email.");
    }
}
