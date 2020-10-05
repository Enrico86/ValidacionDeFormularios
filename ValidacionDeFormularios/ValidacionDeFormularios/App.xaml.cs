using System;
using ValidacionDeFormularios.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidacionDeFormularios
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BehaviorsValidation();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
