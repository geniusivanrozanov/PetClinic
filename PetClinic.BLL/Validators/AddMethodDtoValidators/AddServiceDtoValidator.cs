using FluentValidation;
using PetClinic.BLL.DTOs.AddMethodDto;

namespace PetClinic.BLL.Validators.AddMethodDtoValidators;

public class AddServiceDtoValidator : AbstractValidator<AddServiceDto>
{
    public AddServiceDtoValidator()
    {
        RuleFor(s => s.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("More than 20 characters or empty.");

        RuleFor(s => s.Duration)
            .NotNull()
            .NotEmpty()
            .WithMessage("Field is required.");

        RuleFor(s => s.Price)
            .NotNull()
            .NotEmpty()
            .WithMessage("Field is required.");
    }
}
