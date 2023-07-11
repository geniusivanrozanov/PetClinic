using FluentValidation;
using PetClinic.BLL.DTOs.AddMethodDto;

namespace PetClinic.BLL.Validators.AddMethodDtoValidators;

public class AddReviewDtoValidator : AbstractValidator<AddReviewDto>
{
    public AddReviewDtoValidator()
    {
        RuleFor(r => r.AppointmentId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Field is required.");

        RuleFor(r => r.Diagnosis)
            .NotNull()
            .NotEmpty()
            .MaximumLength(300)
            .WithMessage("Longer than 300 characters or empty.");

        RuleFor(r => r.VetComments)
            .NotNull()
            .NotEmpty()
            .MaximumLength(300)
            .WithMessage("Longer than 300 characters or empty.");
    }
}
