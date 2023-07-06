using FluentValidation;
using PetClinic.BLL.DTOs.UpdateMethodDto;

namespace PetClinic.BLL.Validators.UpdateMethodDtoValidators;

public class UpdateAppointmentDtoValidator : AbstractValidator<UpdateAppointmentDto>
{
    public UpdateAppointmentDtoValidator()
    {
        RuleFor(a => a.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(a => a.AppointmentDateAndTime)
            .NotNull()
            .NotEmpty()
            .WithMessage("Choose date and time.");

        RuleFor(a => a.PetId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Pet is required.");

        RuleFor(a => a.ServiceId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Service is required.");
    }
}
