using FluentValidation;
using PetClinic.BLL.DTOs.AddMethodDto;

namespace PetClinic.BLL.Validators.AddMethodDtoValidators;

public class AddAppointmentDtoValidator : AbstractValidator<AddAppointmentDto>
{
    public AddAppointmentDtoValidator()
    {
        RuleFor(a => a.AppointmentDateAndTime)
            .NotNull()
            .NotEmpty()
            .WithMessage("Choose date and time.");

        RuleFor(a => a.PetId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Pet is requered.");

        RuleFor(a => a.ServiceId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Service is requered.");
    }
}
