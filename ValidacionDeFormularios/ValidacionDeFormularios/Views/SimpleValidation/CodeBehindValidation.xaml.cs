using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacionDeFormularios.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidacionDeFormularios.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeBehindValidation : ContentPage
    {
        public CodeBehindValidation()
        {
            InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            if (RegexUtilities.IsValidEmail(emailEntry.Text))
            {
                errorLabel.Text = "Email válido";
            }
            else errorLabel.Text = "Email incorrecto";
        }

        private void emailEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;
            var entry = sender as Entry;
            if (RegexUtilities.IsValidEmail(email))
            {
                errorLabel.Text = "Email válido";
                entry.BackgroundColor = Color.LightGreen;
                entry.TextColor = Color.DarkGreen;
            }
            else
            {
                errorLabel.Text = "Email incorrecto";
                entry.BackgroundColor = Color.LightCoral;
                entry.TextColor = Color.DarkRed;
            }

        }
    }
}