using FluentValidation;
using PetClinic.BLL.DTOs.AddMethodDto;

namespace PetClinic.BLL.Validators.AddMethodDtoValidators;

public class AddPetDtoValidator : AbstractValidator<AddPetDto>
{
    public AddPetDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(20)
            .WithMessage("Name should not ne emapty and" + 
                         "should be no longer than 20 characters.");
         
        RuleFor(p => p.ClientId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Field is required.");

        RuleFor(p => p.PetTypeId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Field is required.");
    }
}
