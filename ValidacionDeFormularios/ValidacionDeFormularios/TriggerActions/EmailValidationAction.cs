using System;
using System.Collections.Generic;
using System.Text;
using ValidacionDeFormularios.Utilities;
using Xamarin.Forms;

namespace ValidacionDeFormularios.TriggerActions
{
    public class EmailValidationAction : TriggerAction<Entry>
    {

        public Color ErrorBackgroundColor { get; set; }
        public Color ErrorTextColor { get; set; }
        public Color ValidBackgroundColor { get; set; }
        public Color ValidTextColor { get; set; }
        public EmailValidationAction()
        {
            ErrorBackgroundColor = Color.LightCoral;
            ErrorTextColor = Color.DarkRed;
            ValidBackgroundColor = Color.LightGreen;
            ValidTextColor = Color.DarkGreen;
        }

        protected override void Invoke(Entry sender)
        {
            bool isValid = RegexUtilities.IsValidEmail(sender.Text);
            sender.BackgroundColor = isValid ? ValidBackgroundColor : ErrorBackgroundColor;
            sender.TextColor = isValid ? ValidTextColor : ErrorTextColor;
        }
    }
}
