using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ValidacionDeFormularios.Models;
using ValidacionDeFormularios.Validators;

namespace ValidacionDeFormularios.ViewModels
{
    public class StudentPageViewModel: INotifyDataErrorInfo
    {
        public Student Student = new Student();
        IDictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        StudentValidator validator = new StudentValidator();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public string TextError { get; set; }

        public bool HasErrors => throw new NotImplementedException();

        public StudentPageViewModel()
        {
        }

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void Validate ([CallerMemberName] string propertyName ="")
        {
            if (validator==null)
            {
                throw new NullReferenceException("An instance of the validator is required");
            }
            var result = validator.Validate(Student);

        }

    }
}
