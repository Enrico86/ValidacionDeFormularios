using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ValidacionDeFormularios.ViewModels;
using Xamarin.Plugins.FluentValidation;

namespace ValidacionDeFormularios.Validators
{
    public class UnobtrusiveDemoValidator: EnhancedAbstractValidator<UnobtrusiveDemoViewModel>
    {
        public UnobtrusiveDemoValidator()
        {
            RuleForProp(x => x.Name).NotNull().WithMessage("Name con not be null");
            RuleForProp(x => x.Email).EmailAddress().WithMessage("Email has not a correct format");
        }
    }
}
