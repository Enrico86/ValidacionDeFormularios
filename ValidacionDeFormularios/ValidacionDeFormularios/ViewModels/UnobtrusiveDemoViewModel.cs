using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ValidacionDeFormularios.Validators;
using Xamarin.Forms;
using Xamarin.Plugins.FluentValidation;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace ValidacionDeFormularios.ViewModels
{
    [FluentValidation.Attributes.Validator(typeof(UnobtrusiveDemoValidator))]
    public class UnobtrusiveDemoViewModel: AbstractValidationViewModel
    {
        public ValidatableProperty<string> Name { get; set; }
        = new ValidatableProperty<string>();
        public ValidatableProperty<string> Email { get; set; }
        = new ValidatableProperty<string>();
        public ICommand ValidateCommand { get; set; }
        public UnobtrusiveDemoViewModel()
        {
            ValidateCommand = new Command(() =>
              {
                  Validate(); 
              });
        }
    }
}
