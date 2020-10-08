using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ValidacionDeFormularios.ViewModels;

namespace ValidacionDeFormularios.Validators
{
    public class FluentValidationViewModelValidator: AbstractValidator<FluentValidationViewViewModel>
    {
        public FluentValidationViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("At least 3 characters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email has not a correct format");
        }    
    }
}
