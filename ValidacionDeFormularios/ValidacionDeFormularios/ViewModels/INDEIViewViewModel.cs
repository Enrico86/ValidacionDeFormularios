using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ValidacionDeFormularios.Models;
using ValidacionDeFormularios.Utilities;

namespace ValidacionDeFormularios.ViewModels
{
    public class INDEIViewViewModel : /*INotifyPropertyChanged, INotifyDataErrorInfo*/ BaseValidateViewModel
    {

        private string name;

        [MinLength(5,ErrorMessage ="Name should be at least 5 characters.")]
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                Validate(Name, ()=>!string.IsNullOrWhiteSpace(Name),"The Name is not valid");
                OnPropertyChanged();
            }
        }

        private string email;
        [MinLength(10,ErrorMessage ="Email should be at least 10 characters")]
        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                Validate(Email, ()=>RegexUtilities.IsValidEmail(Email), "The email is incorrect");
                OnPropertyChanged();
            }
        }

        //IDictionary<string, string> _errors = new Dictionary<string, string>();

        //public bool HasErrors =>
        //    _errors?.Any(x => x.Value?.Any() == true) == true;

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    if (_errors.ContainsKey(propertyName) && _errors[propertyName].Any())
        //    {
        //        return new List<string> { _errors[propertyName] };
        //    }
        //    else return new List<string>();
        //}

        //public void Validate(string error, [CallerMemberName] string propertyName = "")
        //{
        //    if (propertyName.Contains("Email"))
        //    {
        //        if (!RegexUtilities.IsValidEmail(Email))
        //        {
        //            if (!_errors.ContainsKey(propertyName))
        //            {
        //                _errors.Add(propertyName, error);
        //            }
        //        }
        //        else _errors.Remove(propertyName);
        //    }
        //    if (propertyName.Contains("Name"))
        //    {
        //        if (string.IsNullOrEmpty(Name))
        //        {
        //            if (!_errors.ContainsKey(propertyName))
        //            {
        //                _errors.Add(propertyName, error);
        //            }
        //        }
        //        else _errors.Remove(propertyName);
        //    }

        //    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        //}

        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //#region PropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //#endregion
    }
}
