using AppProject.Application.Feature.Command.ClinicCommand.CreateClinicCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Validator.Concrete
{
    public class CreateClinicCommandValidator : AbstractValidator<CreateClinicCommand>
    {
        public CreateClinicCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("name.field.is.required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("name.field.is.required");
        }
    }
}
