using FluentValidation;
using PetClinic.BLL.DTOs.UpdateMethodDto;

namespace PetClinic.BLL.Validators.UpdateMethodDtoValidators;

public class UpdatePetDtoValidator : AbstractValidator<UpdatePetDto>
{
    public UpdatePetDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Id is required.");

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
