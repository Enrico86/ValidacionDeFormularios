using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacionDeFormularios.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidacionDeFormularios.Views.INDEInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SfDataFormView : ContentPage
    {
        public SfDataFormView()
        {
            InitializeComponent();
            BindingContext = new INDEIViewViewModel();
        }
    }
}