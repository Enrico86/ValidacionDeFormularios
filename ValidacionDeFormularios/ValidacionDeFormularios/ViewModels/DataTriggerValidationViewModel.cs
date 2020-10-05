using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ValidacionDeFormularios.Models;
using ValidacionDeFormularios.Utilities;

namespace ValidacionDeFormularios.ViewModels
{
    public class DataTriggerValidationViewModel
    {
        public Person Person { get; set; }
        public DataTriggerValidationViewModel()
        {
            Person = new Person();
        }
    }
}
