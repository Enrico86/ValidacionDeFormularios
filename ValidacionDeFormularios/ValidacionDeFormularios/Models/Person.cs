using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ValidacionDeFormularios.Utilities;

namespace ValidacionDeFormularios.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string name;
        private string email;
        private bool isValid;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                Validate();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                Validate();
            }
        }
        public bool IsValid
        {
            get => isValid; set
            {
                isValid = value;
                OnPropertyChanged();
            }
        }

        private void Validate()
        {
            if (!string.IsNullOrEmpty(Name) && RegexUtilities.IsValidEmail(Email))
            {
                IsValid = true;
            }
            else IsValid = false;
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
