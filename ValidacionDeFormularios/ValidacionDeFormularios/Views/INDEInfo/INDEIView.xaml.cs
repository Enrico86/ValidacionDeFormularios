using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacionDeFormularios.Models;
using ValidacionDeFormularios.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidacionDeFormularios.Views.INDEInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class INDEIView : ContentPage
    {
        INDEIViewViewModel vm = new INDEIViewViewModel();
        public INDEIView()
        {
            InitializeComponent();
            this.BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ErrorsChanged += Vm_ErrorsChanged;
        }

        private void Vm_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {

            var propError = (vm.GetErrors(e.PropertyName)as List<string>)?.Any()==true;
            var messages = vm.GetErrors(e.PropertyName) as List<string>;
            var propErrorText = string.Join("\n", messages);
            switch (e.PropertyName)
            {
                case nameof(vm.Name):
                    {
                        entryName.BackgroundColor = propError ? Color.LightCoral : Color.LightGreen;
                        entryName.TextColor = propError ? Color.DarkRed : Color.DarkGreen;
                        lblNameError.IsVisible = propError ? true : false;
                        lblNameError.Text = propErrorText;
                    }
                    break;
                case nameof(vm.Email):
                    {
                        entryEmail.BackgroundColor = propError ? Color.LightCoral : Color.LightGreen;
                        entryEmail.TextColor = propError ? Color.DarkRed : Color.DarkGreen;
                        lblEmailError.IsVisible = propError ? true : false;
                        lblEmailError.Text = propErrorText;
                    }
                    break;
                default:
                    break;
            }
            if (vm.HasErrors)
            {
                buttonLogin.IsEnabled = false;
            }
            else buttonLogin.IsEnabled = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            vm.ErrorsChanged -= Vm_ErrorsChanged;
        }

    }
}