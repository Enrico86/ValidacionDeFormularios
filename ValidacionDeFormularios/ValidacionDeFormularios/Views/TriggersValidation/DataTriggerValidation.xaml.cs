using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacionDeFormularios.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidacionDeFormularios.Views.TriggersValidation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataTriggerValidation : ContentPage
    {
        public DataTriggerValidation()
        {
            InitializeComponent();
            this.BindingContext = new DataTriggerValidationViewModel();
        }
    }
}