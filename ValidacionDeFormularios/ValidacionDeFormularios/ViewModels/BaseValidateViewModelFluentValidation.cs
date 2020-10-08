using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ValidacionDeFormularios.ViewModels
{
    public class BaseValidateViewModelFluentValidation : BaseViewModel, INotifyDataErrorInfo
    {

        IDictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        private readonly IValidator _validator;
        public BaseValidateViewModelFluentValidation(IValidator validator)
        {
            _validator = validator;
        }

        public bool HasErrors => 
            _errors?.Any(x=>x.Value?.Any()==true)==true;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName)&&_errors[propertyName].Any())
            {
                return _errors[propertyName];
            }
            return new List<string>();
        }

        public void Validate ([CallerMemberName] string propertyName ="")
        {
            if (_validator==null)
            {
                throw new NullReferenceException("An instance of IValidator is required");
            }

            var result = _validator.Validate(this);
            var errorMessages = result.Errors.Where(x => x.PropertyName == propertyName)
                .Select(em=>em.ErrorMessage).ToList();
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }
            if (errorMessages.Count>0)
            {
                foreach (var message in errorMessages)
                {
                    if (_errors.ContainsKey(propertyName))
                    {
                        _errors[propertyName].Add(message);
                    }
                    else _errors.Add(propertyName, new List<string> { message });
                }
            }
                    


            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


    }
}
