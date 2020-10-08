using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacionDeFormularios.Validators;
using ValidacionDeFormularios.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidacionDeFormularios.Views.Fluent_Validator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FluentValidationView : ContentPage
    {
        FluentValidationViewViewModel vm = new FluentValidationViewViewModel(new FluentValidationViewModelValidator());

        public FluentValidationView()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ErrorsChanged += Vm_ErrorsChanged;
        }

        private void Vm_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            var propErrors =
                (vm.GetErrors(e.PropertyName) as List<string>)?.Any() == true;
            var messages = vm.GetErrors(e.PropertyName) as List<string>;
            var propText = string.Join("\n", messages);

            switch (e.PropertyName)
            {
                case nameof(vm.Name):
                    entryName.BackgroundColor = propErrors ? Color.LightCoral : Color.LightGreen;
                    entryName.TextColor = propErrors ? Color.DarkRed : Color.DarkGreen;
                    lblNameError.Text = propErrors ? propText : "";
                    lblNameError.IsVisible = propErrors ? true : false;
                    break;
                case nameof(vm.Email):
                    entryEmail.BackgroundColor = propErrors ? Color.LightCoral : Color.LightGreen;
                    entryEmail.TextColor = propErrors ? Color.DarkRed : Color.DarkGreen;
                    lblEmailError.Text = propErrors ? propText : "";
                    lblEmailError.IsVisible = propErrors ? true : false;
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