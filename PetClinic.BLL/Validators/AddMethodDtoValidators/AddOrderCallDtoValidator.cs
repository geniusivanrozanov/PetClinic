using FluentValidation;
using PetClinic.BLL.DTOs.AddMethodDto;

namespace PetClinic.BLL.Validators.AddMethodDtoValidators;

public class AddOrderCallDtoValidator : AbstractValidator<AddOrderCallDto>
{
    public AddOrderCallDtoValidator()
    {
        RuleFor(oc => oc.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .MaximumLength(15)
            .WithMessage("Phone number should be no longer than 15 digits.");
    }
}
