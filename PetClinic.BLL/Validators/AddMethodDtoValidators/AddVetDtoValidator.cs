using FluentValidation;
using PetClinic.BLL.DTOs.AddMethodDto;

namespace PetClinic.BLL.Validators.AddMethodDtoValidators;

public class AddVetDtoValidator : AbstractValidator<AddVetDto>
{
    public AddVetDtoValidator()
    {
        RuleFor(v => v.FirstName)
            .NotNull()
            .NotEmpty()
            .Length(2, 30)
            .WithMessage("Firstname should between 2 and 30 characters.");

        RuleFor(v => v.LastName)
            .NotNull()
            .NotEmpty()
            .Length(4, 30)
            .WithMessage("Lastname should between 4 and 30 characters.");

        RuleFor(v => v.Experience)
            .NotNull()
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("More than 200 characters.");

        RuleFor(v => v.Bio)
            .NotNull()
            .NotEmpty()
            .MaximumLength(500)
            .WithMessage("More than 500 characters.");   

        RuleFor(v => v.DepartmentId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Field is required.");
    }
}
