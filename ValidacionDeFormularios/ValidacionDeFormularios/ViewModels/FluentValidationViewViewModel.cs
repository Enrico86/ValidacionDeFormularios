using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValidacionDeFormularios.ViewModels
{
    public class FluentValidationViewViewModel : BaseValidateViewModelFluentValidation
    {
        private string name;
        private string email;

        public FluentValidationViewViewModel(IValidator validator) : base(validator)
        {
        }

        public string Name
        {
            get => name; 
            set
            {
                name = value;
                Validate();
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email; 
            set
            {
                email = value;
                Validate();
                OnPropertyChanged();
            }
        }
    }
}
