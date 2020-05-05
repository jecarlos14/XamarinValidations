using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XamarinValidatios.Validations
{
    public class EmailChangeBehavior : Behavior<Entry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        static readonly BindablePropertyKey ColorValidationPropertyKey = BindableProperty.CreateReadOnly(nameof(ColorValidation), typeof(Color), typeof(Color), Color.Default);
        public static readonly BindableProperty ColorValidationProperty = ColorValidationPropertyKey.BindableProperty;

        public Color ColorValidation
        {
            get => (Color)GetValue(ColorValidationProperty);
            private set => SetValue(ColorValidationPropertyKey, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            //((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
            ColorValidation = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }
    }
}
