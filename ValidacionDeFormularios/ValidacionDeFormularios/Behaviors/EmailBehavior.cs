using System;
using System.Collections.Generic;
using System.Text;
using ValidacionDeFormularios.Utilities;
using Xamarin.Forms;

namespace ValidacionDeFormularios.Behaviors
{
    public class EmailBehavior: Behavior<Entry>
    {
        public static readonly BindableProperty errorBackgroundColorProperty
            = BindableProperty.Create
            (
                "errorBackgroundColor",
                typeof(Color),
                typeof(EmailBehavior),
                Color.Default
            );
        public static readonly BindableProperty errorTextColorProperty
            = BindableProperty.Create("errorTextColor",typeof(Color),typeof(EmailBehavior),Color.Default);
        public static readonly BindableProperty validBackgroundColorProperty
            = BindableProperty.Create("validBackgroundColor", typeof(Color), typeof(EmailBehavior), Color.Default);
        public static readonly BindableProperty validTextColorProperty
            = BindableProperty.Create("validTextColor", typeof(Color), typeof(EmailBehavior), Color.Default);

        public Color ErrorBackgroundColor
        {
            get { return (Color)GetValue(errorBackgroundColorProperty); }
            set { SetValue(errorBackgroundColorProperty, value); }
        }

        public Color ErrorTextColor
        {
            get { return (Color)GetValue(errorTextColorProperty); }
            set { SetValue(errorTextColorProperty,value); }
        }

        public Color ValidBackgroundColor
        {
            get { return (Color)GetValue(validBackgroundColorProperty); }
            set { SetValue(validBackgroundColorProperty, value); }
        }

        public Color ValidTextColor
        {
            get { return (Color)GetValue(validTextColorProperty); }
            set { SetValue(validTextColorProperty, value); }
        }

        static readonly BindablePropertyKey IsValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailBehavior), false);
        public static readonly BindableProperty IsValidProperty =
            IsValidPropertyKey.BindableProperty;
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidPropertyKey, value); }
        }


        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;
            var entry = sender as Entry;
            IsValid = RegexUtilities.IsValidEmail(email);
            entry.BackgroundColor = RegexUtilities.IsValidEmail(email) ? ValidBackgroundColor : ErrorBackgroundColor;
            entry.TextColor = RegexUtilities.IsValidEmail(email) ? ValidTextColor : ErrorTextColor;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }
    }
}
