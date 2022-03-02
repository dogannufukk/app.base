using AppProject.Application.Feature.Command.EquipmentCommand.CreateEquipmentCommand;
using FluentValidation;
using System;

namespace AppProject.Application.Validator.Concrete
{
    public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
    {
        public CreateEquipmentCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name.field.is.required");
            RuleFor(x => x.Name).NotNull().WithMessage("name.field.is.required");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("the.number.must.be.greater.than.1");
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo((decimal)0.01).WithMessage("the.number.must.be.greater.than.0_01");
            RuleFor(x => x.UsageRate).GreaterThan(0).WithMessage("the.number.must.be.greater.than.0_00");
            RuleFor(x => x.UsageRate).LessThanOrEqualTo(100).WithMessage("the.number.must.be.less.than.100");
            RuleFor(x => x.ClinicId).NotNull().WithMessage("clinic.field.is.required");

        }


    }
}
