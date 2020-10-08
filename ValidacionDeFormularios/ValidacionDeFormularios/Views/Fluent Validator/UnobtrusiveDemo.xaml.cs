﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacionDeFormularios.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidacionDeFormularios.Views.Fluent_Validator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnobtrusiveDemo : ContentPage
    {
        public UnobtrusiveDemo()
        {
            InitializeComponent();
            BindingContext = new UnobtrusiveDemoViewModel();
        }
    }
}