﻿using System;
using ValidacionDeFormularios.Views;
using ValidacionDeFormularios.Views.Fluent_Validator;
using ValidacionDeFormularios.Views.INDEInfo;
using ValidacionDeFormularios.Views.TriggersValidation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidacionDeFormularios
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FluentValidationView();
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
